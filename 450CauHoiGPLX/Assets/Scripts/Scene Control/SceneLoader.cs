using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class SceneLoader : MonoBehaviour {

	public GameObject fadeLayout;
	private Color newFadeColor;
	private string levelLoad;
	public GameObject mainCamera;
	public LoadingIconHandler loadingIcon;
	public SceneTransition sceneTransition;

	public void onLoadSceneFadeIn(){
		onLoadFadeIn (0, 0.01f);
	}

	public void doLoadLevelFadeIn(string level, float value, float time){
		if(loadingIcon!=null)
			loadingIcon.activeLoading ();
		levelLoad = level;
		oncloseFadeOut (value, time);
	}

	public void onLoadFadeIn(float value, float time){
		iTween.ValueTo(
			gameObject,  
			iTween.Hash(
				"from", 255, 
				"to", value, 
				"onupdate", "fadeOnUpdateCallBack",
				"time", time,
				"easeType", iTween.EaseType.easeOutExpo));
	}

	public void oncloseFadeOut(float value, float time){
		iTween.ValueTo(
			gameObject,  
			iTween.Hash(
				"from", 0, 
				"to", value, 
				"onupdate", "fadeOnUpdateCallBack",
				"oncomplete", "fadeOnCompleteCallBack",
				"time", time,
				"easeType", iTween.EaseType.easeInExpo));
	}

	public void fadeOnUpdateCallBack(int newValue){
		newFadeColor = new Color32(0, 0, 0, byte.Parse(newValue.ToString()));
		fadeLayout.GetComponent<Image> ().color = newFadeColor;
	}

	public void fadeOnCompleteCallBack(){
	   // Application.LoadLevel (levelLoad);
//		SceneManager.LoadScene (levelLoad, LoadSceneMode.Single);
//		SceneManager.SetActiveScene ();
		StartCoroutine(LoadSceneAsync());
		loadingIcon.deactiveLoading ();
		if(mainCamera!=null)
			mainCamera.SetActive (false);
	}

	public void loadSceneSingleMode (string levelLoad){
		this.levelLoad = levelLoad;
		StartCoroutine(LoadSceneAsyncWithSigleMode());
	}

	public void doBackPreviousScene(){
		Debug.Log ("current scene : " + sceneTransition.currentSceneName);
		SceneManager.UnloadScene(sceneTransition.currentSceneName);

		GameObject sceneTaskCtrl = GameObject.Find (sceneTransition.lastSceneName + " Task");

		if(mainCamera!=null)
			mainCamera.SetActive (false);
		if (sceneTaskCtrl != null) {
			sceneTaskCtrl.GetComponent<ListTest_Sceen_Task>().doLoadTaskAfterBack ();
		}
	}

	IEnumerator LoadSceneAsyncWithSigleMode()
	{
		AsyncOperation result = SceneManager.LoadSceneAsync ( levelLoad, LoadSceneMode.Single );
		PreferencesUtils.setCurrentScene (levelLoad);
		result.allowSceneActivation = false;

		while (result.progress < 0.9f)
		{

		}
		// still scene one should be active, tryed it as workaround, did not help
		result.allowSceneActivation = true;
		while (!result.isDone) {
			yield return result;
		}
	}

	IEnumerator LoadSceneAsync()
	{
		AsyncOperation result = SceneManager.LoadSceneAsync ( levelLoad, LoadSceneMode.Additive );
		PreferencesUtils.setCurrentScene (levelLoad);
		result.allowSceneActivation = false;

		while (result.progress < 0.9f)
		{
			
		}
//		Debug.Log ( "YEAH Loaded Async" );
		// still scene one should be active, tryed it as workaround, did not help
		result.allowSceneActivation = true;
		while (!result.isDone) {
			yield return result;
		}
	}
}
