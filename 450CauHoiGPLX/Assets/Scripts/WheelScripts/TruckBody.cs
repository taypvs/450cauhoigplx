using UnityEngine;
using System.Collections;

public class TruckBody : MonoBehaviour {

	public bool isBackward;
	public bool isActive;
	public GameObject oppisitePart;

	public GameObject wheel1;
	public GameObject wheel2;
	public GameObject wheel3;
	public GameObject wheel4;

	public GameObject target;
	public Transform parent;
	private float forwardDirection; // -1: forward  -    1: backward
	private float wheelSpeedRatio;
	private float lookSmoothRate;
	private float lookSmoothRatio;
	// Use this for initialization
	void Start () {
		lookSmoothRatio = 0.25f;
		wheelSpeedRatio = 8;
		if(isBackward)
			forwardDirection = 1;
		else
			forwardDirection = -1;
	}
	
	// Update is called once per frame
	void Update () {
		if (isActive)
			SmoothLook ();

		lookSmoothRate = target.GetComponent<CarScript> ().currentSpeed;
		wheel1.transform.Rotate (new Vector3 (0, 0, 1) * Time.deltaTime * target.GetComponent<CarScript> ().currentSpeed*wheelSpeedRatio*forwardDirection);
		wheel2.transform.Rotate (new Vector3 (0, 0, 1) * Time.deltaTime * target.GetComponent<CarScript> ().currentSpeed*wheelSpeedRatio*forwardDirection);
		wheel3.transform.Rotate (new Vector3 (0, 0, 1) * Time.deltaTime * target.GetComponent<CarScript> ().currentSpeed*wheelSpeedRatio*forwardDirection);
		wheel4.transform.Rotate (new Vector3 (0, 0, 1) * Time.deltaTime * target.GetComponent<CarScript> ().currentSpeed*wheelSpeedRatio*forwardDirection);
	}

	private void SmoothLook(){
		Transform targetLook;
		if(!isBackward)
			targetLook = target.transform.Find ("Root").Find("Head");
		else
			targetLook = target.transform.Find ("Root").Find("Tail");
		transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(targetLook.position - transform.position), Time.deltaTime*lookSmoothRate*lookSmoothRatio);
	}

	public void switchBody(){
		if (!isActive) {
			isActive = true;
			transform.SetParent (parent);
		} else {
			isActive = false;
			transform.SetParent (oppisitePart.transform);
		}
			
	}
}
