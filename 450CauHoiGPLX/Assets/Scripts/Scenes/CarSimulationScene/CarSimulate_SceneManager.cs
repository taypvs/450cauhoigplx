using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CarSimulate_SceneManager : MonoBehaviour {

	public Text text;
	public GameObject mainCar;
	public GameObject car1;
	public GameObject car2;
	public GameObject sceneLoader;
	public GameObject popupStart;
	public GameObject popupEndTest;
	public AudioSource soundWelcome;

	// Use this for initialization
	void Start () {
		sceneLoader.GetComponent<SceneLoader> ().onLoadSceneFadeIn ();
		StartCoroutine (sayWelcome());
	}
	
	// Update is called once per frame
	void Update () {
		text.text = mainCar.GetComponent<CarScript> ().currentSpeed.ToString() + " Km/h";

		if (Input.GetKeyDown (KeyCode.Escape)) {
			car1.GetComponent<CarScript> ().isMoving = false;
			car2.GetComponent<CarScript> ().isMoving = false;
			mainCar.GetComponent<CarScript> ().isMoving = false;
			popupEndTest.SetActive (true);
		}
	}

	IEnumerator sayWelcome () {
		yield return new WaitForSeconds(0.4f);
		soundWelcome.Play ();
		popupStart.SetActive (true);
	}
}
