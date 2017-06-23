using UnityEngine;
using System.Collections;

public class ListTest_Sceen_Task : SceneTask {

	public ListTests_Sceen_Manager sceneManager;

	public void doLoadTaskAfterBack () {
		Debug.Log ("ListTest_Sceen_Task : doLoadTaskAfterBack");
		sceneManager.load ();
	}
}
