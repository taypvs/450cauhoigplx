using UnityEngine;
using System.Collections;

public class TestSimulate_SwipeController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.touchCount>0 && Input.GetTouch(0).phase==TouchPhase.Moved) {
			Vector2 touchDelta = Input.GetTouch(0).deltaPosition;
//			transform.Translate (-touchDelta.x, 0, 0);
			Debug.Log("ss");
		}

		if (Input.touchCount>0 && Input.GetTouch(0).phase==TouchPhase.Ended) {
			Vector2 touchDelta = Input.GetTouch(0).deltaPosition;
			//This was a flick to the left with magnitude of 5 or more
			if (touchDelta.x>5) {
				
			}
			//This was a flick to the right with magnitude of 5 or more
			if (touchDelta.x<-5) {
				
			} 
		}
	}
}
