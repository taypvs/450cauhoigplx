using UnityEngine;
using System.Collections;
using Boomlagoon.JSON;
using UnityEngine.UI;

public class MainScene_ApiQuestionsLoader_Controller : MonoBehaviour {

	public ListAllQuestionsWs listAllQuestionWs;
	public Text debugText;
	private System.Action onComplete;

	// Use this for initialization
	void Start () {
		Screen.fullScreen = false;
		debugText.text = PreferencesUtils.getCurrentLevelSelected ();
		onComplete = onCompleteApi;
		listAllQuestionWs.initialize();
		listAllQuestionWs.doGetListQuestion (onComplete);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void onCompleteApi(){
		JSONArray jsonArray = JSONArray.Parse (listAllQuestionWs.httpApiLoader.results);
		AllLevel allLv = new AllLevel(jsonArray);
		PreferencesUtils.setCurrentLevelSelected ("A1");
		Debug.Log ("Result : " + listAllQuestionWs.httpApiLoader.results);
	}
}
