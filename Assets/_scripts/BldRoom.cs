﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CampusSimulator {
    public class BldRoom : MonoBehaviour
    {
        public BuildingMan bm;
        public Building bld;
        public int personCap;
        public Vector3 pos;
        public float alignang;
        public float area;
        public float length;
        public float width;
        public GameObject roomformgo;
        public bool enableFrames;
        public bool initEnableFrames;

        BldRoomOccMan occman=null;

        public string roomFullName;
        public string roomNodeName;

        public void Initialize(Building bld, string roomname, string nodename)
        {
            this.bld = bld;
            this.bm = bld.bm;
            this.name = roomname;
            this.roomFullName = bld.name + "/"+ roomname;
            this.roomNodeName = nodename;
        }

        public void SetStatsArea(Vector3 pt, int pcap, float alignang,  float area,bool enableFrames)
        {
            this.personCap = pcap;
            this.pos = pt;
            this.alignang = alignang;
            this.area = area;
            var sqrtarea = Mathf.Sqrt(area);
            this.width = sqrtarea;
            this.length = sqrtarea;
            this.enableFrames = enableFrames;
            occman = gameObject.AddComponent<BldRoomOccMan>();
            occman.init(this, pcap, this.width, this.length,slotsCanExpand:true);
        }
        public void SetStats(Vector3 pt, int pcap, float alignang,  float length, float width, bool enableFrames)
        {
            this.personCap = pcap;
            this.pos = pt;
            this.alignang = alignang;
            this.width = width;
            this.length = length;
            this.area = length*width;
            this.enableFrames = enableFrames;
            occman = gameObject.AddComponent<BldRoomOccMan>();
            occman.init(this, pcap, this.width, this.length, slotsCanExpand: true);
        }
        //float d2r = Mathf.PI / 180;
        float r2d = 180 / Mathf.PI;
        static int instance = 0;
        public void CreateObjects()
        {
            // have to defer
            //Debug.Log("start slot");
            if (bm.sman.lcman.IsNodeName(roomNodeName))
            {
                var lpt = bm.sman.lcman.GetNode(roomNodeName);
                pos = lpt.pt;
            }

            if (roomformgo != null)
            {
                DeleteGos();
                //Debug.Log("opps slotformgo should be null:" + slotformgo.name);
            }

            this.roomformgo = new GameObject(name + "_form_go" + instance);
            instance++;
            roomformgo.transform.parent = this.transform;
            //Debug.Log("Generating roomformgo:" + roomformselector);
            bool createfloor = true;
            if (!occman)
            {
                Debug.LogWarning("occman is null in BldRoom for building " + bld.name);
            }
            bool createperson = occman && occman.GetPersonCount() > 0;
            bool createnodes = occman && bm.sman.lcman.nodesvisible;

            if (createfloor)
            {
                var floor = GameObject.CreatePrimitive(PrimitiveType.Cube);
                floor.transform.parent = roomformgo.transform;
                floor.name = "floor";
                floor.transform.localScale = new Vector3(length, 0.01f, width);
                floor.transform.localRotation = Quaternion.Euler(0, this.alignang, 0);
                //Debug.Log($"name:{name} aa:{this.alignang}");
                //floor.transform.localRotation = Quaternion.Euler(0, -17, 0);
                var crenderer = floor.GetComponent<Renderer>();
                crenderer.material.color = Color.gray;
                crenderer.material.shader = Shader.Find("Diffuse");
                //map.AddDrawingElement(new OnlineMapsDrawingRect(new Vector2(2, 2), new Vector2(1, 1), Color.green, 1,Color.blue));
            }
            if (createperson)
            {
                for (int i = 0; i < occman.GetPersonCount(); i++)
                {
                    var person = occman.GetPersonN(i);
                    //if (pers.personName.Contains("Arnie"))
                    //{
                    //    Debug.Log("Creating ava for " + pers.personName + " i:" + i);
                    //}
                    var pogo = person.GetPogo("-ava-br", createpogo: true, resetposition: true);// room person
//                    var persgo = pers.CreatePersonGo("-ava-br");// room person
                    var idlescript = person.idleScript;
                    var animator = pogo.GetComponentInChildren<Animator>();
                    if (animator != null)
                    {
                        animator.applyRootMotion = false;
                        person.perstate = PersonAniStateE.standing;

                        //idlescript = "Samba Dancing";
                        animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Animations/" + idlescript);
                        PersonMan.UnsyncAnimation(animator, idlescript, "BldRoom");
                        //var aclip = animator.runtimeAnimatorController.animationClips[0];
                        //animator.Play(idlescript, 0, GraphAlgos.GraphUtil.GetRanFloat(0, 1) );// unsync the animations
                        //var ctrl = animator.runtimeAnimatorController;
                        //animation["Idle"].time = Random.Range(0.0, animation["Idle"].length);
                    }

                    person.roomPogo = pogo;
                    var ska = bm.sman.trman.peoplescalemodelnumber.Get();
                    var skav = new Vector3(ska, ska, ska);
                    pogo.transform.localScale = skav;
                    //persgo.name = pers.personName+"-ava";
                    if (!person.UseFixedPlace())
                    {
                        pogo.transform.position = roomformgo.transform.position;
                    }
                    else
                    {
                        var lclc = bm.sman.lcman;
                        var nodept = lclc.GetNode(person.homeNode);
                        var roompt = lclc.GetNode(this.roomNodeName);
                        var diff = nodept.pt - roompt.pt;
                        //var roomrotate = Quaternion.EulerAngles(0, this.alignang, 0);// wierd, apparently EulerAngles is in Radians?
                        var roomrotate = Quaternion.Euler(0, r2d*this.alignang, 0);// this may be wrong?
                        var diffa = roomrotate * diff;
                        pogo.transform.position = diffa;
                    }

                    pogo.transform.SetParent(roomformgo.transform);
                    ////pogo.transform.Rotate(roomformgo.transform.rotation.eulerAngles);

                    if (person.hasCamera)
                    {
                        person.AddCamera(pogo, "BldRoom CreateObjects");
                    }
                    if (person.hasHololens)
                    {
                        person.ActivateHololens(true);
                    }
                    if (person.grabbedMainCamera)
                    {
                        person.GrabMainCamera();
                    }

                    if (!person.UseFixedPlace())
                    {
                        var v = occman.GetOccPosition(person.roomPlaceIdx);
                        //if (bld.name == "Bld19" && (pers.homeRoom=="b19-f01-lobby"))
                        //{
                        //    Debug.Log(pers.personName + " in " + pers.placeNode + "  idx:" + pers.placeIdx + " personCap:" + personCap + " ang:" + ang/d2r+" x:"+x+" z:"+z);
                        //}
                        pogo.transform.Translate(new Vector3(v.x, 0, v.z));
                        var rang = r2d * occman.GetOccAngle(person.roomPlaceIdx);

                        pogo.transform.Rotate(new Vector3(0, 270 - rang, 0));
                    }
                    else
                    {
                        pogo.transform.Rotate(new Vector3(0, person.homeRotate, 0));
                    }


                }
            }
            if (createnodes)
            {
                occman.CreateNodes();
            }
            roomformgo.transform.position = pos;
            roomformgo.transform.rotation = Quaternion.Euler(0, alignang, 0);
        }

        public bool HasFreeRoomSlots()
        {
            return occman.Nfree() > 0;
        }
        public int ReserveRoomSlot()
        {
            return occman.GetFreeRoomSlot(true);
        }
        public void UnReserveRoomSlot(int idx)
        {
            occman.UnReserve(idx);
        }

        public Person GetRandomPerson()
        {
            var i = GraphAlgos.GraphUtil.GetRanInt(occman.GetPersonCount());
            return occman.GetPersonN(i);
        }

        public List<Person> GetFreePeopleInRoom()
        {
            return occman.GetFreeToTravelPeopleInRoom();
        }

        public List<Person> GetAllPeopleInRoom()
        {
            return occman.GetAllPeopleInRoom();
        }


        public List<Person> GetPersons()
        {
            return occman.GetPersons();
        }


        public void OccupyReservedSlot(Person person)
        {
            occman.OccupyReservedSlot(person);
            DeleteGos();
            CreateObjects();
        }
        public void OccupyFixedNode(Person person)
        {
            occman.OccupyFixedNode(person);
            DeleteGos();
            CreateObjects();
        }

        public void OccupyFreeSlot(Person person)
        {
            occman.OccupyFreeSlot(person);
            DeleteGos();
            CreateObjects();
        }
        public void Occupy(Person person, bool regen = true)
        {
            occman.Occupy(person);
            if (regen)
            {
                DeleteGos();
                CreateObjects();
            }
        }

        public void Vacate(Person person)
        {
            occman.Vacate(person);
            //Debug.Log("Deleting gos for room:"+name);
            DeleteGos();
            CreateObjects();
        }
        public void DeleteGos()
        {
            if (roomformgo != null)
            {
                Object.Destroy(roomformgo);
                roomformgo = null;
            }
        }
        public void SetHeight()
        {
            var node = bm.sman.lcman.GetNode(roomNodeName);
            if (node!=null)
            {

            }
        }


        public void CreateGos()
        {
            CreateObjects();
        }
        public void EmptyRoom()
        {
            occman.EmptyRoom();
            occman = null;
        }
    }
}