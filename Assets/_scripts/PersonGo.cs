using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CampusSimulator
{
    public class PersonGo : MonoBehaviour
    {
        public Person person;
        public bool toggleHololens;
        public bool toggleCamera;
        public bool toggleMainCamera;
        public bool sendOnJourney;
        public Animator animator;
        public GameObject pogo;

        public enum humanoidTypeE { ModPeople, Biped, Unknown, Unchecked }
        public humanoidTypeE humanoidType = humanoidTypeE.Unchecked;

        public void Init(Person person,GameObject pogo)
        {
            this.person = person;
            if (pogo != null)
            {
                this.animator = pogo.GetComponentInChildren<Animator>();
            }
            SetAvatarType();
            //this.building = person.GetBuilding();   doesn't have to be in a building
        }




        static Dictionary<humanoidTypeE, string> headPartPathNames = new Dictionary<humanoidTypeE, string>
        {
            { humanoidTypeE.ModPeople,"master/Reference/Hips/Spine/Spine1/Spine2/Neck/Head" },
            { humanoidTypeE.Biped,"Bip001/Bip001 Pelvis/Bip001 Spine/Bip001 Spine1/Bip001 Neck/Bip001 Head" },
        };
        static Dictionary<humanoidTypeE, float> avatarHeights = new Dictionary<humanoidTypeE, float>
        {
            { humanoidTypeE.ModPeople,1.8f },
            { humanoidTypeE.Biped,1.6f },
        };
        static Dictionary<humanoidTypeE, Vector3> avatarHololensOffsets = new Dictionary<humanoidTypeE, Vector3>
        {
            { humanoidTypeE.ModPeople,new Vector3(0,1.69f,0.07f) },
            { humanoidTypeE.Biped,new Vector3(0,1.49f,0) },
        };
        public GameObject GetBodyPart(Person.BodyPart part)
        {
            GameObject bpgo;
            if (gameObject == null) return null;
            switch (part)
            {
                default:
                case Person.BodyPart.body:
                    bpgo = gameObject;
                    break;
                case Person.BodyPart.head:
                    var partname = GetHeadPartPath() + "/HoloLens/Sphere";
                    bpgo = GraphAlgos.GraphUtil.GetPart(gameObject, partname);
                    break;
            }
            return bpgo;
        }
        public float GetPersonHeight()
        {
            float height = avatarHeights[humanoidTypeE.ModPeople];
            if (avatarHeights.ContainsKey(humanoidType))
            {
                height = avatarHeights[humanoidType];
            }
            return height;
        }
        public string GetHeadPartPath()
        {
            string hloffset = headPartPathNames[humanoidTypeE.ModPeople];
            if (avatarHololensOffsets.ContainsKey(humanoidType))
            {
                hloffset = headPartPathNames[humanoidType];
            }
            return hloffset;
        }
        public Vector3 GetHoloLensOffset()
        {
            Vector3 hloffset = avatarHololensOffsets[humanoidTypeE.ModPeople];
            if (avatarHololensOffsets.ContainsKey(humanoidType))
            {
                hloffset = avatarHololensOffsets[humanoidType];
            }
            return hloffset;
        }

        public void SetAvatarType()
        {
            var child1 = transform.GetChild(0);
            if (child1.name == "H_DDS_LowRes")
            {
                humanoidType = humanoidTypeE.ModPeople;
            }
            else if (child1.name.StartsWith("Bip"))
            {
                humanoidType = humanoidTypeE.Biped;
            }
            else
            {
                humanoidType = humanoidTypeE.Unknown;
            }
        }
        // Update is called once per frame
        void Update()
        {
            if (toggleHololens)
            {
                person.toggleHololens = true;
                toggleHololens = false;
            }
            if (toggleCamera)
            {
                person.toggleCamera = true;
                toggleCamera = false;
            }
            if (toggleMainCamera)
            {
                person.toggleMainCamera = true;
                toggleMainCamera = false;
            }
            if (sendOnJourney)
            {
                person.sendOnJourney = true;
                sendOnJourney = false;
            }
        }
    }
}