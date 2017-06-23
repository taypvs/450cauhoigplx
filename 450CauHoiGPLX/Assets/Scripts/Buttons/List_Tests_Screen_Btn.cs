using UnityEngine;
using System.Collections;

public class List_Tests_Screen_Btn : MonoBehaviour {

	public string idGroupQuestion;
	public string isDone;

	private SceneLoader sceneLoader;

	// Use this for initialization
	void Start () {
		sceneLoader = GameObject.Find ("SceneLoader").GetComponent<SceneLoader> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void onClickGoToTest(){
		PreferencesUtils.setCurrentSelectedGroupQuestion (idGroupQuestion);
		if (isDone.Equals ("0") || isDone.Equals ("")) {
			sceneLoader.doLoadLevelFadeIn ("Test Simulation Scene", 10, 0.01f);
		} else {
			sceneLoader.doLoadLevelFadeIn ("List Question Result", 10, 0.01f);
		}
	}
}
