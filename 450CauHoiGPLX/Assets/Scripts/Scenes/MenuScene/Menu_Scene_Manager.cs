﻿using UnityEngine;
using System.Collections;

public class Menu_Scene_Manager : MonoBehaviour {

	public GameObject checkIconA1;
	public GameObject checkIconB1;
	public GameObject checkIconFC;

	// Use this for initialization
	void Start () {
		deactiveAllCheck ();
		if(PreferencesUtils.getCurrentLevelSelected().Equals(PreferencesUtils.LEVEL_DRIVER_TYPE_A))
			checkIconA1.SetActive(true);
		if(PreferencesUtils.getCurrentLevelSelected().Equals(PreferencesUtils.LEVEL_DRIVER_TYPE_B))
			checkIconB1.SetActive(true);
		if(PreferencesUtils.getCurrentLevelSelected().Equals(PreferencesUtils.LEVEL_DRIVER_TYPE_FC))
			checkIconFC.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void deactiveAllCheck(){
		checkIconA1.SetActive (false);
		checkIconB1.SetActive (false);
		checkIconFC.SetActive (false);
	}	
}