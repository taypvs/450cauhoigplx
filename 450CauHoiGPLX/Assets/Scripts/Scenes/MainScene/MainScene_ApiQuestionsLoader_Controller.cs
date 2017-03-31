using UnityEngine;
using System.Collections;
using Boomlagoon.JSON;
using UnityEngine.UI;

public class MainScene_ApiQuestionsLoader_Controller : MonoBehaviour {

	public ListAllQuestionsWs listAllQuestionWs;
	public Text debugText;
	public LoadingIconHandler loadingIcon;

	private System.Action onComplete;

	// Use this for initialization
	void Start () {
		Screen.fullScreen = false;
		debugText.text = PreferencesUtils.getCurrentLevelSelected ();
		//PreferencesUtils.setCurrentLevelSelected (PreferencesUtils.LEVEL_DRIVER_TYPE_A);
		onComplete = onCompleteApi;

		loadingIcon.activeLoading ();
		listAllQuestionWs.initialize();
		listAllQuestionWs.doGetListQuestion (onComplete);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void onCompleteApi(){
		JSONArray jsonArray = JSONArray.Parse (listAllQuestionWs.httpApiLoader.results);
		//AllLevel allLv = new AllLevel(jsonArray);
		StartCoroutine (WaitForParsing(jsonArray));
		loadingIcon.deactiveLoading ();
		//PreferencesUtils.setCurrentLevelSelected (PreferencesUtils.LEVEL_DRIVER_TYPE_A);
		//Debug.Log ("Result : " + listAllQuestionWs.httpApiLoader.results);
	}

	private IEnumerator WaitForParsing(JSONArray jsonArray) {
		AllLevel allLv = new AllLevel(jsonArray);
		yield return allLv;
		// check for errors
		if (allLv == null) {
			
		} else {
			Debug.Log ("Parsing Done");
			debugText.text = "onCompleteApi => " + allLv.levels[0].lName;
		}
	}
}
