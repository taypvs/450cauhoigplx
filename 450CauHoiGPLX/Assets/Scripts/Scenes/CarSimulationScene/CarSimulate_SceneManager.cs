using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CarSimulate_SceneManager : MonoBehaviour {

	public Text text;
	public GameObject car;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		text.text = car.GetComponent<CarScript> ().currentSpeed.ToString() + " Km/h";
	}
}
