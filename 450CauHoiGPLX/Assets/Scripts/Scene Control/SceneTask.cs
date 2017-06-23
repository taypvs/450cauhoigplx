using UnityEngine;
using System.Collections;

public class SceneTask : MonoBehaviour, SceneTaskInterface {
	public SceneTransition sceneTransition;

	public void doTransitionBack () {
		
	}

	public void doLoadTaskAfterBack () {
		Debug.Log ("SceneTask : doLoadTaskAfterBack");
	}

}
