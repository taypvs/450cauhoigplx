using UnityEngine;
using System.Collections;

public class TrafficLightController : MonoBehaviour {

	public GameObject greenLight;
	public GameObject redLight;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void switchLight(){
		if (greenLight.activeSelf) {
			redLight.SetActive (true);
			greenLight.SetActive (false);
		}
		else if (redLight.activeSelf) {
			redLight.SetActive (false);
			greenLight.SetActive (true);
		}
	}

	public void switchLightAfter(float seconds){
		StartCoroutine (switchLightAfterSeconds (seconds));
	}

	IEnumerator switchLightAfterSeconds(float seconds) {
		yield return new WaitForSeconds(seconds);
		switchLight ();
	}

}
