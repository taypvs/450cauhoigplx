using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Boomlagoon.JSON;

public class ListTests_Sceen_Manager : MonoBehaviour {

	public GameObject groupQuestionItem;
	public GameObject listContent;
	public GameObject sceneLoader;
	public Text debugText;
	public LoadingIconHandler loadingIcon;

	private LevelQuestion levelQuestion;
	private GroupQuestion groupDone;
	// Use this for initialization
	void Start () {
		load ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape))
			sceneLoader.GetComponent<SceneLoader> ().doLoadLevelFadeIn ("Main Scene", 10, 0.1f);
	}

	private void initGroupQuestions(){
		clearAllChild ();

		levelQuestion = new LevelQuestion (JSONObject.Parse (PreferencesUtils.getJsonGroupQuestionsInLevel(PreferencesUtils.getCurrentLevelSelected())));

		debugText.text = levelQuestion.lName;
		float itemPosition_Y = 0;

		for(int i = 0; i < levelQuestion.groupQuestions.Length; i++){
			if (levelQuestion.groupQuestions [i].type.Equals("1")) {
				itemPosition_Y = itemPosition_Y - 20;
				GameObject newGroupQuestion = (GameObject)Instantiate (groupQuestionItem, new Vector3 (0, 0, 0), Quaternion.identity);
				newGroupQuestion.transform.SetParent (listContent.transform, false);
				newGroupQuestion.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0, itemPosition_Y);
				newGroupQuestion.GetComponent<RectTransform> ().anchorMin = new Vector2 (0.5f, 1);
				newGroupQuestion.GetComponent<RectTransform> ().anchorMax = new Vector2 (0.5f, 1);

				itemPosition_Y = itemPosition_Y - newGroupQuestion.GetComponent<RectTransform> ().rect.height;

				// If The test has not done yet
				if (!(loadQuestionDoneAt (i))) {

					newGroupQuestion.transform.Find ("RightLayout").gameObject.SetActive (false);	
					newGroupQuestion.transform.Find ("WrongLayout").gameObject.SetActive (false);	
					newGroupQuestion.transform.Find ("Image").gameObject.SetActive (false);	

					newGroupQuestion.transform.Find ("DeThi_txt").GetComponent<RectTransform> ().anchoredPosition = new Vector2 (50, -110);
					newGroupQuestion.transform.Find ("Arrow Icon").GetComponent<RectTransform> ().anchoredPosition = new Vector2 (-50, -110);

					newGroupQuestion.GetComponent<List_Tests_Screen_Btn> ().isDone = levelQuestion.groupQuestions [i].isDone;
				}
				// If The test has been done
				else {
				
					newGroupQuestion.transform.Find ("RightLayout").gameObject.SetActive (true);	
					newGroupQuestion.transform.Find ("WrongLayout").gameObject.SetActive (true);	
					newGroupQuestion.transform.Find ("Image").gameObject.SetActive (true);	

					newGroupQuestion.transform.Find ("DeThi_txt").GetComponent<RectTransform> ().anchoredPosition = new Vector2 (50, -50);
					newGroupQuestion.transform.Find ("Arrow Icon").GetComponent<RectTransform> ().anchoredPosition = new Vector2 (-50, -50);

					newGroupQuestion.transform.Find ("RightLayout").Find ("Right Answers Txt").GetComponent<Text> ().text = groupDone.numQuestionRight ().ToString ();
					newGroupQuestion.transform.Find ("WrongLayout").Find ("Wrong Answers Txt").GetComponent<Text> ().text = groupDone.numQuestionWrong ().ToString ();

					newGroupQuestion.GetComponent<List_Tests_Screen_Btn> ().isDone = groupDone.isDone;
				}
				newGroupQuestion.transform.Find ("DeThi_txt").GetComponent<Text> ().text = CommonMethods.getGroupQuestionName (levelQuestion.groupQuestions [i].gName);
				newGroupQuestion.GetComponent<List_Tests_Screen_Btn> ().idGroupQuestion = levelQuestion.groupQuestions [i].id;
			}

		}
		listContent.GetComponent<RectTransform>().sizeDelta = new Vector2 (listContent.GetComponent<RectTransform> ().rect.width, -itemPosition_Y);
		loadingIcon.deactiveLoading ();
	}

	private bool loadQuestionDoneAt(int index){
		if (PreferencesUtils.getGroupQuestionDone (levelQuestion.groupQuestions[index].id) != null && !PreferencesUtils.getGroupQuestionDone (levelQuestion.groupQuestions[index].id).Equals ("")) {
			groupDone = new GroupQuestion (JSONObject.Parse (PreferencesUtils.getGroupQuestionDone (levelQuestion.groupQuestions[index].id)));
			if(groupDone.isDone.Equals("1"))
				return true;	
		}
		return false;
	}

	IEnumerator initAfter(float seconds) {
		yield return new WaitForSeconds(seconds);
		initGroupQuestions ();
	}
		
	public void load() {
		PreferencesUtils.clearAnswerNumberSelect ();
		loadingIcon.activeLoading ();
		GameObject.Find ("Header Title").GetComponent<Text>().text = "Danh sách đề thi";
		StartCoroutine(initAfter (UtilsConstanst.SCENE_TRANSITION_TIME));
	}

	private void clearAllChild () {
		foreach (Transform child in listContent.transform) {
			GameObject.Destroy(child.gameObject);
		}
	}
}