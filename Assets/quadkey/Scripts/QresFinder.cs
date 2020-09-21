using System;
using System.IO;
using UnityEngine;
using System.Collections.Generic;

namespace Aiskwk.Map
{
    public enum QresType { TextureFile, Elevations };

    public class QresFinder
    {
        QresType qresType;
        ElevProvider eleprov;
        MapProvider mapprov;
        MapExtentTypeE mapextent;
        int lod;
        int nrow_x;
        int ncol_z;
        string scenename;
        string fileName;
        string scenePathName;
        //string oldfileName;
        //string oldpathName;
        string fullName;
        string resFullName;
        public long last_loaded_texsize;
        string text = null;
        Texture2D tex = null;
        bool exists = false;
        bool loaded = false;
        public QresFinder(ElevProvider eleprov, string scenename, int nrow_x,int ncol_z, string oldpathname, string oldfilename, bool loadData=true )
        {
            // Example: 
            //          pathname = "qkmaps/scenemaps/bing/tukwila/texmap/16/"
            //          filename = "tex.png"
            //          pathname = "qkmaps/scenemaps/bing/tukwila/elv13-13qk/"
            //          filename = "eledata.csv"
            //
            // probably need to split pathname up into pieces 
            //    /qkmaps
            //    /scenemaps (or combine these two)
            //    /{mapprov}
            //    /{scenename}
            //    /texmap
            //    /{size}
            this.qresType =  QresType.Elevations;
            this.eleprov = eleprov;
            //this.oldfileName = oldfilename;
            //this.oldpathName = oldpathname;
            this.lod = -1;
            this.nrow_x = nrow_x;
            this.ncol_z = ncol_z;

            Init(scenename, loadData: loadData);
        }
        public QresFinder(MapProvider mapprov, string scenename, int lod,  MapExtentTypeE mapextent,bool loadData = true)
        {
            this.qresType = QresType.TextureFile;
            this.mapprov = mapprov;
            this.mapextent = mapextent;
            this.lod = lod;
            //this.oldfileName = oldfilename;
            //this.oldpathName = oldpathname;
            Init(scenename, loadData: loadData);
        }
        public string GetTextureFullName(MapExtentTypeE mapextent)
        {
            var texname = "tex.png";
            if (mapextent == MapExtentTypeE.AsSpecified)
            {
                texname = "croppedtex.png";
            }
            return texname;
        }
        public string GetElevFullName()
        {
            var fname = "eledata.csv";
            return fname;
        }
        void SetFilename()
        {
            switch (qresType)
            {
                case QresType.TextureFile:
                    {
                        fileName = GetTextureFullName(mapextent);
                        break;
                    }
                case QresType.Elevations:
                    {
                        fileName = GetElevFullName();
                        break;
                    }
            }
        }
        void Init(string scenename, bool loadData = true)
        {
            this.scenename = scenename;
            this.scenePathName = GetSubDir();
            if (scenePathName.Length > 0 && !this.scenePathName.EndsWith("/"))
            {
                scenePathName += "/";
            }
            SetFilename();
            this.fullName = scenePathName + fileName;
            this.resFullName = StripExtension(scenePathName + fileName);
            loaded = false;
            if (loadData)
            {
                FindAndLoadFiles();
            }
            //Debug.Log("qrp - PersistantPath:" + PersistentPathName());
            //Debug.Log("qrp - TempPath      :" + TempPathName());
        }
        public static string GetTextureSubDir(MapProvider mapprov, string scenename, int levelOfDetail)
        {
            var mapsubdir = QkMan.GetMapProvSubdirName(mapprov);
            var dirname = $"scenemaps/{mapsubdir}/{scenename}/texmap/lod{levelOfDetail}/";

            return dirname;
        }

        public static string GetTextureRoot()
        {
            var rv = $"scenemaps/";
            return rv;
        }

        public static string GetElevationSubDir(ElevProvider eleprov, string scenename, int nrowx, int ncolz)
        {
            var elesubdir = QkMan.GetElevProvSubdirName(eleprov);
            var dirname = $"scenemaps/{elesubdir}/{scenename}/elev/grid{nrowx}x{ncolz}/";
            return dirname;
        }

        string GetSubDir()
        {
            var rv = "";
            switch (qresType)
            {
                case QresType.TextureFile:
                    {
                        rv = GetTextureSubDir(mapprov, scenename, lod);
                        break;
                    }
                case QresType.Elevations:
                    {
                        rv = GetElevationSubDir(eleprov, scenename, nrow_x,ncol_z);
                        break;
                    }
            }
            return rv;
        }

        public string GetFullName()
        {
            return resFullName;
        }

        public FileInfo GetTexFileInfo(MapExtentTypeE mapextent)
        {
            var fname = GetSceneDependentPersistentPathName() + GetTextureFullName(mapextent);
            var fi = new FileInfo(fname);
            return fi;
        }
        public FileInfo GetElevFileInfo()
        {
            var fname = GetSceneDependentPersistentPathName() +   GetElevFullName();
            var fi = new FileInfo(fname);
            return fi;
        }
        public static bool EnsureExistenceOfDirectory(string fname)
        {
            var ok = true;
            try
            {
                var fileInfo = new FileInfo(fname);
                if (!fileInfo.Directory.Exists)
                {
                    Debug.Log("Creating " + fname);
                    fileInfo.Directory.Create();
                }
            }
            catch (Exception ex)
            {
                Debug.LogError(ex.Message);
                ok = false;
            }
            return ok;
        }
        public static string StripExtension(string sin)
        {
            var lidx = sin.LastIndexOf('.');
            var sout = sin;
            if (lidx >= 0)
            {
                sout = sin.Remove(lidx);
            }
            return sout;
        }

        public string GetTempPathSceneRoot()
        {
            //  tpath = "C:/Users/mike/AppData/Local/Temp/DefaultCompany/campusim/scenemaps/bing/satlabels/MsftB121focused/texmap/lod18/"
            var tpn = Application.temporaryCachePath + "/scenemaps";
            return tpn;
        }
        public string GetSceneDependentTempPathName()
        {
            //  tpath = "C:/Users/mike/AppData/Local/Temp/DefaultCompany/campusim/scenemaps/bing/satlabels/MsftB121focused/texmap/lod18/"
            var tpn = Application.temporaryCachePath + "/" + scenePathName;
            return tpn;
        }

        string GetElevPfd1(MapExtentTypeE me)
        {
            var rv = "";
            var fi = GetElevFileInfo();
            var dts = "---";
            var fsize = "0";
            if (fi.Exists)
            {
                dts = fi.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss");
                fsize = (fi.Length / 1e6).ToString("f2");
            }
            rv += $"{GetElevFullName()}  MB:{fsize} {dts}";
            return rv;
        }
        string GetTexPfd1(MapExtentTypeE me)
        {
            var rv = "";
            var fi = GetTexFileInfo(me);
            var dts = "---";
            var fsize = "0";
            if (fi.Exists)
            {
                dts = fi.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss");
                fsize = (fi.Length / 1e6).ToString("f2");
            }
            rv += $"{GetTextureFullName(me)}  MB:{fsize} {dts}";
            return rv;
        }

        public string GetPersistentFileData()
        {
            var rv = "";
            switch (qresType)
            {
                default:
                case QresType.TextureFile:
                    {
                        rv += GetTexPfd1(MapExtentTypeE.SnapToTiles) + "   -   ";
                        rv += GetTexPfd1(MapExtentTypeE.AsSpecified);
                        break;
                    }
                case QresType.Elevations:
                    {
                        rv += GetElevPfd1(MapExtentTypeE.SnapToTiles) + "   -   ";
                        rv += GetElevPfd1(MapExtentTypeE.AsSpecified);
                        break;
                    }

            }
            return rv;
        }
        public string GetTempFileData(string name,string mask)
        {
            var dname = GetSceneDependentTempPathName();
            var pnglist = new string[0];
            var di = new DirectoryInfo(dname);
            var smintime = "";
            var smaxtime = "";
            long bytecnt = 0;
            if (di.Exists)
            {
                pnglist = Directory.GetFiles(dname, mask, SearchOption.TopDirectoryOnly);
                var mintime = DateTime.MaxValue;
                var maxtime = DateTime.MinValue;
                foreach (string fname in pnglist)
                {
                    var fi = new FileInfo(fname);
                    var dt = fi.LastWriteTime;
                    if (dt < mintime) mintime = dt;
                    if (dt > maxtime) maxtime = dt;
                    bytecnt += fi.Length;
                }
                smintime = mintime.ToString("yyyy-MM-dd HH:mm:ss");
                smaxtime = maxtime.ToString("yyyy-MM-dd HH:mm:ss");
            }
            int pngcnt = pnglist.Length;
            var tsize = (bytecnt / 1e6).ToString("f2");
            var rv = $"{name} files:{pngcnt} MB:{tsize}   mintime:{smintime}  maxtime:{smaxtime}";
            return rv;
        }

        public string GetTempFileData()
        {
            var rv = "";
            switch(qresType)
            {
                case QresType.TextureFile:
                    {
                        rv = GetTempFileData("Png", "*.png");
                        break;
                    }

                case QresType.Elevations:
                    {
                        rv = GetTempFileData("Req/Resp", "*.*");
                        break;
                    }
            }
            return rv;
        }
        public string GetPersistentPathNameSceneRoot()
        {
            var ppn = Application.persistentDataPath + "/scenemaps/";
            return ppn;
        }
        public string GetSceneDependentPersistentPathName()
        {
            // ppath = "C:/Users/mike/AppData/LocalLow/DefaultCompany/campusim/scenemaps/bing/satlabels/MsftB121focused/texmap/lod18/"
            var ppn = Application.persistentDataPath + "/" + scenePathName;
            return ppn;
        }
        public string GetPersistentPathNameWide()
        {
            var ppn = Application.persistentDataPath;
            return ppn;
        }
        public bool Exists()
        {
            return exists;
        }
        public void LoadIfNeeded()
        {
            if (!loaded)
            {
                FindAndLoadFiles();
            }
        }
        public Texture2D GetTex()
        {
            LoadIfNeeded();
            return tex;
        }
        public string GetText()
        {
            return text;
        }
        public string[] GetLines()
        {
            var linearr = text.Split('\n');
            return linearr;
        }
        public void Reload()
        {
            FindAndLoadFiles();
        }
        void FindAndLoadFiles()
        {
            switch (qresType)
            {
                case QresType.TextureFile:
                    {
                        FindAndLoadBitmap();
                        break;
                    }
                case QresType.Elevations:
                    {
                        FindAndLoadCsv();
                        break;
                    }
            }
            loaded = true;
        }
        Texture2D LoadBitmap(string filePath)
        {
            filePath = filePath.ToLower();
            Texture2D tex = null;
            byte[] fileData;

            if (File.Exists(filePath))
            {
                var fi = new FileInfo(filePath);
                last_loaded_texsize = fi.Length;
                fileData = File.ReadAllBytes(filePath);
                tex = new Texture2D(width: 2, height: 2);
                tex.LoadImage(fileData); //..this will auto-resize the texture dimensions.
            }
            //Debug.Log("Loaded file " + filePath + " bytes" + last_loaded_texsize);
            return tex;
        }
        void FindAndLoadBitmap()
        {
            if (qresType != QresType.TextureFile)
            {
                Debug.Log($"Error {fileName} QresFinder is not of type QresType.Bitmap");
            }
            tex = Resources.Load<Texture2D>(resFullName);
            if (tex != null)
            {
                Debug.Log("QresFinder - Bitmap sucessfully retrieved from Resources");
                exists = true;
                return;
            }
            var ppFllName = GetSceneDependentPersistentPathName() + fileName;
            if (File.Exists(ppFllName))
            {
                tex = LoadBitmap(ppFllName);
                if (tex != null)
                {
                    //Debug.Log("QresFinder - Bitmap sucessfully retrieved from File");
                    exists = true;
                }
            }
        }
        public bool CheckCsvExistence()
        {
            var ppFllName = GetSceneDependentPersistentPathName() + fileName;
            return File.Exists(ppFllName);
        }


        void FindAndLoadCsv()
        {
            exists = false;
            if (qresType != QresType.Elevations)
            {
                Debug.LogError($"Error {fileName} QresFinder is not of type QresType.CsvFile");
            }
            var textasset = Resources.Load<TextAsset>(resFullName);
            if (textasset != null)
            {
                //Debug.Log("QresFinder - Text sucessfully retrieved from Resources");
                exists = true;
                text = textasset.text;
                return;
            }
            var ppFllName = GetSceneDependentPersistentPathName() + fileName;
            //Debug.LogWarning($"Loading csv from {ppFllName}");
            if (File.Exists(ppFllName))
            {
                text = File.ReadAllText(ppFllName);
                if (text != null)
                {
                    //Debug.Log("QresFinder - Text sucessfully retrieved from File");
                    exists = true;
                }
            }
        }

    }
}