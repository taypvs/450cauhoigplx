using UnityEngine;
using System.Collections;
using Boomlagoon.JSON;

public class Question {

	public string id;
	public string qName;
	public string image;
	public string position;
	public string result; // 0 = not yet, 1 = wrong, 2 = right
	public Answer[] answers;

	public Question(){

	}

	public Question(JSONObject jsonObject){
		id = jsonObject ["id"].Str;
		qName = jsonObject ["name"].Str;
		image = jsonObject ["image"].Str;
		position = jsonObject ["position"].Str;
		result = "0";
		if(jsonObject.ContainsKey ("result"))
			result = jsonObject ["result"].Str;
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
