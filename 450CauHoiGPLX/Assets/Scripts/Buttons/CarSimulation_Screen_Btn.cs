using UnityEngine;
using System.Collections;

public class CarSimulation_Screen_Btn : MonoBehaviour {

	public GameObject mainCar;
	public AudioSource soundStart;
	public GameObject car1;
	public GameObject car2;
	public SceneLoader SceneLoader;

	public bool active;
	// Use this for initialization
	void Start () {
		active = false;
		StartCoroutine (activeAfterSecond(2));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void onClickKeepDriving(){
		if (active) {
			mainCar.GetComponent<CarScript> ().startMoving ();
			if (car1 != null)
				car1.GetComponent<CarScript> ().startMoving ();
			if (car2 != null)
				car2.GetComponent<CarScript> ().startMoving ();
			soundStart.Play ();
			transform.parent.gameObject.SetActive (false);
		}
	}

	public void onClickEndTest(){
		SceneLoader.doLoadLevelFadeIn ("Main Scene", 255, 0.1f);
	}

	IEnumerator activeAfterSecond(float seconds) {
		yield return new WaitForSeconds(seconds);
		active = true;
	}
}
