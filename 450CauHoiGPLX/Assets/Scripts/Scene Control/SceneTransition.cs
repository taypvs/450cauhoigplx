using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransition : MonoBehaviour {

	public SceneLoader sceneLoader;
	public string currentSceneName;
	public string lastSceneName;
	// Use this for initialization
	void Start () {
		SceneManager.activeSceneChanged += OnSceneWasSwitched;
		SceneManager.sceneLoaded += OnSceneLoaded;
		Debug.Log ("currentSceneName : " + currentSceneName);
	}

	void OnDisable ()
	{
		SceneManager.sceneLoaded -= OnSceneLoaded;
		SceneManager.activeSceneChanged -= OnSceneWasSwitched;
		iTween.ValueTo(
			gameObject,  
			iTween.Hash(
				"from", 0, 
				"to", 1080, 
				"onupdate", "transitionUpdateCallBack",
				"oncomplete", "transitionBackComplete",
				"time", 0.5f,
				"easeType", iTween.EaseType.easeOutExpo));
	}

	public void closeScene (){
		OnDisable ();
	}

	void OnEnable ()
	{
		sceneSetup ();

		if (!currentSceneName.Equals ("Main Scene")) {
			iTween.ValueTo (
				gameObject,  
				iTween.Hash (
					"from", 1080, 
					"to", 0, 
					"onupdate", "transitionUpdateCallBack",
					"time", UtilsConstanst.SCENE_TRANSITION_TIME,
					"easeType", iTween.EaseType.easeOutExpo));
		}
	}

	public void transitionUpdateCallBack (int newValue){
		gameObject.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (newValue, 0);
	}

	public void transitionBackComplete (){
		sceneLoader.doBackPreviousScene ();
	}

	private void OnSceneLoaded(Scene aScene, LoadSceneMode aMode)
	{
		// do whatever you like
		Debug.Log(aScene.name + " Loaded!!!!");
	}

	private void OnSceneWasSwitched(Scene aScene, Scene bScene)
	{
		// do whatever you like
		Debug.Log(aScene.name + " Switched to " + bScene.name);
	}

	private void sceneSetup () {
		lastSceneName = PreferencesUtils.getLastScene ();
		currentSceneName = PreferencesUtils.getCurrentScene ();
		PreferencesUtils.setLastScene (currentSceneName);
	}
}
