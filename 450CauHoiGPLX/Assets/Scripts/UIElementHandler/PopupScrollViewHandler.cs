using UnityEngine;
using System.Collections;

public class PopupScrollViewHandler : MonoBehaviour {

//	// Use this for initialization
//	void Start () {
//		Debug.Log ("Height : " + transform.Find ("Viewport").Find ("Content").gameObject.GetComponent<RectTransform> ().rect.height);
//
//	}
//	
	// Update is called once per frame
	void Update () {
		resize ();
		//GetComponent<RectTransform> ().sizeDelta = new Vector2(GetComponent<RectTransform> ().rect.width, transform.Find ("Viewport").Find ("Content").gameObject.GetComponent<RectTransform> ().rect.height);
	}

	public void resize(){
		GetComponent<RectTransform> ().sizeDelta = new Vector2(GetComponent<RectTransform> ().rect.width, transform.Find ("Viewport").Find ("Content").gameObject.GetComponent<RectTransform> ().rect.height);
	}
}
