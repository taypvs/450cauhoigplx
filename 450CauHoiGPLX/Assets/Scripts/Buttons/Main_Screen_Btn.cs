using UnityEngine;
using System.Collections;

public class Main_Screen_Btn : MonoBehaviour {

	public GameObject sceneLoader;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void onClickLoadCarSimulateScene(){
		Debug.Log ("Current Level : " + PreferencesUtils.getCurrentLevelSelected ());
		if(PreferencesUtils.getCurrentLevelSelected().Equals(PreferencesUtils.LEVEL_DRIVER_TYPE_A))
			sceneLoader.GetComponent<SceneLoader> ().doLoadLevelFadeIn ("CustomDriverScene", 250, 0.3f);
		else if(PreferencesUtils.getCurrentLevelSelected().Equals(PreferencesUtils.LEVEL_DRIVER_TYPE_FC))
			sceneLoader.GetComponent<SceneLoader> ().doLoadLevelFadeIn ("FCDriverScene", 250, 0.3f);
	}

	public void onClickLoadListTestsScene(){
		Debug.Log ("onClickLoadCarSimulateScene");
		sceneLoader.GetComponent<SceneLoader> ().doLoadLevelFadeIn ("List Tests Scene", 250, 0.1f);
	}

	public void onClickLoadMenuScene(){
		Debug.Log ("onClickLoadCarSimulateScene");
		sceneLoader.GetComponent<SceneLoader> ().doLoadLevelFadeIn ("Menu Scene", 250, 0.1f);
	}

	public void onClickMainScene(){
		sceneLoader.GetComponent<SceneLoader> ().doLoadLevelFadeIn ("Main Scene", 250, 0.1f);
	}

	public void onClickLoadResultScene(){
		Debug.Log ("onClickLoadCarSimulateScene");
		sceneLoader.GetComponent<SceneLoader> ().doLoadLevelFadeIn ("List Question Result", 250, 0.1f);
	}

}
