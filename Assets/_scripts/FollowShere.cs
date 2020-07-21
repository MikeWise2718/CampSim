using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FollowShere : MonoBehaviour {

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

    // Use this for initialization
    void Start () {
        startpos = transform.position;
	}
	

    void Track(string birdname)
    {
        bird = GameObject.Find(birdname);
        if (bird != null)
        {
            birdpos = bird.transform.position;
            var pdelt = bird.transform.position - transform.position;
            var dist = Vector3.Distance(bird.transform.position, transform.position);

            if (dist < 2.0)
            {
                vel = vel.normalized * decelFak;
                pdelt = pdelt.normalized * decelFak;
            }
            else if (dist < 0.5)
            {
                vel = vel.normalized * decelFak;
                pdelt = pdelt.normalized * decelFak;
            }
            var bmovedist = Vector3.Distance(lastbirdpos, birdpos);
            if (bmovedist == 0)
            {
                vel = vel.normalized * 0.2f; // put the brakes on
            }

            vel = vel + attractFak * pdelt * Time.deltaTime;
            var moveit = vel * Time.deltaTime;

            if (vel.magnitude > maxvel)
            {
                vel = vel.normalized * maxvel; // clamp at maxvel
            }
            var dfk = 1 / Time.deltaTime;
            Debug.Log("Found bird vel:" + vel + " vdelt:" + pdelt + " dt:" + Time.deltaTime + " dfk:" + dfk);
            var newpos = transform.position + moveit;
            // newpos.y = startpos.y;  // pin the y axis
            transform.position = newpos;
            var lookpos = bird.transform.position;
            lookpos.y *= 0.8f; // look down a bit so we can see the ground too
            transform.LookAt(lookpos);
            lastbirdpos = birdpos;
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
