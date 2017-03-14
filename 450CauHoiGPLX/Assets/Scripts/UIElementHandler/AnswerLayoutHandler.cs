using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AnswerLayoutHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<RectTransform> ().sizeDelta = new Vector2(GetComponent<RectTransform> ().rect.width, transform.Find ("Text").gameObject.GetComponent<RectTransform> ().rect.height);
	}
}
