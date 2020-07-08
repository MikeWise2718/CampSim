using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UxUtils;
using Aiskwk.Map;
using Aiskwk.Dataframe;

namespace CampusSimulator
{

    public class StreetMan : MonoBehaviour
    {
        public SceneMan sman;

        public UxSettingBool osmstreets = new UxSettingBool("osmstreets", false);
        public UxSettingBool fixedstreets = new UxSettingBool("fixedstreets", false);

        public void InitPhase0()
        {
        }


        public void InitializeValues()
        {
            osmstreets.GetInitial(false);
            fixedstreets.GetInitial(true);
            Debug.Log($"StreetMan.InitializeValues osmblds:{osmstreets.Get()}   fixedblds:{fixedstreets.Get()}");
        }


        public void InitializeScene(SceneSelE newregion)
        {
            Debug.Log($"StreetMan.SetScene {newregion}");
            InitializeValues();
            var osmloadspec = "";
            switch (newregion)
            {
                case SceneSelE.MsftRedwest:
                case SceneSelE.MsftCoreCampus:
                case SceneSelE.MsftB19focused:
                    osmloadspec = "msftb19area,msftcommons,msftredwest";
                    break;
                case SceneSelE.MsftDublin:
                    osmloadspec = "msftdublin";
                    //ptscale = 1000f;
                    break;
                case SceneSelE.Eb12small:
                case SceneSelE.Eb12:
                    osmloadspec = "eb12small";
                    break;
                case SceneSelE.TeneriffeMtn:
                    osmloadspec = "tenmtn";
                    //ptscale = 1000f;
                    break;
                case SceneSelE.TukSouCen:
                    osmloadspec = "tuksoucen";
                    //ptscale = 1000f;
                    break;
                case SceneSelE.HiddenLakeLookout:
                    osmloadspec = "hidlakelook";
                    //ptscale = 1000f;
                    break;
                default:
                case SceneSelE.None:
                    // DelBuildings called above already
                    break;
            }
            if (osmloadspec != "")
            {
                //GetDfsFromResources(osmloadspec);
            }
        }


        public void SetScene(SceneSelE newregion)
        {
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