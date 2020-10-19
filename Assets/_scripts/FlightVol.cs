using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Aiskwk.SimpleJSON;
using System;

namespace CampusSimulator
{
    [Serializable]
    public class FvCoord
    {
        double lat;
        double lng;
        double alt;
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
        public string fill;
        List<FvCoord> fvcoords;
        public List<string> coords;

        public FvFeatture(string fvfname,string id,string fill)
        {
            this.fvfname = fvfname;
            this.id = id;
            this.fill = fill;
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
            var str = ReadResourceAsString(fname);

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
                var desc = props["description"];
                var typ = geometry["type"];
                var coords = geometry["coordinates"][0];
                var ff = new FvFeatture(fvfname, id, fill);
                foreach(var c in coords)
                {
                    var cv = c.Value;
                    double lat = cv[0];
                    double lng = cv[1];
                    double alt = cv[2];
                    //var ok1 = double.TryParse(c[0], out lat);
                    ff.AddCoord(lat,lng,alt);
                }
                Debug.Log($"   Found id:{id} props:{props.Count} geometry.type:{typ} geometry.coords:{coords.Count} ");
                Debug.Log($"   name:{name} fill:{fill} desc:{desc}");
                features.Add(ff);
            }
        }

        public List<string> ReadResource(string pathname)
        {
            //var idx = pathname.IndexOf(".geojson");
            //if (idx > 0)
            //{
            //    pathname = pathname.Remove(idx);
            //}
            var asset = Resources.Load<TextAsset>(pathname);
            return TextAssetToList(asset);
        }

        public string ReadResourceAsString(string pathname)
        {
            var idx = pathname.IndexOf(".geojson");
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
        public static List<string> TextAssetToList(TextAsset ta)
        {
            var listToReturn = new List<string>();
            var arrayString = ta.text.Split('\n');
            foreach (var line in arrayString)
            {
                listToReturn.Add(line);
            }
            return listToReturn;
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}