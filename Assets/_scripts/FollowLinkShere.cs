using CampusSimulator;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FollowLinkShere : MonoBehaviour {

    GameObject bird = null;
    Vector3 vel = Vector3.zero;
    public Vector3 startpos;
    Vector3 lastbirdpos = Vector3.zero;
    Vector3 birdpos = Vector3.zero;
    public float maxvel = 2.0f;
    public float updateGap = 0.1f;
//    public float decelFak = 0.8f;
  //  public float attractFak = 0.01f;
    public float decelFak = 0.8f;
    public float attractFak = 0.6f;
    public SceneMan sman;

    // Use this for initialization
    void Start () {
        startpos = transform.position;
	}
	

    void Track(string birdname)
    {
        if (sman==null)
        {
            sman = GameObject.FindObjectOfType<SceneMan>();
            if (sman==null)
            {
                Debug.LogError("FollowLinkSphere could not find sman");
                return;
            }
        }
        bird = GameObject.Find(birdname);
        if (bird != null)
        {
            birdpos = bird.transform.position;

            var grc = sman.lcman.GetGraphCtrl();
            var (link, closept) = grc.FindClosestPointOnLineCloud(birdpos);

            //Debug.Log($"Found closest birdlink");
            // newpos.y = startpos.y;  // pin the y axis
            transform.position = closept;
            //var lookpos = bird.transform.position;
            //lookpos.y *= 0.8f; // look down a bit so we can see the ground too
            //transform.LookAt(lookpos);
            //lastbirdpos = birdpos;
        }
    }

    float lastTime = 0;
    
	// Update is called once per frame
	void Update () 
    {
        //if ((Time.time - lastTime) > updateGap)
        //{
            Track("Viewer");
            lastTime = Time.time;
       // }
    }
}
