using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Test_Simulation_Screen_Btn : MonoBehaviour {

	public GameObject swipe;
	public Answer answer;
	public Question question;
	public GameObject screenManager;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void onClickSwipeToLeft(){
		swipe.GetComponent<TestSimulate_SwipeController> ().swipeToLeft ();
	}

	public void onClickSwipeToRight(){
		swipe.GetComponent<TestSimulate_SwipeController> ().swipeToRight ();
	}

	public void onClickChooseAnswer(){
		if (answer.choose.Equals ("0")) {
			answer.choose = "1";
			transform.Find ("Image").GetComponent<Image> ().color = Color.red;
		} else {
			answer.choose = "0";
			transform.Find ("Image").GetComponent<Image> ().color = new Color32 (0, 0, 0, 0);
		}
	}

	public void onClickSeeResult(){
		screenManager.GetComponent<TestSimulate_ScreenManager> ().checkAnswer (swipe.GetComponent<TestSimulate_SwipeController> ().index);
	}
}
