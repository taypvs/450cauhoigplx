using UnityEngine;
using System.Collections;
using Boomlagoon.JSON;

public class Answer : MonoBehaviour {

	public string id;
	public string text;
	public string position;
	public string correct;
	public string choose;
	public string question_id;

	public Answer(){
	
	}

	public Answer(JSONObject jsonObject){
		id = jsonObject ["id"].Str;
		text = jsonObject ["text"].Str;
		position = jsonObject ["position"].Str;
		correct = jsonObject ["correct"].Str;
		question_id = jsonObject ["question_id"].Str;
		choose = "0";
		if(jsonObject.ContainsKey ("choose"))
			choose = jsonObject ["choose"].Str;
	}

	public string toString() {
		return JsonUtility.ToJson (this);
	}
}
