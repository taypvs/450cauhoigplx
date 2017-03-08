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
		Debug.Log ("onClickLoadCarSimulateScene");
		sceneLoader.GetComponent<SceneLoader> ().loadLevelFadeIn ("CustomDriverScene", 250, 0.3f);
	}
}
