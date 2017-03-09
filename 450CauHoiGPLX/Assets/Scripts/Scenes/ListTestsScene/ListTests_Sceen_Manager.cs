using UnityEngine;
using System.Collections;
using Boomlagoon.JSON;

public class ListTests_Sceen_Manager : MonoBehaviour {

	private LevelQuestion levelQuestion;

	// Use this for initialization
	void Start () {
		Screen.fullScreen = false;
		levelQuestion = new LevelQuestion (JSONObject.Parse (PreferencesUtils.getJsonGroupQuestionsInLevel(PreferencesUtils.getCurrentLevelSelected())));
		Debug.Log (levelQuestion.lName);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
