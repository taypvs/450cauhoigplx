using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Boomlagoon.JSON;

public class ListQuestionResult_Detail_ScreenManager : MonoBehaviour {

	public GameObject swipeLayout;
	public GameObject questionLayout;
	public GameObject answerLayout;
	public GameObject sceneLoader;
	public GameObject appBackground;

	private GroupQuestion groupQuestion;

	// Use this for initialization
	void Start () {
		appBackground.transform.Find ("Header").gameObject.SetActive(true);
		string currentSelectedGroupId = PreferencesUtils.getCurrentSelectedGroupQuestion ();
		groupQuestion = new GroupQuestion (JSONObject.Parse (PreferencesUtils.getGroupQuestionDone (currentSelectedGroupId)));
		initQuestionLayout ();
		swipeLayout.GetComponent<TestSimulate_SwipeController> ().questionNumber.text = "1/" + groupQuestion.questions.Length;
		swipeLayout.GetComponent<TestSimulate_SwipeController> ().totalQuestion = groupQuestion.questions.Length;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			sceneLoader.GetComponent<SceneLoader> ().doLoadLevelFadeIn ("List Question Result", 230, 0.1f);
			PreferencesUtils.clearAnswerNumberSelect ();
		}
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
				Answer currentAnswer = groupQuestion.questions [i].answers [j];
				GameObject newAnswerLayout = (GameObject)Instantiate (answerLayout, new Vector3(0, 0, 0), Quaternion.identity);
				// Init Layout
				newAnswerLayout.transform.SetParent (currentParentLayout.transform, false);
				newAnswerLayout.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0, -20);
				newAnswerLayout.GetComponent<RectTransform> ().anchorMin = new Vector2 (0, 0);
				newAnswerLayout.GetComponent<RectTransform> ().anchorMax = new Vector2 (0, 0);
				newAnswerLayout.GetComponent<Button> ().enabled = false;

				newAnswerLayout.transform.Find ("Text").GetComponent<Text>().text = groupQuestion.questions [i].answers[j].text;
				newAnswerLayout.GetComponent<Test_Simulation_Screen_Btn> ().answer = groupQuestion.questions [i].answers [j];

				currentParentLayout = newAnswerLayout;
				if (currentAnswer.choose.Equals ("1")) {
					newAnswerLayout.transform.Find ("Image").GetComponent<Image> ().color = Color.cyan;
				}
				if (currentAnswer.correct.Equals ("1")) {
					newAnswerLayout.transform.Find ("Text").gameObject.GetComponent<Text> ().color = Color.blue;
				}
				else 
					if(currentAnswer.choose.Equals ("1"))
						newAnswerLayout.transform.Find ("Text").gameObject.GetComponent<Text> ().color = Color.red;
			}

		}

		swipeLayout.GetComponent<RectTransform> ().sizeDelta = new Vector2 (itemPosition_X, swipeLayout.GetComponent<RectTransform> ().rect.height);
		swipeLayout.GetComponent<TestSimulate_SwipeController> ().initFirstIndex ();
	}
		
}
