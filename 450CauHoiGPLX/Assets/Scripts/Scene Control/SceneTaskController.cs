using UnityEngine;
using System.Collections;

public class SceneTaskController : MonoBehaviour {

	public SceneTask sceneTask;

	public void doTaskAfterBack(){
		sceneTask.doLoadTaskAfterBack ();
	}
}
