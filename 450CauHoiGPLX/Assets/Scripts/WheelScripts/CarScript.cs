﻿using UnityEngine;
using System.Collections;

public class CarScript : MonoBehaviour, CarBehaviorInterface {

	public GameObject[] targetPoint;
	public GameObject popUp;

	private float currentSpeed;
	private float defaultSpeed;
	private bool isMoving;
	private int pointPosition;
	private GameObject currentPoint;

	private void init(){
		isMoving = false;
		currentSpeed = 0;
		defaultSpeed = 15f;
		pointPosition = -1;
	}

	// Use this for initialization
	void Start () {
		init ();
		startMoving ();
	}
	
	// Update is called once per frame
	void Update () {
		if (distanceToPoint () < 0.01f && isMoving) {
			if (currentPoint.GetComponent<TargetPoint> ().isCheckPoint) {
				stop ();
				showPopupInfo ();
			} else {
				moveToNextPoint ();
			}
		}
	}

	public void startMoving(){
		isMoving = true;
		currentSpeed = defaultSpeed;
		moveToNextPoint ();
	}
	public void moveToNextPoint (){
		pointPosition++;
		if (pointPosition < targetPoint.Length) {
			currentPoint = targetPoint [pointPosition];
			SmoothLook (currentPoint.transform);
//			transform.LookAt (currentPoint.transform);
//			iTween.MoveTo (gameObject, iTween.Hash ("position", currentPoint.transform.position, "speed", currentSpeed, "EaseType", iTween.EaseType.spring));
			transform.Translate((currentPoint.transform.position - transform.position)*currentSpeed*Time.deltaTime);
		}
	}

	public void stop (){
		isMoving = false;
	}

	public void showPopupInfo (){
		popUp.SetActive (true);
	}

	public void hidePopupInfo (){
		popUp.SetActive (false);
	}

	public void startEngine (){
	
	}

	private float distanceToPoint(){
		return Vector3.Distance (transform.position, currentPoint.transform.position);
	}

	public void OnTriggerEnter(Collider collider){
		Debug.Log ("OnTriggerEnter");
	}
		
	private void SmoothLook(Transform target){
//		transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(newDirection), Time.deltaTime);
		iTween.LookTo(gameObject, iTween.Hash("looktarget", target , "time", 6f));
	}

}
