﻿using UnityEngine;
using System.Collections;

public class BoxFollow : MonoBehaviour {

	public Transform pointFollow;

	public TruckBody forwardBody;
	public TruckBody backwardBody;
	// Use this for initialization
	void Start () {
		switchForward ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = pointFollow.position;
	}


	public void switchBackward(){
		Debug.Log ("switchBackward");
		backwardBody.switchBody ();
		forwardBody.switchBody ();
	}

	public void switchForward(){
		Debug.Log ("switchForward");
		forwardBody.switchBody ();
		backwardBody.switchBody ();
	}

	public void switchActiveRotate(){
		transform.GetChild (0).GetComponent<TruckBody> ().isAllowRotate = !transform.GetChild (0).GetComponent<TruckBody> ().isAllowRotate;
	}
}
