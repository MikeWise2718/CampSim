using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CampusSimulator
{
    public class LocationMan : MonoBehaviour
    {
        public  SceneMan sman;

        public string locstate = "unstarted";
        public bool running = false;
        // Start is called before the first frame update
        IEnumerator Start()
        {
            // First, check if user has location service enabled
            if (!Input.location.isEnabledByUser)
            {
                locstate = "Not enabled";
                yield break;
            }

            // Start service before querying location
            Input.location.Start();

            // Wait until service initializes
            int maxWait = 20;
            while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
            {
                locstate = "Service Starting";
                yield return new WaitForSeconds(1);
                maxWait--;
            }

            // Service didn't initialize in 20 seconds
            if (maxWait < 1)
            {
                locstate = "Service Timed Out after " + maxWait + " secs";
                yield break;
            }

            // Connection has failed
            if (Input.location.status == LocationServiceStatus.Failed)
            {
                locstate = "Service Unable to determine device location";
                yield break;
            }
            else
            {
                locstate = "Service Running";
                running = true;
                // Access granted and location value could be retrieved
            }

            // Stop service if there is no need to query location updates continuously
            //Input.location.Stop();
        }

        private void Awake()
        {
            if (SystemInfo.supportsGyroscope)
            {
                Input.gyro.enabled = true;
            }
        }

        public string GetLocState()
        {
            return locstate;
        }


        public Vector3 GetLoc()
        {
            if (!running) return Vector3.zero;
            var rv = new Vector3(Input.location.lastData.latitude, Input.location.lastData.altitude, Input.location.lastData.longitude);
            //print("Location: " +  + " " + Input.location.lastData.longitude + " " + Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp);
            return rv;
        }
        public Vector2 GetLocAccuracy()
        {
            if (!running) return Vector2.zero;
            var rv = new Vector2(Input.location.lastData.horizontalAccuracy, Input.location.lastData.verticalAccuracy);
            return rv;
        }
        public double GetLocTime()
        {
            if (!running) return 0;
            var rv = Input.location.lastData.timestamp;
            return rv;
        }
        public Quaternion GetGyro()
        {
            if (!SystemInfo.supportsGyroscope) return new Quaternion(1, 2, 3, 4);
            var rv = Input.gyro.attitude;
            return rv;
        }

        // Update is called once per frame
        //void Update()
        //{

        //}
    }
}