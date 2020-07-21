using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Humm1Controller : MonoBehaviour {
	public enum hummControlType  { Free,FixedHeight };
	public float velInc=1.414f;
	public float velFak=1;
	public float turnInc=3;
	public float turnFak=2;
	public float maxVel=20;
	public hummControlType controlType=hummControlType.Free;


	private GameObject[] hudtextgo;
	private Text[] hudtext;
	private Rigidbody rb;
	private float mVel = 0;
	private float mYaw = 0;
	private float mPit = 0;
	private float mRol = 0;
	private int frameCount = 0;

	// Use this for initialization
	void Start()
	{
		rb = GetComponent<Rigidbody>();
		hudtextgo = GameObject.FindGameObjectsWithTag("hudtext");
		//print (hudtextgo);
		//print (hudtextgo.Length);
		hudtext = new Text[hudtextgo.Length];
		for (var i = 0; i < hudtextgo.Length; i++) {
			hudtext[i] = hudtextgo[i].GetComponent<Text> ();			
		}
		Array.Sort(hudtext, delegate(Text x, Text y) { return x.text.CompareTo(y.text); });
	}

	Vector3 boundVector(Vector3 v,float mxv){
		float exfak = v.magnitude / mxv;
		if (exfak>1){
			v = v / exfak;
		}
		return(v);
	}
	// Update is called once per frame
	void Update()
	{
		if (rb==null)
        {
			return;
        }
        //Debug.Log("update humm1ctrl");
		mYaw = mYaw + Input.GetAxis("Horizontal");
		mPit = mPit + Input.GetAxis("Vertical");
		if (Input.GetKeyDown(KeyCode.Insert)){
			mVel = 0;
			mYaw = 0;
			mPit = 0;
			mRol = 0;
			var rot = rb.rotation.eulerAngles;
			rb.rotation = Quaternion.Euler(rot.x, rot.y, 0);
		}
		if (Input.GetKeyDown(KeyCode.KeypadPlus)){
			if (mVel == 0) mVel =0.5f;
			mVel = mVel * velInc;
		}
		if (Input.GetKeyDown(KeyCode.KeypadMinus)){
			mVel = mVel / velInc;
		}
		if (Input.GetKeyDown(KeyCode.A)){
			mRol = mRol + turnInc;
		}
		if (Input.GetKeyDown(KeyCode.S)){
			mRol = mRol - turnInc;
		}
	}
	void FixedUpdate()
	{
		if (rb==null)
        {
			return;
        }
		Move();
		Turn();
		frameCount++;
		addText(3, "Fc:"+frameCount.ToString() );
	}
	void addText(int pos,string itext)
	{
		if (hudtext != null) {
			if (pos < hudtext.Length) {
				hudtext[pos].text = itext;
			}
		}
	}
	private void Move ()
	{
		// Create a vector in the direction the tank is facing with a magnitude based on the input, speed and the time between frames.
		float vel = mVel * velFak;
		Vector3 movit = transform.forward*vel*Time.deltaTime;
		if (controlType == hummControlType.FixedHeight) {
			movit.y = 0;
		}

		// Apply this movement to the rigidbody's position.
		rb.MovePosition(rb.position + movit);
		addText(0, "Pos:"+rb.position.ToString()+ " Vel:"+vel.ToString() );
	}
	private void Turn ()
	{
		// Determine the number of degrees to be turned based on the input, speed and time between frames.
		float dYaw = mYaw*turnFak*Time.deltaTime;
		float dPit = mPit*turnFak*Time.deltaTime;
		float dRol = mRol*turnFak*Time.deltaTime;

		if (controlType == hummControlType.FixedHeight) {
			dRol = 0;
			dPit = 0;
		}
		// Make this into a rotation in the y axis.
		Quaternion turnRotation = Quaternion.Euler(dPit,dYaw,dRol);



		// Apply this rotation to the rigidbody's rotation.
		rb.MoveRotation (rb.rotation * turnRotation);
		var rot = rb.rotation.eulerAngles;
		addText(1, "Rot:"+rot.ToString() );
	}

}