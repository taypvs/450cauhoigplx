using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Boomlagoon.JSON;

public class ListQuestionDone_ScreenManager : MonoBehaviour {

	public GameObject scrollContent;
	public GameObject resultLayout;
	public GameObject sceneLoader;
	public Text timeTxt;
	public Text resultTxt;
	public Text passTxt;
	public Text totalTxt;
	public Text totalRightTxt;
	public Text totalWrongTxt;

	public Sprite rightIco;
	public Sprite wrongIco;
	private GroupQuestion groupDone;
	// Use this for initialization
	void Start () {
		string currentSelectedGroupId = PreferencesUtils.getCurrentSelectedGroupQuestion ();
		groupDone = new GroupQuestion (JSONObject.Parse (PreferencesUtils.getGroupQuestionDone (currentSelectedGroupId)));
		initResults ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			sceneLoader.GetComponent<SceneLoader> ().doLoadLevelFadeIn ("List Tests Scene", 230, 0.05f);
			PreferencesUtils.clearCurrentSelectedGroupQuestion ();
		}
	}

	private void initResults(){
		float itemPosition_X = 0;
		float itemPosition_Y = 0;

		initTopText ();

		for (int i = 0; i < groupDone.questions.Length; i++) {
			GameObject newResultLayout = (GameObject)Instantiate (resultLayout, new Vector3(0, 0, 0), Quaternion.identity);

			// Init Layout
			itemPosition_X = ((i % 4) * (newResultLayout.GetComponent<RectTransform> ().rect.width + 40) + 40);
			itemPosition_Y = -1 * ((i / 4) * (newResultLayout.GetComponent<RectTransform> ().rect.height + 40) + 40);
			newResultLayout.transform.SetParent (scrollContent.transform, false);
			newResultLayout.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (itemPosition_X, itemPosition_Y);
			newResultLayout.GetComponent<RectTransform> ().anchorMin = new Vector2 (0, 1f);
			newResultLayout.GetComponent<RectTransform> ().anchorMax = new Vector2 (0, 1f);

			// Init Info
			newResultLayout.transform.Find("Name").gameObject.GetComponent<Text>().text = "Câu " + (i+1);
			if(groupDone.questions[i].result.Equals("2"))
				newResultLayout.transform.Find("Icon").gameObject.GetComponent<Image>().sprite = rightIco;
			else if (groupDone.questions[i].result.Equals("1"))
				newResultLayout.transform.Find("Icon").gameObject.GetComponent<Image>().sprite = wrongIco;
			newResultLayout.GetComponent<List_Question_Result_Btn> ().index = i;
		}
	}

	private void initTopText(){
		timeTxt.text = CommonMethods.secondsToMMSS(int.Parse(groupDone.timeDone));
		resultTxt.text = groupDone.numQuestionRight () + "/" + groupDone.questions.Length;
		if (groupDone.numQuestionWrong() < 5) {
			passTxt.text = "ĐẠT";
		} else {
			passTxt.text = "KHÔNG ĐẠT";
		}
		totalTxt.text = groupDone.questions.Length.ToString ();
		totalRightTxt.text = groupDone.numQuestionRight ().ToString ();
		totalWrongTxt.text = groupDone.numQuestionWrong ().ToString ();
	}
}
