using UnityEngine;
using System.Collections;

public class MainScene_Screen_Manager : MonoBehaviour {

	public Main_Screen_Btn mainSceneBtn;

	// Use this for initialization
	void Start () {
		PlayerPrefs.DeleteAll ();
		Screen.fullScreen = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (mainSceneBtn.isOpenPopup) {
				mainSceneBtn.PopupA.SetActive (false);
				mainSceneBtn.PopupB.SetActive (false);
				mainSceneBtn.isOpenPopup = false;
			}
			else
				Application.Quit ();
		}
	}
}
