using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class List_Sign_Detail_Btn : MonoBehaviour {

	public string detail;
	public string image;
	public string title;
	public GameObject popup;

	private SceneLoader sceneLoader;

	// Use this for initialization
	void Start () {
		sceneLoader = GameObject.Find ("SceneLoader").GetComponent<SceneLoader> ();
		popup = GameObject.Find ("Canvas").transform.Find("App Layout").Find("Popup Detail").gameObject;
	}

	// Update is called once per frame
	void Update () {

	}

	public void onClickPopupDetail(){
		Sprite signSrpite = Resources.Load<Sprite>(image);
		if(signSrpite!=null){
			popup.transform.Find ("Detail Layout").Find ("Detail Header").Find ("Image").GetComponent<Image> ().sprite = signSrpite;
		}
		popup.transform.Find ("Detail Layout").Find ("Detail Header").Find ("Text").GetComponent<Text> ().supportRichText = true;
		popup.transform.Find ("Detail Layout").Find ("Detail Header").Find ("Text").GetComponent<Text> ().text = CommonMethods.reformatText(title);
		popup.transform.Find ("Detail Layout").Find ("Scroll View").Find ("Viewport").Find("Content").Find("Text").GetComponent<Text> ().text = CommonMethods.reformatText(detail);
		popup.SetActive (true);
	}

	public void onClickTurnOffPopup(){
		popup.SetActive (false);
	}
}
