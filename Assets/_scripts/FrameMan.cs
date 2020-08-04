using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using GraphAlgos;
using UxUtils;

namespace CampusSimulator
{
    public enum LableClassE {  person, vehicle };
    public class LabelEntry
    {
        public LableClassE thing;
        public string model;
        public string id;
        public string id2;
        public string debstr;
        public Rect rect;
        public Vector3 pt;
        public Vector3 rot;
        public Vector3 vel;
        public string locname;
        public string comment;
        public Color color;
        public float width;
        public LabelEntry(LableClassE thing, string model, string id, string id2, string debstr, Rect rect, Vector3 pt,Vector3 rot,Vector3 vel, string locname, string comment, Color color, float width)
        {
            this.thing = thing;
            this.model = model;
            this.id = id;
            this.id2 = id2;
            this.rect = rect;
            this.pt = pt;
            this.rot = rot;
            this.vel = vel;
            this.locname = locname;
            this.comment = comment;
            this.color = color;
            this.width = width;
        }
        public LabelEntry(Person person, Rect rect, Vector3 pt, Vector3 rot, Vector3 vel, string locname, string comment, Color color, float width)
        {
            this.thing = LableClassE.person;
            this.model = person.avatarName;
            this.id = person.personName;
            this.id2 = person.empStatus.ToString();
            this.rect = rect;
            this.pt = pt;
            this.rot = rot;
            this.vel = vel;
            this.locname = locname;
            this.comment = comment;
            this.color = color;
            this.width = width;
            this.debstr = person.placeBld + "/" + person.placeNode + "/" + person.placeRoom;

        }
        public LabelEntry(Vehicle vehicle,Rect rect, Vector3 pt, Vector3 rot, Vector3 vel, string locname, string comment, Color color, float width)
        {
            this.thing = LableClassE.vehicle;
            this.model = vehicle.formName;
            this.id = vehicle.vehicleId;
            this.id2 = vehicle.vehicleId;
            this.rect = rect;
            this.pt = pt;
            this.rot = rot;
            this.vel = vel;
            this.locname = locname;
            this.comment = comment;
            this.color = color;
            this.width = width;
            this.debstr = "";
        }
        public string txtmsg()
        {
            var fmt1 = "f1";
            var fmt3 = "f3";
            var msg = thing + "," + model + "," + id + "," +
                        rect.xMin.ToString(fmt1) + "," +
                        rect.yMin.ToString(fmt1) + "," +
                        rect.xMax.ToString(fmt1) + "," +
                        rect.yMax.ToString(fmt1) + "," +
                        pt.x.ToString(fmt3) + "," +
                        pt.y.ToString(fmt3) + "," +
                        pt.z.ToString(fmt3) + "," +
                        rot.x.ToString(fmt3) + "," +
                        rot.y.ToString(fmt3) + "," +
                        rot.z.ToString(fmt3) + "," +
                        vel.x.ToString(fmt3) + "," +
                        vel.y.ToString(fmt3) + "," +
                        vel.z.ToString(fmt3) + "," +
                        locname + "," +
                        comment;
            return msg;
        }
    }

    public class FrameMan : MonoBehaviour
    {
        public SceneMan sman;
        public enum personDetectModeE { none, person, head, face }

        public List<LabelEntry> foundLabelList = new List<LabelEntry>();

        public UxSettingBool frameJourneys = new UxSettingBool("FrameJourneys", true);
        public UxSettingBool frameBuildings = new UxSettingBool("FrameBuildings", true);
        public UxSettingBool frameGarages = new UxSettingBool("FrameGarages", true);
        public UxSettingBool frameZones = new UxSettingBool("FrameZones", true);
        public UxSettingBool showCarRects = new UxSettingBool("FrameShowCarRects", true);
        public UxSettingBool showPersRects = new UxSettingBool("FrameShowPersRects", true);
        public UxSettingBool showHeadRects = new UxSettingBool("FrameShowHEadRects", true);

        public bool useEmpClassColors=true;

        public bool forceFrameAllRooms;
        //public bool showOnlyFlaggedPeople;
        public UxSettingBool detectFte = new UxSettingBool("FrameDetectFte", true);
        public UxSettingBool detectContractor = new UxSettingBool("FrameDetectContractor", true);
        public UxSettingBool detectSecurity = new UxSettingBool("FrameDetectSecurity", true);
        public UxSettingBool detectVisitor = new UxSettingBool("FrameDetectVisitor", true);
        public UxSettingBool detectUnknown = new UxSettingBool("FrameDetectUnknown", true);

        public UxSettingBool visibilityTiedToDetectability = new UxSettingBool("FrameVisibilityTiedToDetectability", true);

        public string fteText = "FullTimeEmp";
        public string contractorText = "Contractor";
        public string securityText = "Security";
        public string visitorText = "Visitor";
        public string unknownText = "Unknown";

        public enum textContentE { name, empstatus,debstr, none };
        //public textContentE topLabelText = textContentE.empstatus;
        //public textContentE botLabelText = textContentE.none;
        public UxEnumSetting<textContentE> topLabelText = new UxEnumSetting<textContentE>("FrameTopTextContent", textContentE.empstatus);
        public UxEnumSetting<textContentE> botLabelText = new UxEnumSetting<textContentE>("FrameBotTextContent", textContentE.empstatus);

        public float maxFrameDist = 20;

        public float rectLineWidth = 1f;

        public void FrameButtonPressed(bool onoff, bool reset)
        {
            Debug.LogWarning($"FBP {sman.curscene} onoff:{onoff} reset:{reset}");
            frameJourneys.SetAndSave(onoff);
            frameBuildings.SetAndSave(onoff);
            frameGarages.SetAndSave(onoff);
            frameZones.SetAndSave(onoff);
            showCarRects.SetAndSave(onoff);
            showPersRects.SetAndSave(onoff);
            showHeadRects.SetAndSave(false);
            //showHeadRects.SetAndSave(false);
            //visibilityTiedToDetectability.SetAndSave(true);
            if (reset)
            {
                //Debug.Log("Reseting detect variables to " + onoff);
                detectFte.SetAndSave(onoff);
                detectContractor.SetAndSave(onoff);
                detectSecurity.SetAndSave(onoff);
                detectVisitor.SetAndSave(onoff);
                detectUnknown.SetAndSave(onoff);
                topLabelText.SetAndSave(textContentE.name);
                botLabelText.SetAndSave(textContentE.empstatus);
            }
        }

        public void AddFoundLabel(Person person, Rect rect, Vector3 pt, Vector3 rot, Vector3 vel, string locname, string comment, Color color, float width)
        {
            var nlab = new LabelEntry(person, rect, pt, rot, vel, locname, comment, color, width);
            foundLabelList.Add(nlab);
        }
        public void AddFoundLabel(Vehicle vehicle, Rect rect, Vector3 pt, Vector3 rot, Vector3 vel, string locname, string comment, Color color, float width)
        {
            var nlab = new LabelEntry(vehicle, rect, pt, rot, vel, locname, comment, color, width);
            foundLabelList.Add(nlab);
        }

        public void AddFoundLabel(LableClassE thing, string model, string id, string id2,string debstr, Rect rect, Vector3 pt,Vector3 rot,Vector3 vel, string locname, string comment, Color color, float width)
        {
            var nlab = new LabelEntry(thing, model, id, id2,debstr, rect,pt,rot,vel,locname, comment, color, width);
            if (thing == LableClassE.person)
            {
                Enum.TryParse<PersonMan.empStatusE>(id2, true, out var stat);
                if (!GetEnabled(stat)) return; // don't add lablel
            }
            foundLabelList.Add(nlab);
        }

        public float savefreqsecs = 5;
        public bool saveContinuouslyOnPlay = false;
        public bool saveLabelListOnce = false;
        public bool saveLabelListContinuously = false;
        public int numLabelListSaves = 0;
        float lastlabelsave = 0;

        public string GetLabelListFileName(string camname)
        {
            lastlabelsave = Time.time;
            //var ncs = numMainCamSaves.ToString("D3");

            var spath = sman.simrundir + sman.labelsdir + camname + "/";
            System.IO.Directory.CreateDirectory(spath);
            var tstmp = GraphAlgos.GraphUtil.LeadZeroFloat(lastlabelsave, 5, 1);
            var fname = spath + camname + "_" + tstmp + ".csv";
            return fname;
        }
        public void SaveLabelList(string camname)
        {
            // https://forum.unity.com/threads/how-to-save-manually-save-a-png-of-a-camera-view.506269/
            //var mcam = Camera.main;
            var mcam = sman.vcman.GetCurrentCamera();
            if (mcam != null)
            {
                //lastlabelsave = Time.time;
                //System.IO.Directory.CreateDirectory(path + name + "/");
                //var fname = path + "/" + camname + "_labellist_" + DateTime.Now.ToString("yyyyMMdd-HHmmss-fff") + ".txt";

                var fname = GetLabelListFileName(camname);

                Debug.Log("Writing " + fname + " lines:" + foundLabelList.Count);
                var ll = new List<string>();
                ll.Add("object,obavatar,obid,frmxmin,frmymin,frmxmax,frmymax,ptx,pty,ptz,rotx,roty,rotz,velx,vely,velz,locname,comment");
                foreach (var flab in foundLabelList)
                {
                    ll.Add(flab.txtmsg());
                }
                System.IO.File.WriteAllLines(fname, ll);
                numLabelListSaves++;
            }
        }

        public void InitializeScene(SceneSelE newregion)
        {
            GetInitials();
        }

        public void GetInitials()
        {
            //Debug.Log($"FrameMan.SetScene setregion:{newregion}");
            visibilityTiedToDetectability.GetInitial(false);
            frameJourneys.GetInitial(false);
            frameBuildings.GetInitial(false);
            frameGarages.GetInitial(false);
            frameZones.GetInitial(false);
            showCarRects.GetInitial(false);
            showPersRects.GetInitial(false);
            showHeadRects.GetInitial(false);
            detectFte.GetInitial(false);
            detectContractor.GetInitial(false);
            detectSecurity.GetInitial(false);
            detectVisitor.GetInitial(false);
            detectUnknown.GetInitial(false);
            topLabelText.GetInitial(textContentE.none);
            botLabelText.GetInitial(textContentE.name);
            //Debug.Log($"FrameMan.SetScene {newregion}- vt2d:{visibilityTiedToDetectability.Get()} valueretrieved:{visibilityTiedToDetectability.ValueRetrievedFromPersistentStore()}");
        }

        public void SetScene(SceneSelE newregion)
        {
        }


            private void LateUpdate()
        {
            foundLabelList = new List<LabelEntry>();
            if (showCarRects.Get())
            {
                CalcGarageFrames();
                CalcJourneyFrames(BirdFormE.car, personDetectModeE.none);
            }
            if (showPersRects.Get())
            {
                CalcZoneFrames(personDetectModeE.person);
                CalcBldFrames(personDetectModeE.person);
                CalcJourneyFrames(BirdFormE.person, personDetectModeE.person);
            }
            if (showHeadRects.Get())
            {
                CalcZoneFrames(personDetectModeE.head);
                CalcBldFrames(personDetectModeE.head);
                CalcJourneyFrames(BirdFormE.person, personDetectModeE.head);
            }
            //Debug.Log("VidcamMan ("+name+") LateUpdate has " + foundLabelList.Count + " labels at time " + Time.time);

            if (saveLabelListOnce)
            {
                SaveLabelList(sman.vcman.lastcamset);
                saveLabelListOnce = false;
            }
            if (saveLabelListContinuously)
            {
                var gap = Time.time - lastlabelsave;
                if (gap > savefreqsecs)
                {
                    SaveLabelList(sman.vcman.lastcamset);
                }
            }
        }
        Color GetPersColor(Person pers, Color altcolor)
        {
            if (useEmpClassColors)
            {
                switch (pers.empStatus)
                {
                    case PersonMan.empStatusE.Security: return GraphAlgos.GraphUtil.GetColorByName("violet");
                    case PersonMan.empStatusE.FullTimeEmp: return Color.blue;
                    case PersonMan.empStatusE.Contractor: return Color.yellow;
                    case PersonMan.empStatusE.Visitor: return Color.green;
                    case PersonMan.empStatusE.Unknown: return Color.red;
                }
            }
            return altcolor;
        }
        public string GetIdText(PersonMan.empStatusE stat)
        {
            switch (stat)
            {
                case PersonMan.empStatusE.FullTimeEmp: return fteText;
                case PersonMan.empStatusE.Contractor: return contractorText;
                case PersonMan.empStatusE.Security: return securityText;
                case PersonMan.empStatusE.Visitor: return visitorText;
                case PersonMan.empStatusE.Unknown: return unknownText;
            }
            return "Unknown";
        }

        public bool GetEnabled(PersonMan.empStatusE stat)
        {

            switch (stat)
            {
                case PersonMan.empStatusE.FullTimeEmp: return detectFte.Get();
                case PersonMan.empStatusE.Contractor: return detectContractor.Get();
                case PersonMan.empStatusE.Security: return detectSecurity.Get();
                case PersonMan.empStatusE.Visitor: return detectVisitor.Get();
                case PersonMan.empStatusE.Unknown: return detectUnknown.Get();
            }
            return false;
        }

        public bool SetVisibityOnEnablement(Person pers)
        {
            var enabled = !visibilityTiedToDetectability.Get() || GetEnabled(pers.empStatus);
            if (pers.persGo)
            {
                pers.persGo.gameObject.SetActive(enabled);
            }
            else
            {
                Debug.Log("null persgo for " + pers.personName);
            }
            pers.SetVisiblity(GetEnabled(pers.empStatus));
            return enabled;
        }
        public void SetPeepVisibility()
        {
            var ncnt = 0;
            var peeps = sman.psman.GetPersonList();
            foreach (var peep in peeps)
            {
                var enabled = SetVisibityOnEnablement(peep);
                if (enabled) ncnt++;
            }
            Debug.Log($"SetPeepVisiblity - Visible count:{ncnt} updatecnt:{updcount}");       
        }

        public void CalcBldRoomFrames(BldRoom broom, personDetectModeE personDetectMode)
        {
            int icnt = 0;
            var persons = broom.GetPersons();
            var vz = Vector3.zero;
            var cam = sman.vcman.GetCurrentCamera();
            foreach (var person in persons)
            {
                //var rendgo = pers.roomPogo;
                //if (showOnlyFlaggedPeople && !person.flagged) continue;

                var rendgo = GetBodyPart(person, personDetectMode);
                if (rendgo == null) continue;
                if (!person.GetVisiblity()) continue;

                if (!GraphAlgos.GraphUtil.ClipToCameraBox(rendgo, clipdist: maxFrameDist,cam)) continue;
                var obrect = GraphAlgos.GraphUtil.GUIRectWithObject(rendgo,cam);
                var obrectvisible = GraphAlgos.GraphUtil.ClipToScreen(obrect);
                if (obrectvisible)
                {
                    var cmt = person.personName +" ("+person.empStatus+") in room " + broom.roomFullName;
                    var clr = GetPersColor(person, Color.magenta);
                    var pt = rendgo.transform.position;
                    var rot = rendgo.transform.localEulerAngles;
                    //var debstr = person.placeBld+"/"+person.placeNode +"/"+person.placeRoom;
                    //AddFoundLabel(LableClassE.person, person.avatarName, person.personName, person.empStatus.ToString(),debstr, obrect,pt,rot,vz, broom.roomFullName, cmt, clr, 2);
                    AddFoundLabel(person, obrect, pt, rot, vz, broom.roomFullName, cmt, clr, 2);
                    icnt++;
                }
            }
        }
        GameObject GetBodyPart(Person person, personDetectModeE personDetectMode)
        {
            GameObject bpgo = null;
            switch (personDetectMode)
            {
                case personDetectModeE.head:
                    bpgo = person.GetBodyPart(Person.BodyPart.head);
                    break;
                default:
                case personDetectModeE.person:
                    bpgo = person.GetBodyPart(Person.BodyPart.body);
                    break;
            }
            return bpgo;
        }
        public void CalcBldFrames(personDetectModeE personDetectMode)
        {
            if (!frameBuildings.Get()) return;
            var brooms = sman.bdman.GetBrooms();
            foreach (BldRoom broom in brooms)
            {
                if (!broom.enableFrames) continue;
                CalcBldRoomFrames(broom, personDetectMode);
            }
            //Debug.Log("CalcGarageFrames Added " + icnt + " label/frames");
        }
        public void CalcZoneFrames(personDetectModeE personDetectMode)
        {
            if (!frameZones.Get()) return;
            var vz = Vector3.zero;
            int icnt = 0;
            var zoneslots = sman.znman.GetZoneSlots();
            var cam = sman.vcman.GetCurrentCamera();
            foreach (ZoneSlot slot in zoneslots)
            {
                if (slot.slotformgo != null)
                {
                    if (slot.pogo != null && slot.person.GetVisiblity())
                    {
                        //if (showOnlyFlaggedPeople && !slot.person.flagged) continue;
                        var rendgo = GetBodyPart(slot.person, personDetectMode);
                        if (rendgo == null) continue;

                        //var rendgo = slot.persgo;
                        if (!GraphAlgos.GraphUtil.ClipToCameraBox(rendgo, clipdist: maxFrameDist,cam)) continue;

                        var obrect = GraphAlgos.GraphUtil.GUIRectWithObject(rendgo,cam);
                        var obrectvisible = GraphAlgos.GraphUtil.ClipToScreen(obrect);
                        if (obrectvisible)
                        {

                            var person = slot.person;
                            var cmt = person.personName + " (" + person.empStatus + ") occupying " + slot.fullname;
                            var clr = GetPersColor(person, Color.yellow);
                            var pt = rendgo.transform.position;
                            var rot = rendgo.transform.localEulerAngles;
                            var empstat = person.empStatus.ToString();
                            //var debstr = person.placeBld + "/" + person.placeNode + "/" + person.placeRoom;
                            //AddFoundLabel(LableClassE.person, slot.avatarname, person.personName, empstat, debstr, obrect, pt,rot,vz, slot.fullname, cmt, clr, 2);
                            AddFoundLabel(person, obrect, pt, rot, vz, slot.fullname, cmt, clr, 2);
                            icnt++;
                        }
                    }
                }
            }
            //Debug.Log("CalcZoneFrames Added " + icnt + " Label/Frames");
        }


        public void CalcGarageFrames()
        {
            if (!frameGarages.Get()) return;
            var vz = Vector3.zero;
            int icnt = 0;
            var slots = sman.gaman.GetGarageSlots();
            var cam = sman.vcman.GetCurrentCamera();
            //Debug.Log($"CalcGarageFrames name:{cam.gameObject.name} cam.pos:{cam.transform.position}");
            foreach (GarageSlot slot in slots)
            {
                if (slot.slotformgo != null)
                {
                    if (slot.cargo != null)
                    {
                        if (!GraphAlgos.GraphUtil.ClipToCameraBox(slot.cargo, clipdist: maxFrameDist,cam)) continue;

                        var obrect = GraphAlgos.GraphUtil.GUIRectWithObject(slot.cargo,cam);
                        var obrectvisible = GraphAlgos.GraphUtil.ClipToScreen(obrect);
                        if (obrectvisible)
                        {
                            var v = slot.vehicle;
                            var cmt = v.vehicleId + " parked in " + slot.fullname;
                            var pt = slot.cargo.transform.position;
                            var rot = slot.cargo.transform.localEulerAngles;
                            //AddFoundLabel(LableClassE.vehicle, v.formName, v.vehicleId, v.formName,"", obrect,pt,rot,vz, slot.fullname, cmt, Color.yellow, 2);
                            AddFoundLabel(v,  obrect, pt, rot, vz, slot.fullname, cmt, Color.yellow, 2);
                            icnt++;
                        }
                    }
                }
            }
            //Debug.Log("CalcGarageFrames Added " + icnt + " label/frames");
        }


        public void CalcJourneyFrames(BirdFormE formfilter, personDetectModeE personDetectMode)
        {
            if (!frameJourneys.Get()) return;
            var vz = Vector3.zero;
            int icnt = 0;
            var journeys = sman.jnman.GetJourneys();
            var cam = sman.vcman.GetCurrentCamera();
            foreach (Journey jny in journeys)
            {
                if (jny.status == JourneyStatE.WaitingToStart) continue;

                var visible = false;
                var birdThing = jny.birdctrl.birdform;
                if (birdThing == formfilter)
                {
                    var rendgo = jny.birdctrl.birdformgo;
                    if (formfilter == BirdFormE.person)
                    {
                        //if (showOnlyFlaggedPeople && !jny.person.flagged) continue;
                        if (!jny.person.GetVisiblity()) continue;
                        rendgo = GetBodyPart(jny.person, personDetectMode);
                        if (rendgo == null) continue;
                    }

                    if (!GraphAlgos.GraphUtil.ClipToCameraBox(rendgo, clipdist: maxFrameDist,cam)) continue;

                    jny.birdrect = GraphAlgos.GraphUtil.GUIRectWithObject(rendgo,cam);
                    visible = GraphAlgos.GraphUtil.ClipToScreen(jny.birdrect);
                    visible = visible && GraphAlgos.GraphUtil.IsInFrontOfMainCamera(rendgo,cam);
                    jny.birdrectvisible = visible;
                    if (visible)
                    {
                        var id = jny.person.personName;
                        var id2 = jny.person.empStatus.ToString();
                        var model = jny.person.avatarName;
                        if (birdThing == BirdFormE.car)
                        {
                            id = jny.vehicle.vehicleId;
                            id2 = jny.vehicle.formName;
                        }
                        else
                        {
                            var person = jny.person;
                        }
                        var cmt = jny.birdctrl.birdresourcename + "  journeying";
                        //cmt += " Sc w,h:" + Screen.width + "," + Screen.height;
                        var clr = Color.cyan;
                        if (formfilter == BirdFormE.person)
                        {
                            clr = GetPersColor(jny.person, clr);
                        }
                        var pt = rendgo.transform.position;
                        var rot = rendgo.transform.localEulerAngles;
                        var vel = jny.birdctrl.birdVelVek;
                        var locname = jny.birdctrl.pathweg.link.name;
                        //var thing = (birdThing == BirdFormE.car ? LableClassE.vehicle : LableClassE.person);
                        //AddFoundLabel(thing, model, id, id2, debstr, jny.birdrect, pt, rot, vel, locname, cmt, clr, 2);
                        if (birdThing == BirdFormE.person)
                        {
                            AddFoundLabel(jny.person, jny.birdrect, pt, rot, vel, locname, cmt, clr, 2);
                        }
                        else
                        {
                            AddFoundLabel(jny.vehicle, jny.birdrect, pt, rot, vel, locname, cmt, clr, 2);
                        }
                        icnt++;
                    }
                }
            }
            //Debug.Log("CalcJourneyFrames added " + icnt + " label/frames");
        }

        string GetLabelText(textContentE choice, LableClassE thing, string personName, string empStatusText, string debstr)
        {
            string rv = "";
            if (thing != LableClassE.person) return thing.ToString();
            switch (choice)
            {
                case textContentE.empstatus:
                    {
                        Enum.TryParse<PersonMan.empStatusE>(empStatusText, true, out var stat);
                        rv = GetIdText(stat);
                    }
                    break;
                case textContentE.name:
                    rv = personName;
                    break;
                case textContentE.debstr:
                    rv = debstr;
                    break;
            }
            return rv;
        }

        private void OnGUI()
        {
            if (Event.current.type != EventType.Repaint) return;
            // still gets called multiple times per update, but less now
            var textcolor = GraphAlgos.GraphUtil.GetColorByName("black",alpha:1);

            foreach (var flab in foundLabelList)
            {
                var toptxt = GetLabelText(topLabelText.Get(),flab.thing, flab.id, flab.id2,flab.debstr);
                var bottxt = GetLabelText(botLabelText.Get(), flab.thing, flab.id, flab.id2,flab.debstr);
                GraphAlgos.GraphUtil.GUIDrawRectFrame(flab.rect, flab.color, linwid: rectLineWidth, textcolor: textcolor, topLabel: toptxt, BotLabel: bottxt);
            }
            //Debug.Log("VidcamMan ("+name+") OnGUI has " + foundLabelList.Count + " labels at time "+Time.time);
        }
        void Start()
        {
            sman = FindObjectOfType<SceneMan>();

            //filesavepath = "./labels/" + sman.runtimestamp + "/";
        }
        bool _visibilityTiedToDetectability;
        bool _detectFte;
        bool _detectCon;
        bool _detectSec;
        bool _detectVis;
        bool _detectUnk;
        public bool DetectionChanged()
        {
            var chg = true;
            if (updcount>=0)
            {
                chg = _visibilityTiedToDetectability != visibilityTiedToDetectability.Get() ||
                      _detectFte != detectFte.Get() ||
                      _detectCon != detectContractor.Get() ||
                      _detectSec != detectSecurity.Get() ||
                      _detectVis != detectVisitor.Get() ||
                      _detectUnk != detectUnknown.Get();
            }
            _visibilityTiedToDetectability = visibilityTiedToDetectability.Get();
            _detectFte = detectFte.Get();
            _detectCon = detectContractor.Get();
            _detectSec = detectSecurity.Get();
            _detectVis = detectVisitor.Get();
            _detectUnk = detectUnknown.Get();
            return chg;
        }

        bool forceFramed = false;
        int updcount = 0;
        // Update is called once per frame
        void Update()
        {
            updcount++;
            if (forceFrameAllRooms)
            {
                forceFramed = !forceFramed;
                sman.bdman.ForceFrameAllRooms(forceFramed);
                forceFrameAllRooms = false;
            }
            if (DetectionChanged())
            {
                SetPeepVisibility();
            }
        }

    }
}
