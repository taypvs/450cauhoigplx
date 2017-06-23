using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Boomlagoon.JSON;

public class ListSignTopic_Sceen_Manager : MonoBehaviour {

	public GameObject SignLayout;
	public GameObject listContent;
	public GameObject sceneLoader;
	public LoadingIconHandler loadingIcon;

	// Use this for initialization
	void Start () {
		loadingIcon.activeLoading ();
		StartCoroutine(initAfter (UtilsConstanst.SCENE_TRANSITION_TIME));
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {	
			sceneLoader.GetComponent<SceneLoader> ().doLoadLevelFadeIn ("Main Scene", 10, 0.01f);	
		}
	}

	private void initTopics(){
		Topic topic = new Topic (JSONObject.Parse (PreferencesUtils.getTopicSign ()));
		float itemPosition_Y = 0;

		for (int i = 0; i < topic.smallTopics.Length; i++) {
			GameObject newSignLayout = (GameObject)Instantiate (SignLayout, new Vector3 (0, 0, 0), Quaternion.identity);
			newSignLayout.transform.SetParent (listContent.transform, false);
			newSignLayout.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0, itemPosition_Y);
			newSignLayout.GetComponent<RectTransform> ().anchorMin = new Vector2 (0.5f, 1);
			newSignLayout.GetComponent<RectTransform> ().anchorMax = new Vector2 (0.5f, 1);

			newSignLayout.transform.Find ("Text").gameObject.GetComponent<Text> ().text = CommonMethods.reformatText(topic.smallTopics [i].title);
			itemPosition_Y = itemPosition_Y - newSignLayout.GetComponent<RectTransform> ().rect.height - 2;

			newSignLayout.GetComponent<ListTopic_Screen_Btn> ().idTopic = topic.smallTopics [i].id;

		}
		listContent.GetComponent<RectTransform>().sizeDelta = new Vector2 (listContent.GetComponent<RectTransform> ().rect.height, - itemPosition_Y);
		loadingIcon.deactiveLoading ();
	}

	IEnumerator initAfter(float seconds) {
		yield return new WaitForSeconds(seconds);
		initTopics ();
	}
}
