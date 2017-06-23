using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Boomlagoon.JSON;

public class TrickScene_Manager : MonoBehaviour {

	public GameObject TrickLayout;
	public GameObject TrickDetailLayout;
	public GameObject listContent;
	public GameObject sceneLoader;
	public Text debugText;
	public LoadingIconHandler loadingIcon;

	// Use this for initialization
	void Start () {
		StartCoroutine(initAfter (UtilsConstanst.SCENE_TRANSITION_TIME));
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {	
			sceneLoader.GetComponent<SceneLoader> ().doLoadLevelFadeIn ("Main Scene", 10, 0.01f);	
		}
	}

	private void initTopics(){
		Topic topic = new Topic (JSONObject.Parse (PreferencesUtils.getTopicTrick ()));
		float itemPosition_Y = 0;
		float itemPosition_Y_content = 0;

		for (int i = 0; i < topic.smallTopics.Length; i++) {
			itemPosition_Y_content = 0;
			GameObject newTrickLayout = (GameObject)Instantiate (TrickLayout, new Vector3 (0, 0, 0), Quaternion.identity);
			newTrickLayout.transform.SetParent (listContent.transform, false);
			newTrickLayout.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0, -itemPosition_Y);
			newTrickLayout.GetComponent<RectTransform> ().anchorMin = new Vector2 (0.5f, 1);
			newTrickLayout.GetComponent<RectTransform> ().anchorMax = new Vector2 (0.5f, 1);

			Transform title = newTrickLayout.transform.Find ("Title");
			itemPosition_Y_content = itemPosition_Y_content - title.gameObject.GetComponent<RectTransform> ().rect.height;
			title.Find ("Text").gameObject.GetComponent<Text> ().text = CommonMethods.reformatText(topic.smallTopics [i].title);

			for (int j = 0; j < topic.smallTopics [i].contents.Length; j++) {
				GameObject newContent = (GameObject)Instantiate (TrickDetailLayout, new Vector3 (0, 0, 0), Quaternion.identity);
				newContent.transform.SetParent (newTrickLayout.transform, false);
				newContent.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0, itemPosition_Y_content);
				newContent.GetComponent<RectTransform> ().anchorMin = new Vector2 (0.5f, 1);
				newContent.GetComponent<RectTransform> ().anchorMax = new Vector2 (0.5f, 1);
				itemPosition_Y_content = itemPosition_Y_content - newContent.GetComponent<RectTransform> ().rect.height - 5;

				newContent.transform.Find ("Text").GetComponent<Text> ().text = CommonMethods.reformatText(topic.smallTopics [i].contents [j].title);

			}
			itemPosition_Y = itemPosition_Y - itemPosition_Y_content;
			newTrickLayout.GetComponent<RectTransform>().sizeDelta = new Vector2 (newTrickLayout.GetComponent<RectTransform> ().rect.width, -itemPosition_Y_content);
		}
		listContent.GetComponent<RectTransform>().sizeDelta = new Vector2 (listContent.GetComponent<RectTransform> ().rect.height, itemPosition_Y);
	}

	IEnumerator initAfter(float seconds) {
		yield return new WaitForSeconds(seconds);
		initTopics ();
	}
}
