using UnityEngine;
using System.Collections;

public class List_Tests_Screen_Btn : MonoBehaviour {

	public string idGroupQuestion;
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
		sceneLoader.doLoadLevelFadeIn ("Test Simulation Scene", 250, 0.2f);
	}
}
