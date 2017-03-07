using UnityEngine;
using System.Collections;
using Boomlagoon.JSON;

public class MainScene_ApiQuestionsLoader_Controller : MonoBehaviour {

	private System.Action onComplete;
	public ListAllQuestionsWs listAllQuestionWs;

	// Use this for initialization
	void Start () {
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
		Debug.Log ("Result : " + listAllQuestionWs.httpApiLoader.results);
	}
}
