using UnityEngine;
using System.Collections;

public class Menu_Screen_Btn : MonoBehaviour {

	public Menu_Scene_Manager screenManager;
	public SceneLoader sceneLoader;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void doSelectedA1(){
		screenManager.deactiveAllCheck ();
		screenManager.checkIconA1.SetActive (true);
		PreferencesUtils.setCurrentLevelSelected (PreferencesUtils.LEVEL_DRIVER_TYPE_A);
	}

	public void doSelectedB1(){
		screenManager.deactiveAllCheck ();
		screenManager.checkIconB1.SetActive (true);
		PreferencesUtils.setCurrentLevelSelected (PreferencesUtils.LEVEL_DRIVER_TYPE_B);
	}

	public void doSelectedFC(){
		screenManager.deactiveAllCheck ();
		screenManager.checkIconFC.SetActive (true);
		PreferencesUtils.setCurrentLevelSelected (PreferencesUtils.LEVEL_DRIVER_TYPE_FC);
	}
		
}
