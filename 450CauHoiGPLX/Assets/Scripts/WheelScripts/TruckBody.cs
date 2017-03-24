using UnityEngine;
using System.Collections;

public class TruckBody : MonoBehaviour {

	public bool isBackward;
	public bool isActive;
	public bool isAllowRotate;
	public GameObject oppisitePart;

	public GameObject wheel1;
	public GameObject wheel2;
	public GameObject wheel3;
	public GameObject wheel4;

	public GameObject target;
	public GameObject backwardTarget;
	public Transform parent;
	private float forwardDirection; // -1: forward  -    1: backward
	private float wheelSpeedRatio;
	private float lookSmoothRate;
	private float lookSmoothRatio;
	private float lookBackSmoothRatio;
	// Use this for initialization
	void Start () {
		lookBackSmoothRatio = 1f;
		lookSmoothRatio = 0.3f;
		wheelSpeedRatio = 20;
		if(isBackward)
			forwardDirection = 1;
		else
			forwardDirection = -1;
	}
	
	// Update is called once per frame
	void Update () {
		if (isActive&&isAllowRotate&&target.GetComponent<CarScript> ().isMoving)
			SmoothLook ();

		lookSmoothRate = target.GetComponent<CarScript> ().currentSpeed;
		wheel1.transform.Rotate (new Vector3 (0, 0, 1) * Time.deltaTime * target.GetComponent<CarScript> ().currentSpeed*wheelSpeedRatio*forwardDirection);
		wheel2.transform.Rotate (new Vector3 (0, 0, 1) * Time.deltaTime * target.GetComponent<CarScript> ().currentSpeed*wheelSpeedRatio*forwardDirection);
		wheel3.transform.Rotate (new Vector3 (0, 0, 1) * Time.deltaTime * target.GetComponent<CarScript> ().currentSpeed*wheelSpeedRatio*forwardDirection);
		wheel4.transform.Rotate (new Vector3 (0, 0, 1) * Time.deltaTime * target.GetComponent<CarScript> ().currentSpeed*wheelSpeedRatio*forwardDirection);
	}

	private void SmoothLook(){
		Transform targetLook;
		if (!isBackward) {
			targetLook = target.transform.Find ("Root").Find ("Head");
			transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(targetLook.position - transform.position), Time.deltaTime*lookSmoothRate*lookSmoothRatio);
		} else {
			targetLook = backwardTarget.transform;
			transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(targetLook.position - transform.position), Time.deltaTime*lookSmoothRate*lookBackSmoothRatio);
		}
		//transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(targetLook.position - transform.position), Time.deltaTime*lookSmoothRate*lookSmoothRatio);
		//iTween.LookTo(gameObject, iTween.Hash("looktarget", targetLook , "time", 0.4f*lookSmoothRate*lookSmoothRatio, "easeType", iTween.EaseType.linear));
	}

	public void switchBody(){
		if (!isActive) {
			isActive = true;
			isAllowRotate = true;
			transform.SetParent (parent);
		} else {
			isActive = false;
			transform.SetParent (oppisitePart.transform);
		}
			
	}
}
