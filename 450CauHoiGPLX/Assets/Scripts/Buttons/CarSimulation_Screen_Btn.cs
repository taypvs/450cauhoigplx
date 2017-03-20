using UnityEngine;
using System.Collections;

public class CarSimulation_Screen_Btn : MonoBehaviour {

	public GameObject mainCar;
	public AudioSource soundStart;
	public GameObject car1;
	public GameObject car2;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void onClickKeepDriving(){
		mainCar.GetComponent<CarScript> ().startMoving ();
		if(car1!=null)
			car1.GetComponent<CarScript> ().startMoving ();
		if(car2!=null)
			car2.GetComponent<CarScript> ().startMoving ();
		soundStart.Play ();
		transform.parent.gameObject.SetActive (false);
	}
}
