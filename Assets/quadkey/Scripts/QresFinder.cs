using System;
using System.IO;
using UnityEngine;
using System.Collections.Generic;

namespace Aiskwk.Map
{
    public class QresFinder
    {

        enum QresType { BitmapFile, CsvFile };
        QresType qresType;
        string fileName;
        string pathName;
        string fullName;
        string resFullName;
        public long last_loaded_texsize;
        string text = null;
        Texture2D tex = null;
        bool exists = false;
        public QresFinder(string pathname, string filename)
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
            this.qresType = QresType.BitmapFile;
            if (filename.EndsWith(".csv"))
            {
                this.qresType = QresType.CsvFile;
            }
            this.fileName = filename;
            this.pathName = pathname;
            if (pathName.Length > 0 && !this.pathName.EndsWith("/"))
            {
                pathName += "/";
            }
            this.fullName = pathName + fileName;
            this.resFullName = StripExtension(pathName + fileName);
            Load();
            //Debug.Log("qrp - PersistantPath:" + PersistentPathName());
            //Debug.Log("qrp - TempPath      :" + TempPathName());
        }
        public static bool EnsureExistenceOfDirectory(string fname)
        {
            var ok = true;
            try
            {
                FileInfo fileInfo = new FileInfo(fname);
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
        public string TempPathName()
        {
            var tpn = Application.temporaryCachePath + "/" + pathName;
            return tpn;
        }
        public string PersistentPathName()
        {
            var ppn = Application.persistentDataPath + "/" + pathName;
            return ppn;
        }
        public bool Exists()
        {
            return exists;
        }
        public Texture2D GetTex()
        {
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
            Load();
        }
        void Load()
        {
            switch (qresType)
            {
                case QresType.BitmapFile:
                    {
                        FindAndLoadBitmap();
                        break;
                    }
                case QresType.CsvFile:
                    {
                        FindAndLoadCsv();
                        break;
                    }
            }
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
            if (qresType != QresType.BitmapFile)
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
            var ppFllName = PersistentPathName() + fileName;
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



        void FindAndLoadCsv()
        {
            exists = false;
            if (qresType != QresType.CsvFile)
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
            var ppFllName = PersistentPathName() + fileName;
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