using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AnswerLayoutHandler : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		GetComponent<RectTransform> ().sizeDelta = new Vector2(GetComponent<RectTransform> ().rect.width, transform.Find ("Text").gameObject.GetComponent<Text> ().preferredHeight + 50);
	}
}
