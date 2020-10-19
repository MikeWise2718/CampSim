using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Aiskwk.SimpleJSON;
using System;
using Aiskwk.Map;

namespace CampusSimulator
{
    [Serializable]
    public class FvCoord
    {
        public double lat;
        public double lng;
        public double alt;
        public FvCoord(double lat,double lng,double alt)
        {
            this.lat = lat;
            this.lng = lng;
            this.alt = alt;
        }
        public override string ToString()
        {
            var s = $"{lat:f6} {lng:f6} {alt}";
            return s;
        }
    }

    [Serializable]
    public class FvFeatture
    {
        public string fvfname;
        public string id;
        public string desc;
        public string typ;
        public string fill;
        public string fill_opacity;
        public List<FvCoord> fvcoords;
        public List<string> coords;

        public FvFeatture(string fvfname,string id,string desc,string typ,string fill, string fill_opacity)
        {
            this.fvfname = fvfname;
            this.id = id;
            this.fill = fill;
            this.typ = typ;
            this.desc = desc;
            this.fill_opacity = fill_opacity;
            fvcoords = new List<FvCoord>();
            coords = new List<string>();
        }
        public void AddCoord(double lat,double lng,double alt)
        {
            var fvcrd = new FvCoord(lat, lng, alt);
            fvcoords.Add(fvcrd);
            coords.Add(fvcrd.ToString());
        }
    }
    public class FlightVol : MonoBehaviour
    {
        FlightVolMan fm;
        string fname;

        public List<FvFeatture> features;
        public void Init(FlightVolMan fm, string fname)
        {
            this.fm = fm;
            this.fname = fname;
            this.features = new List<FvFeatture>();
            var str = ReadResourceAsString(this.fname);

            var json = JSON.Parse(str);

            var jsonfeatures = json["features"].AsArray;
            Debug.Log($"Found {jsonfeatures.Count} features");
            foreach (var feature in jsonfeatures)
            {
                var sk = feature.Key.ToString();
                var vd = feature.Value;
                //Debug.Log($"feature.Key:{sk} Value:{feature.Value}");
                var id = vd["id"];
                var geometry = vd["geometry"];
                var props = vd["properties"];
                var fvfname = props["name"];
                var fill = props["fill"];
                var fill_opacity = props["fill-opacity"];
                var desc = props["description"];
                var typ = geometry["type"];
                var coords = geometry["coordinates"][0];
                var ff = new FvFeatture(fvfname, id, desc,typ, fill, fill_opacity);
                foreach(var c in coords)
                {
                    var cv = c.Value;
                    double lat = cv[0];
                    double lng = cv[1];
                    double alt = cv[2];
                    //var ok1 = double.TryParse(c[0], out lat);
                    ff.AddCoord(lat,lng,alt);
                }
                //Debug.Log($"   Found id:{id} props:{props.Count} geometry.type:{typ} geometry.coords:{coords.Count} ");
                //Debug.Log($"   name:{name} fill:{fill} desc:{desc}");
                features.Add(ff);
            }
        }

        public string ReadResourceAsString(string pathname)
        {
            var idx = pathname.IndexOf(".geojson");// only reads json, csv, txt and a few others - without specifying
            if (idx > 0)
            {
                pathname = pathname.Remove(idx);
            }
            var asset = Resources.Load<TextAsset>(pathname);
            if (asset==null)
            {
                fm.sman.LggError($"Could not load asset:{pathname}");
                return null;
            }
            return asset.text;
        }
        GameObject fvgo = null;
        public void CreateGos()
        {
            var llm = fm.sman.mpman.GetLatLongMap();
            var fname = $"fv-{name}";
            fvgo = new GameObject(fname);
            foreach (var f in features)
            {
                var n = f.fvcoords.Count;
                var pt = Vector3.zero;
                var pt0 = pt;
                for(int i=0; i<n; i++)
                {
                    var c = f.fvcoords[i];
                    pt = llm.xycoord(c.lat, c.lng,(float) c.alt);
                    var cname = $"fv-c{i}";
                    var cgo = qut.CreateMarkerSphere(cname, pt,size:600);
                    cgo.transform.parent = fvgo.transform;
                    if (i>0)
                    {
                        var pname = $"fv-p{i-1}:{i}";
                        var pip = qut.CreatePipe( pname, pt0, pt, size: 300  );
                        pip.transform.parent = fvgo.transform;
                    }
                    pt0 = pt;
                }
            }
            fvgo.transform.parent = this.transform;

        }
        public void DeleteGos()
        {
            if (fvgo != null)
            {
                fm.sman.Lgg("Deleting fvgo");
                Destroy(fvgo);
            }
            fvgo = null;
        }

        public void Delete()
        {
            DeleteGos();
            features = new List<FvFeatture>();
        }

            // Start is called before the first frame update
            //void Start()
            //{

            //}

            //// Update is called once per frame
            //void Update()
            //{

            //}
        }
    }