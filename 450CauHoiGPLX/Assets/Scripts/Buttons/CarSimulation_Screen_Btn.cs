using UnityEngine;
using System.Collections;

public class CarSimulation_Screen_Btn : MonoBehaviour {

	public GameObject car;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void onClickKeepDriving(){
		car.GetComponent<CarScript> ().moveToNextPoint ();
		transform.parent.gameObject.SetActive (false);
	}
}
