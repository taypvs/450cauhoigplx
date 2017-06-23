using UnityEngine;
using System.Collections;
using Boomlagoon.JSON;
using UnityEngine.UI;

public class MainScene_ApiQuestionsLoader_Controller : MonoBehaviour {

	public ListAllQuestionsWs listAllQuestionWs;
	public ListAllTopicsWs listAllTopicWs;
	public Text debugText;
	public LoadingIconHandler loadingIcon;
	public GameObject sceneLoader;

	private System.Action onCompleteQuestionWs;
	private System.Action onCompleteTopicWs;

	// Use this for initialization
	void Start () {
		Screen.fullScreen = false;
		//debugText.text = PreferencesUtils.getCurrentLevelSelected ();
		//PreferencesUtils.setCurrentLevelSelected (PreferencesUtils.LEVEL_DRIVER_TYPE_A);
		onCompleteQuestionWs = onCompleteApiQuestion;
		onCompleteTopicWs = onCompleteApiTopic;

		loadingIcon.activeLoading ();
		listAllTopicWs.initialize ();
		listAllQuestionWs.initialize();
		listAllQuestionWs.doGetListQuestion (onCompleteQuestionWs);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void onCompleteApiQuestion(){
		if(PreferencesUtils.getCurrentLevelSelected ()==null || PreferencesUtils.getCurrentLevelSelected ().Equals(""))
			PreferencesUtils.setCurrentLevelSelected (PreferencesUtils.LEVEL_DRIVER_TYPE_A);
		
		JSONArray jsonArray = null;
		Debug.Log ("Is Error API : " + listAllQuestionWs.httpApiLoader.isError );
		if (!listAllQuestionWs.httpApiLoader.isError) {
			jsonArray = JSONArray.Parse (listAllQuestionWs.httpApiLoader.results);
			StartCoroutine (WaitForParsingQuestions(jsonArray));
		}
		else {
			if (PreferencesUtils.getJsonGroupQuestionsInLevel (PreferencesUtils.getCurrentLevelSelected ()) != null
			    && !PreferencesUtils.getJsonGroupQuestionsInLevel (PreferencesUtils.getCurrentLevelSelected ()).Equals ("")) {
				// Already saved
				Debug.Log ("Is Error API : Already saved ");
			} else {
				Debug.Log ("Is Error API : loadInitJsonQuestion ");
				jsonArray = JSONArray.Parse (CommonMethods.loadInitJsonQuestion ());
				StartCoroutine (WaitForParsingQuestions (jsonArray));
			}
		}
		//AllLevel allLv = new AllLevel(jsonArray);


		//loadingIcon.deactiveLoading ();
		listAllTopicWs.doGetListTopic (onCompleteTopicWs);
	}

	private void onCompleteApiTopic(){
		JSONArray jsonArray = null;
		Debug.Log ("Is Error API : " + listAllTopicWs.httpApiLoader.isError );
		if (!listAllTopicWs.httpApiLoader.isError) {
			jsonArray = JSONArray.Parse (listAllTopicWs.httpApiLoader.results);
			StartCoroutine (WaitForParsingTopics(jsonArray));
		}
		else {
			if (PreferencesUtils.getTopicSign() != null
				&& !PreferencesUtils.getTopicSign().Equals ("")) {
				// Already saved
				Debug.Log ("Is Error API : Already saved ");
			} else {
				Debug.Log ("Is Error API : loadInitJsonTopic ");
				jsonArray = JSONArray.Parse (CommonMethods.loadInitJsonTopic());
				StartCoroutine (WaitForParsingTopics (jsonArray));
			}
		}
		//AllLevel allLv = new AllLevel(jsonArray);


		//loadingIcon.deactiveLoading ();
		sceneLoader.GetComponent<SceneLoader> ().loadSceneSingleMode ("Main Scene");
	}

	private IEnumerator WaitForParsingQuestions(JSONArray jsonArray) {
		AllLevel allLv = new AllLevel(jsonArray);
		yield return allLv;
		// check for errors
		if (allLv == null) {
			
		} else {
			Debug.Log ("Parsing Done");
//			debugText.text = "onCompleteApi => " + allLv.levels[0].lName;
		}
	}

	private IEnumerator WaitForParsingTopics(JSONArray jsonArray) {
		AllTopic allTp = new AllTopic(jsonArray);
		yield return allTp;
		// check for errors
		if (allTp == null) {

		} else {
			Debug.Log ("Parsing Done");
			//			debugText.text = "onCompleteApi => " + allLv.levels[0].lName;
		}
	}
}
