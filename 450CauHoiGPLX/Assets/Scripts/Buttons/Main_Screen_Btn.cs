using UnityEngine;
using System.Collections;

public class Main_Screen_Btn : MonoBehaviour {

	public GameObject sceneLoader;
	public LoadingIconHandler loadingIcon;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void onClickLoadCarSimulateScene(){
		if(!loadingIcon.isLockButton)
			if(PreferencesUtils.getCurrentLevelSelected().Equals(PreferencesUtils.LEVEL_DRIVER_TYPE_A))
				sceneLoader.GetComponent<SceneLoader> ().doLoadLevelFadeIn ("CustomDriverScene", 250, 0.3f);
			else if(PreferencesUtils.getCurrentLevelSelected().Equals(PreferencesUtils.LEVEL_DRIVER_TYPE_FC))
				sceneLoader.GetComponent<SceneLoader> ().doLoadLevelFadeIn ("FCDriverScene", 250, 0.3f);
	}

	public void onClickLoadListTestsScene(){
		if(!loadingIcon.isLockButton)
			sceneLoader.GetComponent<SceneLoader> ().doLoadLevelFadeIn ("List Tests Scene", 250, 0.1f);
	}

	public void onClickLoadMenuScene(){
		if(!loadingIcon.isLockButton)
			sceneLoader.GetComponent<SceneLoader> ().doLoadLevelFadeIn ("Menu Scene", 250, 0.1f);
	}

	public void onClickMainScene(){
		if(!loadingIcon.isLockButton)
			sceneLoader.GetComponent<SceneLoader> ().doLoadLevelFadeIn ("Main Scene", 250, 0.1f);
	}

	public void onClickLoadResultScene(){
		if(!loadingIcon.isLockButton)
			sceneLoader.GetComponent<SceneLoader> ().doLoadLevelFadeIn ("List Question Result", 250, 0.1f);
	}

}
	