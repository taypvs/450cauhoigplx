using UnityEngine;
using System.Collections;

public class BoxFollow : MonoBehaviour {

	public Transform pointFollow;
	public GameObject car;
	public GameObject wheel1;
	public GameObject wheel2;
	public GameObject wheel3;
	public GameObject wheel4;

	private float wheelSpeedRatio;
	private float lookSmoothRate;
	private float lookSmoothRatio;
	private float forwardDirection; // -1: forward  -    1: backward
	// Use this for initialization
	void Start () {
		lookSmoothRatio = 0.25f;
		wheelSpeedRatio = 8;
		forwardDirection = -1;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = pointFollow.position;
		lookSmoothRate = car.GetComponent<CarScript> ().currentSpeed;
		wheel1.transform.Rotate (new Vector3 (0, 0, 1) * Time.deltaTime * car.GetComponent<CarScript> ().currentSpeed*wheelSpeedRatio*forwardDirection);
		wheel2.transform.Rotate (new Vector3 (0, 0, 1) * Time.deltaTime * car.GetComponent<CarScript> ().currentSpeed*wheelSpeedRatio*forwardDirection);
		wheel3.transform.Rotate (new Vector3 (0, 0, 1) * Time.deltaTime * car.GetComponent<CarScript> ().currentSpeed*wheelSpeedRatio*forwardDirection);
		wheel4.transform.Rotate (new Vector3 (0, 0, 1) * Time.deltaTime * car.GetComponent<CarScript> ().currentSpeed*wheelSpeedRatio*forwardDirection);
		SmoothLook ();
	}

	private void SmoothLook(){
		Transform targetLook = car.transform.Find ("Root").Find("Head");
		transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(targetLook.position - transform.position), Time.deltaTime*lookSmoothRate*lookSmoothRatio);
	}
}
