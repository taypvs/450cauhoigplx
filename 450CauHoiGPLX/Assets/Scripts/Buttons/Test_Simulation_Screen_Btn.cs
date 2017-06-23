using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Test_Simulation_Screen_Btn : MonoBehaviour {

	public GameObject swipe;
	public Answer answer;
	public Question question;
	public GameObject screenManager;
	public GameObject popup;


	public Sprite iconCheck;
	public Sprite iconUncheck;

	public bool isLock;
	// Use this for initialization
	void Start () {
		isLock = false;
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
				transform.Find ("Image").GetComponent<Image> ().sprite = iconCheck;
			} else {
				answer.choose = "0";
				transform.Find ("Image").GetComponent<Image> ().sprite = iconUncheck;
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

	public void onClickTurnOnPopupEndTest(){
		if (!isLock)
			popup.SetActive (true);
	}

	public void onClickTurnOffPopup(){
		if (!isLock)
			transform.parent.parent.gameObject.SetActive (false);
	}
}
