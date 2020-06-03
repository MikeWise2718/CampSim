using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#if !FAKEPLAYERPREFS
using UnityEngine;
#endif

namespace UxUtils
{
#if FAKEPLAYERPREFS
    public class PlayerPrefs
    {
        static Dictionary<string, string> valdict = new Dictionary<string, string>();

        //public static void SetupScenario(string scenename)
        //{

        //}
        public static void DumpAll()
        {
            Console.WriteLine("PlayPrefs has " + valdict.Count + " entries");
            foreach (var v in valdict.Keys)
            {
                Console.WriteLine("   " + v + " -> " + valdict[v]);
            }
        }
        public static void DeleteAll()
        {
            valdict = new Dictionary<string, string>();
        }
        public static bool HasKey(string keyname)
        {
            return valdict.ContainsKey(keyname);
        }
        public static void DeleteKey(string keyname)
        {
            if (HasKey(keyname))
            {
                valdict.Remove(keyname);
            }
        }

        public static string GetString(string keyname, string defaultval)
        {
            var rv = defaultval;
            if (HasKey(keyname))
            {
                rv = valdict[keyname];
            }
            return rv;
        }
        public static float GetFloat(string keyname, float defaultval)
        {
            var rv = defaultval;
            if (HasKey(keyname))
            {
                var s = valdict[keyname];
                float.TryParse(s, out rv);
            }
            return rv;
        }
        public static int GetInt(string keyname, int defaultval)
        {
            var rv = defaultval;
            if (HasKey(keyname))
            {
                var s = valdict[keyname];
                int.TryParse(s, out rv);
            }
            return rv;
        }
        public static void Save()
        {
            // save preferences to disk?
        }
        public static float GetFloat(string keyname) { return GetFloat(keyname, 0); }
        public static int GetInt(string keyname) { return GetInt(keyname, 0); }
        public static string GetString(string keyname) { return GetString(keyname, ""); }
        public static void SetFloat(string keyname, float f) { valdict[keyname] = f.ToString(); }
        public static void SetInt(string keyname, int i) { valdict[keyname] = i.ToString(); }
        public static void SetString(string keyname, string s) { valdict[keyname] = s; }

    }
#endif 

    // Helper classes that saves settings
    public class UxSettingsMan
    {
        static Dictionary<string, int> countdict = new Dictionary<string, int>();
        static Dictionary<string, string> typedict = new Dictionary<string, string>();
        static string _curscenario = "";
        public static void SetScenario(string scenario)
        {
            //Debug.Log("UxSettingsMan-SetScenario: " + scenario);
            _curscenario = scenario;
        }
        public static string GetScenario()
        {
            return _curscenario;
        }
        public static void Clear()
        {
            _curscenario = "";
            countdict = new Dictionary<string, int>();
            typedict = new Dictionary<string, string>();
            PlayerPrefs.DeleteAll();
        }
        public static bool IsRootKey(string keyname)
        {
            // rootkeys don't get a scenario prefix
            var rv = keyname.Length>0 && keyname[0]=='/';
            return rv;
        }

        public static string ScenarioKey(string keyname)
        {
            var rv = keyname;
            if (IsRootKey(keyname))
            {
                return keyname;
            }
            else
            {
                return GetScenario() + "/" + keyname;
            }
        }
        public static void Add(string keyname, string typename)
        {
            if (!countdict.ContainsKey(keyname))
            {
                countdict.Add(keyname, 0);
                typedict.Add(keyname, typename);
                return;
            }
            countdict[keyname]++;
        }
        public static T TryParse<T>(string inValue)
        {
            System.ComponentModel.TypeConverter converter = System.ComponentModel.TypeDescriptor.GetConverter(typeof(T));

            return (T)converter.ConvertFromString(null, System.Globalization.CultureInfo.InvariantCulture, inValue);
        }
        public static T TryParseAlt<T>(T inVariable, string inValue)
        {
            switch (Type.GetTypeCode(inVariable.GetType()))
            {
                case TypeCode.Int32:
                    inVariable = (T)(object)Convert.ToInt32(inValue);
                    break;
                case TypeCode.String:
                    inVariable = (T)(object)inValue;
                    break;
                case TypeCode.Single:
                    inVariable = (T)(object)Convert.ToSingle(inValue);
                    break;

                default:
                    throw new Exception("Blow up in fantastic ways!");
            }
            return inVariable;
        }
    }
    [System.Serializable]
    public class UxSetting<T>
    {
        [SerializeField]
        public T val;
        public T inival;
        [SerializeField]
        public string keyname;
        [SerializeField]
        string typename;
        bool valueRetrievedFromPersistentSTore = false;
        public bool ValueRetrievedFromPersistentStore()
        {
            return valueRetrievedFromPersistentSTore;
        }
        public UxSetting(string keyname, T inival)
        {
            this.keyname = keyname;
            GetTypeName();
            UxSettingsMan.Add(keyname, typename);
            this.inival = inival;
            val = inival;
        }
        private void GetTypeName()
        {
            if (val == null)
            {
                this.typename = "".GetType().ToString();
            }
            else
            {
                this.typename = val.GetType().ToString();
            }
        }
        public void Save()
        {
            var skeyname = UxSettingsMan.ScenarioKey(keyname);
            PlayerPrefs.SetString(skeyname, val.ToString());
        }

        public T Retrieve()
        {
            var skeyname = UxSettingsMan.ScenarioKey(keyname);
            var s = PlayerPrefs.GetString(skeyname);
            if (String.IsNullOrEmpty(s))
            {
                valueRetrievedFromPersistentSTore = false;
                val = inival;
                Save(); // it must have been the first time we tried to retrive it
                return val;
            }
            valueRetrievedFromPersistentSTore = true;
            T rv1 = UxSettingsMan.TryParse<T>(s);
            //T rv2 = UxSettingsMan.TryParseAlt<T>(val,s);
            return rv1;
        }
        public T GetInitial()
        {
            var rv1 = Retrieve();
            val = rv1;
            return rv1;
        }
        public T GetInitial(T defval)
        {
            var rv = Retrieve();
            if (!ValueRetrievedFromPersistentStore())
            {
                SetAndSave(defval);
                return defval;
            }
            else
            {
                val = rv;
                return rv;
            }
        }
        public bool Set(T sval)
        {
            var oval = val;
            val = sval;
            return !oval.Equals(val);
        }
        public bool SetAndSave(T sval)
        {
            var oval = val;
            val = sval;
            var chg = !oval.Equals(val);
            if (chg)
            {
                Save();
            }
            return chg;
        }
        public T Get()
        {
            return val;
        }
    }
    [System.Serializable]
    public class UxSettingBool : UxSetting<bool>
    {
        public UxSettingBool(string keyname, bool inival): base(keyname, inival)
        {
            
        }
    }

    [System.Serializable]
    public class UxEnumSetting<TE> where TE : struct
    {
        [SerializeField]
        TE val;
        [SerializeField]
        List<string> options;
        string typename;
        [SerializeField]
        string keyname;
        bool valueRetrievedFromPersistentStore=false;
        public bool ValueRetrievedFromPersistentStore()
        {
            return valueRetrievedFromPersistentStore;
        }
        public UxEnumSetting(string keyname, TE inival)
        {
            options = new List<string>(System.Enum.GetNames(typeof(TE)));
            this.keyname = keyname;
            this.typename = val.GetType().ToString();
            UxSettingsMan.Add(keyname, typename);
            val = inival;
            //val = Retrieve();
        }
        public List<string> GetOptionsAsList()
        {
            return options;
        }
        public string GetOptionsAsString()
        {
            var listoptions = GetOptionsAsList();
            string options = string.Join(",", listoptions);
            return options;
        }
        private TE TranslateVal(string sval)
        {
            TE enumval;
            System.Enum.TryParse<TE>(sval, true, out enumval);
            return enumval;
        }
        public TE Translate(string sval)
        {
            return TranslateVal(sval);
        }
        public void Save()
        {
            var skeyname = UxSettingsMan.ScenarioKey(keyname);
            Debug.Log("UxEnumSettings - saving " + skeyname + " to val "+val);
            PlayerPrefs.SetString(skeyname, val.ToString());
        }

        public TE Retrieve()
        {
            var skeyname = UxSettingsMan.ScenarioKey(keyname);
            var s = PlayerPrefs.GetString(skeyname);
            if (String.IsNullOrEmpty(s))
            {
                valueRetrievedFromPersistentStore = false;
                //Debug.Log(skeyname + " not found so retrieved " + val);
                Save(); // it must have been the first time we tried to retrive it
                return val;
            }
            valueRetrievedFromPersistentStore = true;
            TE rv = UxSettingsMan.TryParse<TE>(s);
            //Debug.Log(skeyname + " found - retrieved " + rv);
            return rv;
        }
        public TE GetInitial()
        {
            //Debug.Log("GetInitial for " + keyname);
            var rv1 = Retrieve();
            val = rv1;
            return rv1;
        }
        public TE GetInitial(TE defval)
        {
            var rv = Retrieve();
            if (!ValueRetrievedFromPersistentStore())
            {
                SetAndSave(defval);
                return defval;
            }
            else
            {
                val = rv;
                return rv;
            }
        }
        public bool Set(TE nval)
        {
            var oval = val;
            val = nval;
            return !val.Equals(oval); 
        }
        public bool Set(string sval)
        {
            var oval = val;
            val = TranslateVal(sval);
            return !val.Equals(oval);
        }
        public bool SetAndSave(TE sval)
        {
            var oval = val;
            val = sval;
            Save();
            return !val.Equals(oval);
        }
        public bool SetAndSave(string sval)
        {
            var oval = val;
            val = TranslateVal(sval);
            Save();
            return !val.Equals(oval);
        }
        public TE Get()
        {
            return val;
        }
    }

}
