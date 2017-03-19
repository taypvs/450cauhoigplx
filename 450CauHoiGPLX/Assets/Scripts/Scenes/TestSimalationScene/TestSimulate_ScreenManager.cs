using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Boomlagoon.JSON;

public class TestSimulate_ScreenManager : MonoBehaviour {

	public GameObject swipeLayout;
	public GameObject questionLayout;
	public GameObject answerLayout;
	public GameObject sceneLoader;
	public GameObject appBackground;
	public GameObject timeManager;

	private GroupQuestion groupQuestion;

	// Use this for initialization
	void Start () {
		appBackground.transform.Find ("Header").gameObject.SetActive(false);
		appBackground.transform.Find ("HeaderTest").gameObject.SetActive(true);
		LevelQuestion levelQuestion = new LevelQuestion (JSONObject.Parse (PreferencesUtils.getJsonGroupQuestionsInLevel(PreferencesUtils.getCurrentLevelSelected())));
		groupQuestion = levelQuestion.getGroupQuestionById (PreferencesUtils.getCurrentSelectedGroupQuestion ());
		initQuestionLayout ();
		swipeLayout.GetComponent<TestSimulate_SwipeController> ().questionNumber.text = "1/" + groupQuestion.questions.Length;
		swipeLayout.GetComponent<TestSimulate_SwipeController> ().totalQuestion = groupQuestion.questions.Length;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape))
			sceneLoader.GetComponent<SceneLoader> ().doLoadLevelFadeIn ("List Tests Scene", 230, 0.1f);
	}

	private void initQuestionLayout(){
		float itemPosition_X = 0;

		for(int i = 0; i < groupQuestion.questions.Length; i++){
			GameObject newQuestion = (GameObject)Instantiate (questionLayout, new Vector3(0, 0, 0), Quaternion.identity);

			// Init Layout
			newQuestion.transform.SetParent (swipeLayout.transform, false);
			newQuestion.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (itemPosition_X, 0);
			newQuestion.GetComponent<RectTransform> ().anchorMin = new Vector2 (0, 0.5f);
			newQuestion.GetComponent<RectTransform> ().anchorMax = new Vector2 (0, 0.5f);

			itemPosition_X += newQuestion.GetComponent<RectTransform> ().rect.width;


			// Init Text
			newQuestion.transform.Find ("QuestionInnerLayout").Find ("Question Number Txt").GetComponent<Text> ().text = "Câu hỏi " + (i + 1);
			newQuestion.transform.Find ("QuestionInnerLayout").Find ("Question Txt").GetComponent<Text> ().text = groupQuestion.questions[i].qName;

			GameObject currentParentLayout = newQuestion.transform.Find("QuestionInnerLayout").Find("Question Txt").gameObject;

			// Init Answer
			for (int j = 0; j < groupQuestion.questions [i].answers.Length; j++) {
				GameObject newAnswerLayout = (GameObject)Instantiate (answerLayout, new Vector3(0, 0, 0), Quaternion.identity);
				// Init Layout
				newAnswerLayout.transform.SetParent (currentParentLayout.transform, false);
				newAnswerLayout.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0, -20);
				newAnswerLayout.GetComponent<RectTransform> ().anchorMin = new Vector2 (0, 0);
				newAnswerLayout.GetComponent<RectTransform> ().anchorMax = new Vector2 (0, 0);

				newAnswerLayout.transform.Find ("Text").GetComponent<Text>().text = groupQuestion.questions [i].answers[j].text;
				newAnswerLayout.GetComponent<Test_Simulation_Screen_Btn> ().answer = groupQuestion.questions [i].answers [j];

				currentParentLayout = newAnswerLayout;
			}

		}

		swipeLayout.GetComponent<RectTransform> ().sizeDelta = new Vector2 (itemPosition_X, swipeLayout.GetComponent<RectTransform> ().rect.height);
	}

	public void checkAnswer(int index){
		groupQuestion.questions [index].result = "0";
		for (int i = 0; i < groupQuestion.questions [index].answers.Length; i++) {
			if (groupQuestion.questions [index].answers [i].choose.Equals ("1")) {
				if (groupQuestion.questions [index].answers [i].correct.Equals ("1")) {
					getAnswerLayoutFromIndex (currentQuestionLayout (index), i).transform.Find ("Text").GetComponent<Text> ().color = Color.blue;
					getAnswerLayoutFromIndex (currentQuestionLayout (index), i).transform.Find ("Text").GetComponent<Text> ().fontStyle = FontStyle.Bold;
					if(groupQuestion.questions [index].result.Equals("0"))
						groupQuestion.questions [index].result = "2";
				} else {
					getAnswerLayoutFromIndex (currentQuestionLayout (index), i).transform.Find ("Text").GetComponent<Text> ().color = Color.red;
					groupQuestion.questions [index].result = "1";
				}
			} else {
				if (groupQuestion.questions [index].answers [i].correct.Equals ("1")) {
					getAnswerLayoutFromIndex (currentQuestionLayout (index), i).transform.Find ("Text").GetComponent<Text> ().color = Color.blue;
					groupQuestion.questions [index].result = "1";
				}
			}
			getAnswerLayoutFromIndex (currentQuestionLayout (index), i).GetComponent<Button>().enabled = false;
		}
	}

	public GameObject currentQuestionLayout(int index){
		return swipeLayout.transform.GetChild (index).Find ("QuestionInnerLayout").Find ("Question Txt").gameObject;
	}

	public GameObject getAnswerLayoutFromIndex(GameObject parent, int index){
		if (index == 0)
			return parent.transform.Find ("AnswerLayout(Clone)").gameObject;
		else {
			return getAnswerLayoutFromIndex (parent.transform.Find ("AnswerLayout(Clone)").gameObject, --index);
		}
	}

	public void endTest(){
		groupQuestion.isDone = "1";
		for (int i = 0; i < groupQuestion.questions.Length; i++) {
			if (groupQuestion.questions [i].result.Equals ("null")) {
				checkAnswer (i);
			}
		}
		PreferencesUtils.saveGroupQuestionDone (groupQuestion.id, JsonParser.groupQuestionToJson(groupQuestion));
		PreferencesUtils.clearCurrentSelectedGroupQuestion ();
		sceneLoader.GetComponent<SceneLoader> ().doLoadLevelFadeIn ("List Tests Scene", 255, 0.1f);
	}
}
