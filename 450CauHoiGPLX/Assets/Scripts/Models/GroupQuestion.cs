﻿using UnityEngine;
using System.Collections;
using Boomlagoon.JSON;

public class GroupQuestion : MonoBehaviour {
	
	public string id;
	public string gName;
	public string position;
	public string type; // 0 : Đề câu hỏi ôn tập, 1 : Đề thi thử
	public string count; 
	public string isDone; // 0 : not yet, 1 : is Done
	public Question[] questions;

	public GroupQuestion(){

	}

	public GroupQuestion(JSONObject jsonObject){
		id = jsonObject ["id"].Str;
		gName = jsonObject ["name"].Str;
		position = jsonObject ["position"].Str;
		type = jsonObject ["type"].Str;
		count = jsonObject ["count"].Str;
		isDone = "";
		if(jsonObject.ContainsKey("isDone"))
			isDone = jsonObject ["isDone"].Str;
		JSONArray questionArray = jsonObject ["questions"].Array;
		for(int i = 0; i < questionArray.Length; i++){
			Question question = new Question (questionArray[i].Obj);
			addQuestion (question, questionArray.Length, i);
			Debug.Log ("question name : " + question.qName);
		}
	}

	public void addQuestion(Question question, int total, int position){
		if(questions==null)
			questions = new Question[total];
		questions [position] = question;
	}
}