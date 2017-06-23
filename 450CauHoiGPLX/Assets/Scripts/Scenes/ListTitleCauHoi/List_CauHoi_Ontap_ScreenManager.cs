using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Boomlagoon.JSON;

public class List_CauHoi_Ontap_ScreenManager : MonoBehaviour {

	public GameObject groupQuestionItem;
	public GameObject listContent;
	public SceneLoader sceneLoader;
	public LoadingIconHandler loadingIcon;
	LevelQuestion levelQuestion;

	// Use this for initialization
	void Start () {
		PreferencesUtils.clearAnswerNumberSelect ();
		Screen.fullScreen = false;
		loadingIcon.activeLoading ();
		GameObject.Find ("Header Title").GetComponent<Text>().text = "Danh sách đề thi";
		StartCoroutine(initAfter (UtilsConstanst.SCENE_TRANSITION_TIME));
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			sceneLoader.GetComponent<SceneLoader> ().doLoadLevelFadeIn ("Main Scene", 10, 0.01f);
			PreferencesUtils.clearAnswerNumberSelect ();
		}
	}

	private void initGroupQuestions(){
		levelQuestion = new LevelQuestion (JSONObject.Parse (PreferencesUtils.getJsonGroupQuestionsInLevel(PreferencesUtils.getCurrentLevelSelected())));

		float itemPosition_Y = 0;
		int index = 1;
		for(int i = 0; i < levelQuestion.groupQuestions.Length; i++){
			if (levelQuestion.groupQuestions [i].type.Equals("0")) {
				itemPosition_Y = itemPosition_Y;
				GameObject newGroupQuestion = (GameObject)Instantiate (groupQuestionItem, new Vector3 (0, 0, 0), Quaternion.identity);
				newGroupQuestion.transform.SetParent (listContent.transform, false);
				newGroupQuestion.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0, itemPosition_Y);
				newGroupQuestion.GetComponent<RectTransform> ().anchorMin = new Vector2 (0.5f, 1);
				newGroupQuestion.GetComponent<RectTransform> ().anchorMax = new Vector2 (0.5f, 1);

				itemPosition_Y = itemPosition_Y - newGroupQuestion.GetComponent<RectTransform> ().rect.height - 20;


				newGroupQuestion.transform.Find ("Text").GetComponent<Text> ().text = index + ". " + CommonMethods.getGroupQuestionName (levelQuestion.groupQuestions [i].gName);
				index++;
				newGroupQuestion.GetComponent<List_Cau_Hoi_Screen_Btn> ().nameGroupQuestion = levelQuestion.groupQuestions [i].gName;
			}

		}
		listContent.GetComponent<RectTransform>().sizeDelta = new Vector2 (listContent.GetComponent<RectTransform> ().rect.height, -itemPosition_Y);
		loadingIcon.deactiveLoading ();
	}

	IEnumerator initAfter(float seconds) {
		yield return new WaitForSeconds(seconds);
		initGroupQuestions ();
	}
}
