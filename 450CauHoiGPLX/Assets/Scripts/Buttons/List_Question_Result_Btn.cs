using UnityEngine;
using System.Collections;

public class List_Question_Result_Btn : MonoBehaviour {

	public int index;

	private SceneLoader sceneLoader;

	// Use this for initialization
	void Start () {
		sceneLoader = GameObject.Find ("SceneLoader").GetComponent<SceneLoader> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void goToResultDetailsScene(){
		PreferencesUtils.setCurrentAnswerNumberSelect (index);
		sceneLoader.doLoadLevelFadeIn ("List Question Result Detail", 250, 0.2f);
	}
}
