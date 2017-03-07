using UnityEngine;
using System.Collections;
using Boomlagoon.JSON;

public class Question : MonoBehaviour {

	public string id;
	public string name;
	public string image;
	public string position;
	public Answer[] answers;

	public Question(){

	}

	public Question(JSONObject jsonObject){
		id = jsonObject ["id"].Str;
		name = jsonObject ["name"].Str;
		image = jsonObject ["image"].Str;
		position = jsonObject ["position"].Str;
		JSONArray answerArray = jsonObject ["answers"].Array;
		for(int i = 0; i < answerArray.Length; i++){
			Answer answer = new Answer (answerArray[i].Obj);
			addAnswer (answer, answerArray.Length, i);
		}
	}

	public void addAnswer(Answer answer, int total, int position){
		if(answers==null)
			answers = new Answer[total];
		answers [position] = answer;
	}
}
