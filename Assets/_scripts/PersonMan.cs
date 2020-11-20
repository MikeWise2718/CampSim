using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Analytics;
using UxUtils;

namespace CampusSimulator
{
    public enum PersonAniStateE { walking, standing };

    public class PersonMan : MonoBehaviour
    {

        Dictionary<string, Person> persnamelookup = new Dictionary<string, Person>();
        List<string> persnames = new List<string>(); // maintain a sorted list of Persons with destinations
        List<string> wtd_persnames = new List<string>(); // maintain a sorted weighted list of Persons with destinations

        public enum GenderE { male, female, other };// this is for the appearance avatar
        public enum empStatusE { Security, FullTimeEmp, Contractor, Visitor, Unknown };
        //public string [] empStatusStr = new  string [] { "Contractor", "FullTimeEmp", "Visitor","Security", "Unknown" };
        //public float [] empStatusWt = new float []{ 60, 10, 10, 5, 5,  };

        public SceneMan sman = null;

        public int npers = 0;

        public enum PrsModeE { none, full };
        public UxEnumSetting<PrsModeE> bldMode = new UxEnumSetting<PrsModeE>("PersonMode",PrsModeE.full);

        public void ToggleBld()
        {
            if (bldMode.Get() == PrsModeE.full)
            {
                bldMode.Set(PrsModeE.none);
            }
            else
            {
                bldMode.Set(PrsModeE.full);
            }
        }
        public void ModelInitialize(SceneSelE newregion)
        {
            DelPersons(); // this wipes out everyone that was created in the
        }
        //public Person MakePerson(GenderE gender, string persname, string avname, empStatusE empstatus, bool hasHololens = false, bool flagged = false)
        List<string> mtten_presets = new List<string>()
        {
            "m|Jane Doe Found|Girl03|unknown|nothing",
            "m|Jane Doe LastSeen|Girl03|unknown|nothing",
        };
        GenderE GetGender(string s)
        {
            switch (s[0])
            {
                case 'f': return GenderE.female;
                case 'm': return GenderE.male;
                default: return GenderE.other;
            }
        }
        empStatusE GetEmpStat(string s)
        {
            switch (s[0])
            {
                case 'f': return empStatusE.FullTimeEmp;
                case 'c': return empStatusE.Contractor;
                case 's': return empStatusE.Security;
                case 'v': return empStatusE.Visitor;
                default: return empStatusE.Unknown;
            }
        }
        void AddPresetPeople(List<string> presetPeople)
        {
            foreach(var s in presetPeople)
            {
                var sar = s.Split('|');
                if (sar.Length<5)
                {
                    Debug.LogError($"bad personspect:{s}");
                    continue;
                }
                var g = GetGender(sar[0]);
                var emp = GetEmpStat(sar[3]);
                var personname = sar[1];
                var avname = sar[2];
                var p = MakePerson(g, personname, "person", avname, emp,hasHololens:false);
            }
        }
        public void ModelBuild()
        {
            var presetPeople = new List<string>();
            switch (sman.curscene)
            {
                case SceneSelE.MsftRedwest:
                case SceneSelE.MsftCoreCampus:
                case SceneSelE.MsftB19focused:
                case SceneSelE.MsftB33focused:
                case SceneSelE.MsftB121focused:
                    break;
                case SceneSelE.TeneriffeMtn:
                    //presetPeople = mtten_presets;
                    break;
                default:
                case SceneSelE.MsftSmall:
                case SceneSelE.None:
                    break;
            }
            AddPresetPeople(presetPeople);
        }
        readonly string[] maleFirstNames =
        {
            "Mike", "Dave","John", "Steve", "Jim","Bruce","Phil","Jake","Mark","Liam","Bryan","Neil","Neils","Tony",
            "Alex","Brett","Paul","Bill","Chris","Jacob","Oliver","Gabriel","Detlev","Fritz","Hans","Stefan","Lars","Sven","Carsten",
            "Aarav", "Arjun","Vihann", "Manish", "Rahul","Ravi","Ramesh","Rakesh","Vivaan","Arjun","Sai","Muhammad","Aryan","Vijay","Vinod","Deepak","Gaurav",
            "Spyros","Hans","Rene","Wim","Anders","Tyson","Rimes","Todd","Alexey","Max","Satya","Dmitry","Vladimir","Ivan","Mikhail",
            "Liang","Fang","Qi","Peng","Tao","Wei","Ying","Bo","Chi","Fu",
            "Simon","Judson"
        };
        readonly string[] femaleFirstNames =
        {
            "Alice","Tay","Jackie","Holly","Cathy","Joana","Julia","Halle","Linda","Emily","Louise","Ema","Olivia","Cathy","Zoe","Raquel","Anne","Sally","Ivana",
            "Myra","Aditi","Sarah","Angi","Vanya","Sai","Ira","Zara","Clair","Nicole","Valerie","Sally","Vera","Katy","Elizabeth","Mary","Kate","Anastasia",
            "Jie","Ting","Wenyu","Xaoice","Rina","Shay","Asahi","Yin","Ava","Thuy","Fan","Li","Ting","Huan",
            "Ai","Mei","Yuka","Yui","Rio","Rin","Hina","Mao","Haruka","Saki",
            "Suzanne","Hillary","Kamala","Anke","Francoise","Angela","Olga","Vera","Tanya","Uschi","Florance","Deb","Kevyn",
        };
        readonly string[] lastNames =
        {
            "Smith","Jones","Johnson","Miller","Brown","Wise","Wilson","Wilcox","Jordan","Kerr","Cooper","Williams","Welsch",
            "Singh","Agarwal","Patel","Anand","Chopra","Kumar","Garcia","Nguyen","Siva",
            "Lee","Xiao","Chen","Feng","Xian","Zhang","Cai","Wang","Li","Zhao","Zhou","Wu","Le","Smirnov","Egger",
            "Haneda","Tanaka","Park","Nakamura","Watanabe","Ito","Yamamoto","Kobayashi","Saito","Takahashi","Suzuki",
            "Weis","Larsen","Santos","Storch","Becker","Visser","Remus","Carnot","Blanc","Martin","Laren",
            "Plank","Bohr","Ross","Gates","Balmer","Nadella","Ray","Althoff","Mortimer","Cupp"
        };
        public string GenRandomName(GenderE gender)
        {
            int maxiter = 10;// if we can't get a unique name after 10 tries give up :)
            int iter = 0;
            while (iter < maxiter)
            {
                var genderlist = (gender == GenderE.male ? maleFirstNames : femaleFirstNames);
                var fname = GraphAlgos.GraphUtil.GetRanListEntry(genderlist,"popbld");
                var lname = GraphAlgos.GraphUtil.GetRanListEntry(lastNames, "popbld");
                var name = fname + " " + lname;
                if (!persnamelookup.ContainsKey(name))
                {
                    return name;
                }
            }
            return "could not find free name";
        }
        public string GenRandomDroneName(GenderE gender,string dispavname)
        {
            int maxiter = 10;// if we can't get a unique name after 10 tries give up :)
            int iter = 0;
            while (iter < maxiter)
            {
                var genderlist = (gender == GenderE.male ? maleFirstNames : femaleFirstNames);
                var fname = dispavname;
                var lname = GraphAlgos.GraphUtil.GetRanListEntry(genderlist, "popbld");
                var name = fname + "-" + lname;
                if (!persnamelookup.ContainsKey(name))
                {
                    return name;
                }
            }
            return "could not find free name";
        }
        static string[] idlescripts =
        {
            "PersonIdle",
            "Talking4",
            "Talking5",
            "Agreeing",
            "CrazyGesture",
            "IdleHappy",
            "IdleSad",
            "IdleNeutral",
            "IdleUnarmed",
            "Angry",
        };
        static string[] cellidlescripts =
        {
           "Cellphone1",
           "Cellphone2",
  //          "Cellphone3", (left handed)
        };

        public static void UnsyncAnimation(Animator animator, string clipname, string caller)
        {
            if (animator == null) return;
            clipname = clipname.ToLower();
            var unsync = true;
            if (caller == "BirdCtrl") unsync = false;
            if (unsync)
            {
                animator.ForceStateNormalizedTime(GraphAlgos.GraphUtil.GetRanFloat(0, 1));
                //animator.Play(clipname, 0, GraphAlgos.GraphUtil.GetRanFloat(0, 1));
                // animmator.Play causes error message "State cound not be found" - 
                // seems to require that all our animation clips are named internally consistently
            }
        }
        public static string GetIdleScript(string avatarName)
        {
            string rv = "PersonIdle";
            if (avatarName == "Girl001" || avatarName == "Girl002" || avatarName == "Girl012" || 
                avatarName == "Businessman006" || avatarName == "Man001" || avatarName == "Man002" ||
                avatarName == "Businesswoman006")
            {
                rv = GraphAlgos.GraphUtil.GetRanListEntry(cellidlescripts);
            }
            else
            {
                rv = GraphAlgos.GraphUtil.GetRanListEntry(idlescripts);
            }
            return rv;
        }

        public List<Person> GetPeopleInBuilding(Building bld)
        {
            var rv = new List<Person>();
            foreach(var per in persnamelookup.Values)
            {
                if (per.InBuilding(bld.name))
                {
                    rv.Add(per);
                }
            }
            Debug.Log("There are " + rv.Count + " people in bld " + bld.name);
            return rv;
        }



        public List<Person> GetPeopleNotTravelingInBuilding(Building bld)
        {
            var rv = new List<Person>();
            foreach (var per in persnamelookup.Values)
            {
                if (per.NotTravelingInBuilding(bld.name))
                {
                    rv.Add(per);
                }
            }
            //Debug.Log("There are " + rv.Count + " non-traveling people in bld " + bld.name);
            return rv;
        }

        public GenderE GetRandomGender()
        {
            if (GraphAlgos.GraphUtil.FlipCoin("popbld")) return GenderE.female;
            return GenderE.male;
        }
        string[] empStatusStr = new string[] { "FullTimeEmp", "Contractor", "Visitor", "Security", "Unknown" };
        float[] empStatusWt = new float[] { 70, 20, 10, 5, 5, };
        public empStatusE GetRandomEmpStatus()
        {
            //Debug.Log(empStatusWt.ToString());

            var estr = GraphAlgos.GraphUtil.GetRanListEntry(empStatusStr, empStatusWt, "popbld");
            var rv = UxUtils.UxSettingsMan.TryParse<empStatusE>(estr);
            return rv;
        }
        public void AddPersonToBuildingAtNode(GenderE gender, string roomname,string nodename,string personname,string avatarname, empStatusE empstat,
                                              string idlescript,bool freeToTravel,float homeRotate,bool hasHololens=false,bool hasCamera=false,bool flagged=false )
        {
            var broom = sman.bdman.GetBroom(roomname);
            var bld = broom.bld;

            var pers = MakePerson(gender, personname, "Person", avatarname, empstat,hasHololens);
            pers.AssignHomeLocation(bld.name, broom.name, nodename, homeRoomPlacefixed: true,homeRotate:homeRotate);
            pers.idleScript = idlescript;
            if (!freeToTravel)
            {
                pers.personState = PersonStateE.fixedPerson;
            }
            pers.hasCamera = hasCamera;
            pers.flagged = true;
            broom.Occupy(pers);
        }
        public void b19idchange(string pname,string estr, bool flagged=false)
        {
            var pers = GetPerson(pname);
            if (!pers)
            {
                Debug.Log("b19idchange unknown person name:" + pname);
                return;
            }
            var empstat = UxUtils.UxSettingsMan.TryParse<empStatusE>(estr);
            pers.personName = pname;
            pers.empStatus = empstat;
            pers.flagged = flagged;
        }

        public string GetRandomAvatarName(GenderE gender)
        {
            var rv = "";
            if (gender==GenderE.female)
            {
                var idx = (1 + GraphAlgos.GraphUtil.GetRanInt(sman.maxLegacyAvatarGen, "popbld"));
                if (idx <= 10)
                {
                    rv = "Girl" + idx.ToString("D3");
                }
                else if (idx <= 20)
                {
                    var nidx = idx - 10;
                    rv = "Businesswoman" + nidx.ToString("D3");
                } else
                {
                    var nidx = 11 + (idx % 2);
                    rv = "Girl" + nidx.ToString("D3");
                }
            }
            else
            {
                var idx = (1 + GraphAlgos.GraphUtil.GetRanInt(20,"popbld"));
                if (idx <= 10)
                {
                    rv = "Man" + idx.ToString("D3");
                }
                else if (idx <= 20)
                {
                    idx -= 10;
                    rv = "Businessman" + idx.ToString("D3");
                }
            }
            return rv;
        }
        public void EverybodyDance(bool dodance)
        {
            Debug.Log("Everybody Dance " + dodance);
            if (dodance != _dancing)
            {
                _dancing = dodance;
                foreach (var pers in persnamelookup.Values)
                {
                    if (pers.perstate == PersonAniStateE.standing)
                    {
                        var acomp = pers.persGo.gameObject.GetComponentInChildren<Animator>();
                        var script = pers.danceScript;
                        if (!_dancing) script = pers.idleScript;
                        acomp.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Animations/"+script);
                        PersonMan.UnsyncAnimation(acomp, script, "EverybodyDance");
                    }
                }
            }

        }
        public void EverybodyDance()
        {
            EverybodyDance(!_dancing);

        }
        public bool _dancing = false;

        public Person MakePerson(GenderE gender, string persname, string avtype, string avname, empStatusE empstatus, bool hasHololens = false, bool flagged = false, bool isdronelike = false)
        {
            var rv = MakePerson(gender, persname, avtype, avname, 1, Vector3.zero, Vector3.zero,empstatus:empstatus, hasHololens: hasHololens, flagged: flagged, isdronelike: isdronelike);
            return rv;
        }

        public Person MakePerson(GenderE gender, string persname, string avtype, string avname, float avaska, Vector3 avarot, Vector3 avatran, empStatusE empstatus, bool hasHololens = false, bool flagged = false, bool isdronelike = false)
        {
            var pgo = new GameObject(persname);
            //var ska = sman.stman.scalemodelnumber.Get();
            //var skav = new Vector3(ska, ska, ska);
            //pgo.transform.localScale = skav;
            pgo.transform.position = Vector3.zero;
            pgo.transform.parent = this.transform;
            
            var pers = pgo.AddComponent<Person>();
            pers.AddPrsDetails(this, gender, persname,avtype, avname,empstatus,hasHololens,ska: avaska, avarot,avatran);
            if (isdronelike)
            {
                pers.avatarNameMoving = pers.avatarName + "spinning";
                pers.scale *= sman.trman.dronescalemodelnumber.Get();
            }
            else
            {
                pers.scale *= sman.trman.peoplescalemodelnumber.Get();
            }
            AddPersonToCollection(pers); /// has to be afterwards because of the sorted names for journeys
            pers.idleScript = PersonMan.GetIdleScript(pers.avatarName);
            pers.walkScript = "PersonRunning";
            pers.danceScript = "Samba Dancing";
            pers.flagged = flagged;
            pers.isdronelike = isdronelike;
            return pers;
        }
        public Person MakeRandomPerson()
        {
            var gender = GetRandomGender();
            var persname = GenRandomName(gender);
            var avname = GetRandomAvatarName(gender);
            var flagged = GraphAlgos.GraphUtil.FlipBiasedCoin(0.25f, "popbld");

            var empstatus = GetRandomEmpStatus();
            //if (persname == "Phil Nakamura")
            //{
            //    empstatus = empStatusE.FullTimeEmp;
            //    //Debug.Log(persname +" is a "+empstatus);
            //}
            var pers =  MakePerson(gender, persname, "Person", avname, empstatus, flagged:flagged);
            return pers;

            //var pgo = new GameObject(persname);
            //pgo.transform.position = Vector3.zero;
            //pgo.transform.parent = this.transform;
            //var pers = pgo.AddComponent<Person>();
            //pers.AddPrsDetails(this,gender,persname,avname,empstatus);
            //AddPersonToCollection(pers); /// has to be afterwards because of the sorted names for journeys
            //pers.idleScript = PersonMan.GetIdleScript(pers.avatarName);
            //pers.walkScript = "PersonRunning";
            //pers.danceScript = "SambaDancing";
            //return pers;
        }
        public Person MakeRandomPersonDrone(DroneSelectionMode dsm,DroneSelectionNumber dsn)
        {
            var gender = GetRandomGender();
            var (dispavname,avname,avska,avrot,avtran) = sman.drman.GetRandomAvatarDroneName(dsm,dsn);
            var dronename = GenRandomDroneName(gender,dispavname);
            var flagged = GraphAlgos.GraphUtil.FlipBiasedCoin(0.25f, "popbld");

            var empstatus = empStatusE.FullTimeEmp;
            //if (persname == "Phil Nakamura")
            //{
            //    empstatus = empStatusE.FullTimeEmp;
            //    //Debug.Log(persname +" is a "+empstatus);
            //}
            //var pers = MakePerson(gender, persname, "Person",  avname, empstatus, flagged: flagged);
            var pers = MakePerson(gender, dronename, "Obj3d", avname,  avaska:avska, avarot:avrot,avatran:avtran, empstatus, flagged: flagged,isdronelike:true );
            return pers;

            //var pgo = new GameObject(persname);
            //pgo.transform.position = Vector3.zero;
            //pgo.transform.parent = this.transform;
            //var pers = pgo.AddComponent<Person>();
            //pers.AddPrsDetails(this,gender,persname,avname,empstatus);
            //AddPersonToCollection(pers); /// has to be afterwards because of the sorted names for journeys
            //pers.idleScript = PersonMan.GetIdleScript(pers.avatarName);
            //pers.walkScript = "PersonRunning";
            //pers.danceScript = "SambaDancing";
            //return pers;
        }
        public List<Person> MakeRandomPerson(int n)
        {
            Debug.Log($"MakeRandomPerson n:{n}");
            var rv = new List<Person>();
            for (int i = 0; i < n; i++)
            {
                var pers = MakeRandomPerson();
                Debug.Log($"Made person {pers.personName}");
                rv.Add(pers);
            }
            Debug.Log("MRP count:" + rv.Count);
            return rv;
        }
        public void DelPersons()
        {
          //  Debug.Log(#"DelPersons called");
            var namelist = new List<string>(persnamelookup.Keys);
            namelist.ForEach(pname => DelPerson(pname));
        }
        public void DelPerson(string pname)
        {
            //Debug.Log($"Deleting Person {pname}");
            //var go = GameObject.Find(name);

            var pers = persnamelookup[pname];
            npers--;
            persnamelookup.Remove(pname);
            pers.DeleteGos();
            Destroy(pers.gameObject);
        }
        public Person GetPerson(string pname)
        {
            if (!persnamelookup.ContainsKey(pname))
            {
                Debug.LogWarning($"Bad Person lookup:{pname}");
                return null;
            }
            return persnamelookup[pname];
        }
        public void AddPersonToCollection(Person Person)
        {
            if (persnamelookup.ContainsKey(Person.name))
            {
                Debug.LogWarning($"Tried to add duplicate Person:{Person.name}");
                return;
            }
            persnamelookup[Person.name] = Person;
            npers++;
            //Debug.Log("Added bld " + Person.name);
        }


        public List<string> GetPersonNameList()
        {
            return persnames;
        }
        public List<Person> GetPersonList()
        {
            return persnamelookup.Values.ToList<Person>();
        }

        public int GetPersonCount()
        {
            return persnamelookup.Count;
        }
        public bool IsPersonName(string pname)
        {
            var rv =  persnamelookup.ContainsKey(pname);
            return rv;
        }

        public void DeleteGos()
        {
            foreach (var bname in persnamelookup.Keys)
            {
                persnamelookup[bname].DeleteGos();
            }
        }
        public void CreateGos()
        {
            foreach (var bname in persnamelookup.Keys)
            {
                persnamelookup[bname].CreateGos();
            }
        }
        public void RefreshGos()
        {
            DeleteGos();
            CreateGos();
        }
        // Use this for initialization
        //void Start()
        //{
        //}
        public bool everybodyDance = false;
        // Update is called once per frame
        void Update()
        {
            if (everybodyDance)
            {
                EverybodyDance(!_dancing);
                everybodyDance = false;
            }
        }
    }
}