using UnityEngine;
using System.Collections;
using UnityStandardAssets.Utility;

public class CarSimulation_Screen_Btn : MonoBehaviour {

	public GameObject mainCar;
	public AudioSource soundStart;
	public GameObject car1;
	public GameObject car2;
	public SceneLoader SceneLoader;
	public GameObject endConfirmPopup;
	public GameObject mainCamera;
	public TrafficLightController[] trafficLight;

	public bool active;

	private bool isZoom;
	// Use this for initialization
	void Start () {
		isZoom = false;
		active = false;
		StartCoroutine (activeAfterSecond(1));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void onClickKeepDriving(){
		if (active) {
			soundStart.Play ();
			StartCoroutine (startMovingAfterSecond(2));
		}
	}

	public void onClickEndTest(){
		SceneLoader.loadSceneSingleMode ("Main Scene");
	}

	IEnumerator activeAfterSecond(float seconds) {
		yield return new WaitForSeconds(seconds);
		active = true;
	}

	IEnumerator startMovingAfterSecond(float seconds) {
		yield return new WaitForSeconds(seconds);
		mainCar.GetComponent<CarScript> ().startMoving ();
		if (car1 != null)
			car1.GetComponent<CarScript> ().startMoving ();
		if (car2 != null)
			car2.GetComponent<CarScript> ().startMoving ();
		transform.parent.gameObject.SetActive (false);
	}

	public void onClickContinueDriving(){
		if(car1!=null)
			car1.GetComponent<CarScript> ().continueMoving (2);
		if(car2!=null)
			car2.GetComponent<CarScript> ().continueMoving (2);
		if (trafficLight != null && trafficLight.Length > 0) {
			foreach (TrafficLightController tf in trafficLight) {
				tf.switchLightAfter (1.5f);
			}
		}
		mainCar.GetComponent<CarScript> ().continueMoving (2);
		transform.parent.gameObject.SetActive (false);
	}

	public void onClickConfirmEndtest(){
		if(car1!=null)
			car1.GetComponent<CarScript> ().isMoving = false;
		if(car2!=null)
			car2.GetComponent<CarScript> ().isMoving = false;
		mainCar.GetComponent<CarScript> ().isMoving = false;
		endConfirmPopup.SetActive (true);
	}

	public void onClickPause(){
		if (mainCar.GetComponent<CarScript> ().isMoving) {
			if (car1 != null)
				car1.GetComponent<CarScript> ().isMoving = false;
			if (car2 != null)
				car2.GetComponent<CarScript> ().isMoving = false;
			mainCar.GetComponent<CarScript> ().isMoving = false;
		} else {
			if(car1!=null)
				car1.GetComponent<CarScript> ().isMoving = true;
			if(car2!=null)
				car2.GetComponent<CarScript> ().isMoving = true;
			mainCar.GetComponent<CarScript> ().isMoving = true;
		}
	}

	public void zoom() {
		if (!isZoom) {
			mainCamera.transform.position = new Vector3 (mainCamera.transform.position.x, 110, mainCamera.transform.position.z);
			mainCamera.GetComponent<SmoothFollow> ().enabled = true;
			isZoom = true;
		} else {
			mainCamera.GetComponent<SmoothFollow> ().enabled = false;
			mainCamera.transform.position = new Vector3 (374, 217, -10);
			isZoom = false;
		}
	}
}
