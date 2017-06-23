using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Header : MonoBehaviour {

	public bool settingActive;
	public bool backIconActive;
	public string headerTitleTxt;

	// Use this for initialization
	void Start () {
		GameObject settingIcon = transform.Find ("Setting Icon").gameObject;
		GameObject backIcon = transform.Find ("Back Icon").gameObject;
		Text headerTitle = transform.Find ("Header Title").gameObject.GetComponent<Text> ();

		if (settingActive)
			settingIcon.SetActive (true);
		else
			settingIcon.SetActive (false);

		if (backIconActive)
			backIcon.SetActive (true);
		else
			backIcon.SetActive (false);

		headerTitle.text = headerTitleTxt;
	}

}
