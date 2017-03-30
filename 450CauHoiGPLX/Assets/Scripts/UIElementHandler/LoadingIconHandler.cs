using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoadingIconHandler : MonoBehaviour {

	private float rotateSpeed;
	private float rotateValue;

	// Use this for initialization
	void Start () {
		rotateSpeed = 350;
		rotateValue = 0;
	}
	
	// Update is called once per frame
	void Update () {
		rotateValue = rotateValue + rotateSpeed*Time.deltaTime;
		if (rotateValue > 1080)
			rotateValue = 0;
		gameObject.GetComponent<RectTransform> ().rotation = Quaternion.Euler (0, 0, -rotateValue);
	}
}
