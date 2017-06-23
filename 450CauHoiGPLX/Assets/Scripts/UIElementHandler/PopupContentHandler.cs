using UnityEngine;
using System.Collections;

public class PopupContentHandler : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		resize ();
	}

	public void resize(){
		GetComponent<RectTransform> ().sizeDelta = new Vector2(GetComponent<RectTransform> ().rect.width, transform.Find ("Text").gameObject.GetComponent<RectTransform> ().rect.height);
	}
}
