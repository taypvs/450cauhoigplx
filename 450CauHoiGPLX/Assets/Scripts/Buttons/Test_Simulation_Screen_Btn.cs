using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Test_Simulation_Screen_Btn : MonoBehaviour {

	public GameObject swipe;
	public Answer answer;
	public Question question;
	public GameObject screenManager;
	public bool isLock;
	// Use this for initialization
	void Start () {
		isLock = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void onClickSwipeToLeft(){
		if(!isLock)
			swipe.GetComponent<TestSimulate_SwipeController> ().swipeToLeft ();
	}

	public void onClickSwipeToRight(){
		if(!isLock)
			swipe.GetComponent<TestSimulate_SwipeController> ().swipeToRight ();
	}

	public void onClickChooseAnswer(){
		if(!isLock)
			if (answer.choose.Equals ("0")) {
				answer.choose = "1";
				transform.Find ("Image").GetComponent<Image> ().color = Color.red;
			} else {
				answer.choose = "0";
				transform.Find ("Image").GetComponent<Image> ().color = new Color32 (0, 0, 0, 0);
			}
	}

	public void onClickSeeResult(){
		if(!isLock)
			screenManager.GetComponent<TestSimulate_ScreenManager> ().checkAnswer (swipe.GetComponent<TestSimulate_SwipeController> ().index);
	}

	public void onClickEndTest(){
		if(!isLock)
			screenManager.GetComponent<TestSimulate_ScreenManager> ().endTest ();
	}
}
