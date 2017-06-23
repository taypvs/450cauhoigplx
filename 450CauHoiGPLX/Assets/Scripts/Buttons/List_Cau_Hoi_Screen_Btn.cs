using UnityEngine;
using System.Collections;

public class List_Cau_Hoi_Screen_Btn : MonoBehaviour {

	public string nameGroupQuestion;
	public SceneLoader sceneLoader;
	// Use this for initialization
	void Start () {
		sceneLoader = GameObject.Find ("SceneLoader").gameObject.GetComponent<SceneLoader> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void onClickGoToTest(){
		PreferencesUtils.setCurrentSelectedGroupQuestion (nameGroupQuestion);
		sceneLoader.doLoadLevelFadeIn ("List Cau Hoi Detail", 10, 0.01f);
	}
}
