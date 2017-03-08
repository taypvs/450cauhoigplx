using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CarSimulate_SceneManager : MonoBehaviour {

	public Text text;
	public GameObject car;
	public GameObject sceneLoader;
	// Use this for initialization
	void Start () {
		sceneLoader.GetComponent<SceneLoader> ().onLoadSceneFadeIn ();
	}
	
	// Update is called once per frame
	void Update () {
		text.text = car.GetComponent<CarScript> ().currentSpeed.ToString() + " Km/h";
	}
}
