using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Boomlagoon.JSON;

public class List_CauHoi_Detail_ScreenManager : MonoBehaviour {

	public GameObject swipeLayout;
	public GameObject questionLayout;
	public GameObject answerLayout;
	public GameObject sceneLoader;
	public GameObject appBackground;
	public Text numQuestionText;
	public Sprite iconCheck;
	public Sprite iconUnCheck;
	public LoadingIconHandler loading;

	private GroupQuestion groupQuestion;
	private bool isInited;

	// Use this for initialization
	void Start () {
		isInited = false;
		appBackground.transform.Find ("Header").gameObject.SetActive(true);
		loading.activeLoading ();
		StartCoroutine(initAfter (UtilsConstanst.SCENE_TRANSITION_TIME));

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			sceneLoader.GetComponent<SceneLoader> ().doLoadLevelFadeIn ("List Cau Hoi On Tap", 10, 0.01f);
			PreferencesUtils.clearAnswerNumberSelect ();
		}

		if (isInited) {
			if (numQuestionText != null && groupQuestion != null)
				numQuestionText.text = (swipeLayout.GetComponent<TestSimulate_SwipeController> ().index + 1) + "/" + groupQuestion.questions.Length;
		}
	}

	IEnumerator initQuestionLayout(){
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
			Transform contentLayout = newQuestion.transform.Find ("QuestionInnerLayout").Find("Viewport").Find("Content");
			contentLayout.Find ("Question Number Txt").GetComponent<Text> ().text = "Câu hỏi " + (i + 1);
			contentLayout.Find ("Question Txt").GetComponent<Text> ().text = groupQuestion.questions[i].qName;

			float imageHeight = 0;
			Sprite questionSrpite = Resources.Load<Sprite>("test_" + groupQuestion.questions[i].position);
			if(questionSrpite!=null){
				Debug.Log ("Load questionSrpite");
				contentLayout.Find ("Question Txt").Find ("Image").gameObject.GetComponent<Image> ().sprite = questionSrpite;
				contentLayout.Find ("Question Txt").Find ("Image").gameObject.GetComponent<QuestionImageHandler> ().scaleToSprite ();
				imageHeight = contentLayout.Find ("Question Txt").Find ("Image").gameObject.GetComponent<RectTransform> ().sizeDelta.y;
			}


			GameObject currentParentLayout = contentLayout.Find("Question Txt").gameObject;

			// Init Answer
			for (int j = 0; j < groupQuestion.questions [i].answers.Length; j++) {
				Answer currentAnswer = groupQuestion.questions [i].answers [j];
				GameObject newAnswerLayout = (GameObject)Instantiate (answerLayout, new Vector3(0, 0, 0), Quaternion.identity);

				// Init Layout
				if (j != 0 || imageHeight == 0)
					imageHeight = -20;
				else
					imageHeight = -20 - imageHeight - 50;
				newAnswerLayout.transform.SetParent (currentParentLayout.transform, false);
				newAnswerLayout.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0, imageHeight);
				newAnswerLayout.GetComponent<RectTransform> ().anchorMin = new Vector2 (0, 0);
				newAnswerLayout.GetComponent<RectTransform> ().anchorMax = new Vector2 (0, 0);
				newAnswerLayout.GetComponent<Button> ().enabled = false;

				newAnswerLayout.transform.Find ("Text").GetComponent<Text>().text = CommonMethods.reformatText(groupQuestion.questions [i].answers[j].text);
				newAnswerLayout.GetComponent<Test_Simulation_Screen_Btn> ().answer = groupQuestion.questions [i].answers [j];

				if (currentAnswer.correct.Equals ("1")) {
					newAnswerLayout.transform.Find ("Image").GetComponent<Image> ().sprite = iconCheck;
				} else if (currentAnswer.correct.Equals ("0")) {
					newAnswerLayout.transform.Find ("Image").GetComponent<Image> ().sprite = iconUnCheck;
				}
				currentParentLayout = newAnswerLayout;
			}

			contentLayout.gameObject.GetComponent<QuestionScrollContentHandler> ().calculateExpandArea ();
			yield return new WaitForSeconds(2/groupQuestion.questions.Length * 0.1f);
		}

		swipeLayout.GetComponent<RectTransform> ().sizeDelta = new Vector2 (itemPosition_X, swipeLayout.GetComponent<RectTransform> ().rect.height);
		swipeLayout.GetComponent<TestSimulate_SwipeController> ().initFirstIndex ();
		loading.deactiveLoading ();
	}

	IEnumerator initAfter(float seconds) {
		yield return new WaitForSeconds(seconds);
		LevelQuestion levelQuestion = new LevelQuestion (JSONObject.Parse (PreferencesUtils.getJsonGroupQuestionsInLevel(PreferencesUtils.getCurrentLevelSelected())));
		//groupQuestion = levelQuestion.getGroupQuestionById (PreferencesUtils.getCurrentSelectedGroupQuestion ());
		groupQuestion = levelQuestion.getGroupQuestionInrangeByName(PreferencesUtils.getCurrentSelectedGroupQuestion ());
		appBackground.transform.Find ("Header").Find ("Header Title").gameObject.GetComponent<Text> ().text = CommonMethods.getGroupQuestionName(PreferencesUtils.getCurrentSelectedGroupQuestion ());
		StartCoroutine(initQuestionLayout ());
		if(swipeLayout.GetComponent<TestSimulate_SwipeController> ().questionNumber!=null)
			swipeLayout.GetComponent<TestSimulate_SwipeController> ().questionNumber.text = "1/" + groupQuestion.questions.Length;
		if(swipeLayout.GetComponent<TestSimulate_SwipeController> ().totalQuestion!=null)
			swipeLayout.GetComponent<TestSimulate_SwipeController> ().totalQuestion = groupQuestion.questions.Length;

		isInited = true;

	}
}
