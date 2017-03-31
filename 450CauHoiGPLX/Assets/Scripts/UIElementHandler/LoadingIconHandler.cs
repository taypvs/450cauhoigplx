using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoadingIconHandler : MonoBehaviour {

	private float rotateSpeed;
	private float rotateValue;
	public bool isLockButton;

	// Use this for initialization
	void Start () {
		rotateSpeed = 350;
		rotateValue = 0;
		isLockButton = true;
	}
	
	// Update is called once per frame
	void Update () {
		rotateValue = rotateValue + rotateSpeed*Time.deltaTime;
		if (rotateValue > 1080)
			rotateValue = 0;
		gameObject.GetComponent<RectTransform> ().rotation = Quaternion.Euler (0, 0, -rotateValue);
	}

	public void activeLoading(){
		Debug.Log ("activeLoading");
		gameObject.SetActive (true);
		isLockButton = true;
	}

	public void deactiveLoading(){
		Debug.Log ("deactiveLoading");
		gameObject.SetActive (false);
		isLockButton = false;
	}
}
