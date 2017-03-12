using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CarSimulate_SceneManager : MonoBehaviour {

	public Text text;
	public GameObject mainCar;
	public GameObject sceneLoader;
	public GameObject popupStart;
	public AudioSource soundWelcome;

	// Use this for initialization
	void Start () {
		sceneLoader.GetComponent<SceneLoader> ().onLoadSceneFadeIn ();
		StartCoroutine (sayWelcome());
	}
	
	// Update is called once per frame
	void Update () {
		text.text = mainCar.GetComponent<CarScript> ().currentSpeed.ToString() + " Km/h";

		if (Input.GetKeyDown (KeyCode.Escape))
			sceneLoader.GetComponent<SceneLoader> ().doLoadLevelFadeIn ("Main Scene", 230, 0.3f);
	}

	IEnumerator sayWelcome () {
		yield return new WaitForSeconds(0.4f);
		soundWelcome.Play ();
		popupStart.SetActive (true);
	}
}
