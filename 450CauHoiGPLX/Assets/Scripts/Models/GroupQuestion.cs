using UnityEngine;
using System.Collections;
using Boomlagoon.JSON;

public class GroupQuestion : MonoBehaviour {
	
	public string id;
	public string name;
	public string position;
	public string type_id; // 0 : Đề câu hỏi ôn tập, 1 : Đề thi thử
	public string count; 
	public Question[] questions;

	public GroupQuestion(){

	}

	public GroupQuestion(JSONObject jsonObject){
		id = jsonObject ["id"].Str;
		name = jsonObject ["name"].Str;
		position = jsonObject ["position"].Str;
		type_id = jsonObject ["type_id"].Str;
		count = jsonObject ["count"].Str;
		JSONArray questionArray = jsonObject ["questions"].Array;
		for(int i = 0; i < questionArray.Length; i++){
			Question question = new Question (questionArray[i].Obj);
			addQuestion (question, questionArray.Length, i);
		}
	}

	public void addQuestion(Question question, int total, int position){
		if(questions==null)
			questions = new Question[total];
		questions [position] = question;
	}
}
