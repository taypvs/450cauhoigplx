using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class B1_Screen_Manager : MonoBehaviour {

	public Text speedTxt;
	public GameObject car;
	public GameObject popUpEndTest;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		speedTxt.text = car.GetComponent<CarScript> ().currentSpeed.ToString() + " Km/h";

		if (Input.GetKeyDown (KeyCode.Escape)) {
			car.GetComponent<CarScript> ().isMoving = false;
			popUpEndTest.SetActive (true);
		}
	}
}
