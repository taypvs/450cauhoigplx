using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class SceneLoader : MonoBehaviour {

	public GameObject fadeLayout;
	private Color newFadeColor;
	private string levelLoad;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void onLoadSceneFadeIn(){
		onLoadFadeIn (0, 0.3f);
	}

	public void loadLevelFadeIn(string level, float value, float time){
		Debug.Log ("loadLevelFadeIn : " + level);
		levelLoad = level;
		oncloseFadeOut (value, time);
	}

	public void onLoadFadeIn(float value, float time){
		Debug.Log ("oncloseFadeIn : " + value);
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
		Debug.Log ("oncloseFadeIn : " + value);
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
		Debug.Log (newValue);
		newFadeColor = new Color32(0, 0, 0, byte.Parse(newValue.ToString()));
		fadeLayout.GetComponent<Image> ().color = newFadeColor;
	}

	public void fadeOnCompleteCallBack(){
	   // Application.LoadLevel (levelLoad);
		SceneManager.LoadScene (levelLoad, LoadSceneMode.Single);
//		SceneManager.SetActiveScene ();
	}
}
