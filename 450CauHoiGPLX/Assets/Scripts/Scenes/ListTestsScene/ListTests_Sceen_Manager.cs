using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Boomlagoon.JSON;

public class ListTests_Sceen_Manager : MonoBehaviour {

	public GameObject groupQuestionItem;
	public GameObject listContent;
	public GameObject sceneLoader;
	public Text debugText;
	private LevelQuestion levelQuestion;


	// Use this for initialization
	void Start () {
		Screen.fullScreen = false;
		initGroupQuestions ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape))
			sceneLoader.GetComponent<SceneLoader> ().doLoadLevelFadeIn ("Main Scene", 230, 0.1f);
	}

	private void initGroupQuestions(){
		levelQuestion = new LevelQuestion (JSONObject.Parse (PreferencesUtils.getJsonGroupQuestionsInLevel(PreferencesUtils.getCurrentLevelSelected())));

		debugText.text = levelQuestion.lName;
		float itemPosition_Y = 0;

		for(int i = 0; i < levelQuestion.groupQuestions.Length; i++){
			itemPosition_Y = itemPosition_Y - 20;
			GameObject newGroupQuestion = (GameObject)Instantiate (groupQuestionItem, new Vector3(0, 0, 0), Quaternion.identity);
			newGroupQuestion.transform.SetParent (listContent.transform, false);
			newGroupQuestion.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0, itemPosition_Y);
			newGroupQuestion.GetComponent<RectTransform> ().anchorMin = new Vector2 (0.5f, 1);
			newGroupQuestion.GetComponent<RectTransform> ().anchorMax = new Vector2 (0.5f, 1);

			itemPosition_Y = itemPosition_Y - newGroupQuestion.GetComponent<RectTransform> ().rect.height;

			// If The test has not done yet
			if (levelQuestion.groupQuestions [i].isDone.Equals ("0") || levelQuestion.groupQuestions [i].isDone.Equals ("")) {
				newGroupQuestion.transform.Find ("RightLayout").gameObject.SetActive (false);	
				newGroupQuestion.transform.Find ("WrongLayout").gameObject.SetActive (false);	
				newGroupQuestion.transform.Find ("Image").gameObject.SetActive (false);	

				newGroupQuestion.transform.Find ("DeThi_txt").GetComponent<RectTransform> ().anchoredPosition = new Vector2(50, -110);
				newGroupQuestion.transform.Find ("Arrow Icon").GetComponent<RectTransform> ().anchoredPosition = new Vector2(-50, -110);
			}
			// If The test has been done
			else {
				newGroupQuestion.transform.Find ("RightLayout").gameObject.SetActive (true);	
				newGroupQuestion.transform.Find ("WrongLayout").gameObject.SetActive (true);	
				newGroupQuestion.transform.Find ("Image").gameObject.SetActive (true);	

				newGroupQuestion.transform.Find ("DeThi_txt").GetComponent<RectTransform> ().anchoredPosition = new Vector2(50, -50);
				newGroupQuestion.transform.Find ("Arrow Icon").GetComponent<RectTransform> ().anchoredPosition = new Vector2(50, -50);

			}


			newGroupQuestion.transform.Find ("DeThi_txt").GetComponent<Text> ().text = levelQuestion.groupQuestions [i].gName;
			newGroupQuestion.GetComponent<List_Tests_Screen_Btn> ().idGroupQuestion = levelQuestion.groupQuestions [i].id;
		}
	}

	public void loadQuestionDoneAt(int index){
		if (PreferencesUtils.getGroupQuestionDone () != null && !PreferencesUtils.getGroupQuestionDone ().Equals ("")) {
			GroupQuestion groupQuestion = new GroupQuestion (PreferencesUtils.getGroupQuestionDone ());
			Debug.Log ("groupQuestion : " + groupQuestion.isDone);
		}
	}

}
