using UnityEngine;
using System.Collections;

public class Main_Screen_Btn : MonoBehaviour {

	public GameObject sceneLoader;
	public bool isLock;

	// Use this for initialization
	void Start () {
		isLock = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void onClickLoadCarSimulateScene(){
		if(!isLock)
			if(PreferencesUtils.getCurrentLevelSelected().Equals(PreferencesUtils.LEVEL_DRIVER_TYPE_A))
				sceneLoader.GetComponent<SceneLoader> ().doLoadLevelFadeIn ("CustomDriverScene", 250, 0.3f);
			else if(PreferencesUtils.getCurrentLevelSelected().Equals(PreferencesUtils.LEVEL_DRIVER_TYPE_FC))
				sceneLoader.GetComponent<SceneLoader> ().doLoadLevelFadeIn ("FCDriverScene", 250, 0.3f);
	}

	public void onClickLoadListTestsScene(){
		if(!isLock)
			sceneLoader.GetComponent<SceneLoader> ().doLoadLevelFadeIn ("List Tests Scene", 250, 0.1f);
	}

	public void onClickLoadMenuScene(){
		if(!isLock)
			sceneLoader.GetComponent<SceneLoader> ().doLoadLevelFadeIn ("Menu Scene", 250, 0.1f);
	}

	public void onClickMainScene(){
		if(!isLock)
			sceneLoader.GetComponent<SceneLoader> ().doLoadLevelFadeIn ("Main Scene", 250, 0.1f);
	}

	public void onClickLoadResultScene(){
		if(!isLock)
			sceneLoader.GetComponent<SceneLoader> ().doLoadLevelFadeIn ("List Question Result", 250, 0.1f);
	}

}
