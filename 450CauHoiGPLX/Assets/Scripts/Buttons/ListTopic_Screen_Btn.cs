using UnityEngine;
using System.Collections;

public class ListTopic_Screen_Btn : MonoBehaviour {

	public string idTopic;

	private SceneLoader sceneLoader;

	// Use this for initialization
	void Start () {
		sceneLoader = GameObject.Find ("SceneLoader").GetComponent<SceneLoader> ();
	}

	// Update is called once per frame
	void Update () {

	}

	public void onClickGoToSignContent(){
		PreferencesUtils.saveTopicIdClicked (idTopic);
		sceneLoader.doLoadLevelFadeIn ("List Sign Detail Scene", 10, 0.01f);
	}
}
