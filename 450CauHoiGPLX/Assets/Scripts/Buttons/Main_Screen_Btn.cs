using UnityEngine;
using System.Collections;

public class Main_Screen_Btn : MonoBehaviour {

	public GameObject sceneLoader;
	public SceneTransition sceneTransition;
	public GameObject PopupA;
	public GameObject PopupB;
	public bool isOpenPopup;
	public LoadingIconHandler loadingIcon;

	public void onClickOpenPopup(){
		isOpenPopup = true;
		if (PreferencesUtils.getCurrentLevelSelected ().Equals (PreferencesUtils.LEVEL_DRIVER_TYPE_B))
			PopupB.SetActive (true);
		else 
			PopupA.SetActive (true);
	}

	public void onClickRoadDriverScene(){
		isOpenPopup = false;
		PopupA.SetActive (false);
		PopupB.SetActive (false);
//		sceneLoader.GetComponent<SceneLoader> ().doLoadLevelFadeIn ("CustomDriverScene", 10, 0.01f);
		sceneLoader.GetComponent<SceneLoader> ().loadSceneSingleMode ("CustomDriverScene");
	}

	public void onClickLoadTrickScene(){
		isOpenPopup = false;
		PopupA.SetActive (false);
		PopupB.SetActive (false);
		sceneLoader.GetComponent<SceneLoader> ().doLoadLevelFadeIn ("Trick Scene", 10, 0.01f);
	}

	public void onClickLoadSignScene(){
		sceneLoader.GetComponent<SceneLoader> ().doLoadLevelFadeIn ("List  Sign Topic Scene", 10, 0.01f);
	}

	public void onClickLoadCarSimulateScene(){
		isOpenPopup = false;
		PopupA.SetActive (false);
		PopupB.SetActive (false);

		if (PreferencesUtils.getCurrentLevelSelected ().Equals (PreferencesUtils.LEVEL_DRIVER_TYPE_A)) {
//			sceneLoader.GetComponent<SceneLoader> ().doLoadLevelFadeIn ("A1MotoScene", 10, 0.01f);
			sceneLoader.GetComponent<SceneLoader> ().loadSceneSingleMode ("A1MotoScene");

		} else if (PreferencesUtils.getCurrentLevelSelected ().Equals (PreferencesUtils.LEVEL_DRIVER_TYPE_FC)) {
//			sceneLoader.GetComponent<SceneLoader> ().doLoadLevelFadeIn ("FCDriverScene", 10, 0.01f);
			sceneLoader.GetComponent<SceneLoader> ().loadSceneSingleMode ("FCDriverScene");
		} else {
//			sceneLoader.GetComponent<SceneLoader> ().doLoadLevelFadeIn ("B1Scene", 10, 0.01f);
			sceneLoader.GetComponent<SceneLoader> ().loadSceneSingleMode ("B1Scene");
		}
		
	}

	public void onClickLoadListTestsScene(){
		sceneLoader.GetComponent<SceneLoader> ().doLoadLevelFadeIn ("List Tests Scene", 10, 0.01f);
	}

	public void onClickLoadMenuScene(){
		sceneLoader.GetComponent<SceneLoader> ().doLoadLevelFadeIn ("Menu Scene", 10, 0.01f);
	}

	public void onClickMainScene(){
		if(!loadingIcon.isLockButton)
			sceneLoader.GetComponent<SceneLoader> ().loadSceneSingleMode ("Main Scene");
	}

	public void onClickMainSceneSignleMode(){
		if(!loadingIcon.isLockButton)
			sceneLoader.GetComponent<SceneLoader> ().doLoadLevelFadeIn ("Main Scene", 10, 0.01f);
	}

	public void onClickLoadListCauHoiScene(){
		if(!loadingIcon.isLockButton)
			sceneLoader.GetComponent<SceneLoader> ().doLoadLevelFadeIn ("List Cau Hoi On Tap", 10, 0.01f);
	}

	public void onClickLoadResultScene(){
		if(!loadingIcon.isLockButton)
			sceneLoader.GetComponent<SceneLoader> ().doLoadLevelFadeIn ("List Question Result", 10, 0.01f);
	}

	public void onClickBackScene(){
		if (!loadingIcon.isLockButton)
			sceneTransition.closeScene ();
	}
}
	