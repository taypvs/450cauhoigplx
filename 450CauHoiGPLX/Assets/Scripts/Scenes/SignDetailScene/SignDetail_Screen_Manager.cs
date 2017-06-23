using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Boomlagoon.JSON;

public class SignDetail_Screen_Manager : MonoBehaviour {

	public GameObject SignLayout;
	public GameObject listContent;
	public GameObject sceneLoader;
	public LoadingIconHandler loadingIcon;
	public GameObject popupDetail;

	// Use this for initialization
	void Start () {
		loadingIcon.activeLoading ();
		StartCoroutine(initAfter (UtilsConstanst.SCENE_TRANSITION_TIME));
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (popupDetail.activeSelf) {
				popupDetail.SetActive (false);
			} else {
				sceneLoader.GetComponent<SceneLoader> ().doLoadLevelFadeIn ("List  Sign Topic Scene", 10, 0.01f);
			}
		}
	}

	private void initTopics(){
		Topic topic = new Topic (JSONObject.Parse (PreferencesUtils.getTopicSign ()));
		SmallTopic smallTopic = null;
		foreach (SmallTopic checkSmallTopic in topic.smallTopics) {
			if (checkSmallTopic.id.Equals (PreferencesUtils.getTopicIdClicked())) {
				smallTopic = checkSmallTopic;
				break;
			}
		}
		float itemPosition_Y = 0;

		for (int i = 0; i < smallTopic.contents.Length; i++) {
			GameObject newSignLayout = (GameObject)Instantiate (SignLayout, new Vector3 (0, 0, 0), Quaternion.identity);
			newSignLayout.transform.SetParent (listContent.transform, false);
			newSignLayout.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0, itemPosition_Y);
			newSignLayout.GetComponent<RectTransform> ().anchorMin = new Vector2 (0.5f, 1);
			newSignLayout.GetComponent<RectTransform> ().anchorMax = new Vector2 (0.5f, 1);

			newSignLayout.transform.Find ("Text").gameObject.GetComponent<Text> ().text = CommonMethods.reformatText(smallTopic.contents [i].title);
			itemPosition_Y = itemPosition_Y - newSignLayout.GetComponent<RectTransform> ().rect.height - 2;

			Sprite signSrpite = Resources.Load<Sprite>(smallTopic.contents[i].image);
			if(signSrpite!=null){
				newSignLayout.transform.Find ("Image").gameObject.GetComponent<Image> ().sprite = signSrpite;
			}

			newSignLayout.GetComponent<List_Sign_Detail_Btn> ().title = smallTopic.contents [i].title;
			newSignLayout.GetComponent<List_Sign_Detail_Btn> ().image = smallTopic.contents [i].image;
			newSignLayout.GetComponent<List_Sign_Detail_Btn> ().detail = smallTopic.contents [i].detail;


		}
		listContent.GetComponent<RectTransform>().sizeDelta = new Vector2 (listContent.GetComponent<RectTransform> ().rect.height, - itemPosition_Y);
		loadingIcon.deactiveLoading ();
	}

	IEnumerator initAfter(float seconds) {
		yield return new WaitForSeconds(seconds);
		initTopics ();
	}
}
