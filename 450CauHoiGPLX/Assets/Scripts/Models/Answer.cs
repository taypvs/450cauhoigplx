using UnityEngine;
using System.Collections;
using Boomlagoon.JSON;

public class Answer : MonoBehaviour {

	public string id;
	public string text;
	public string position;
	public string correct;
	public string question_id;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public Answer(){
	
	}

	public Answer(JSONObject jsonObject){
		id = jsonObject ["id"].Str;
		text = jsonObject ["text"].Str;
		position = jsonObject ["position"].Str;
		correct = jsonObject ["correct"].Str;
		question_id = jsonObject ["question_id"].Str;
	}

	public string toString() {
		return JsonUtility.ToJson (this);
	}
}
