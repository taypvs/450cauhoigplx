using UnityEngine;
using System.Collections;
using Boomlagoon.JSON;

public class LevelQuestion : MonoBehaviour {

	public string id;
	public string name;
	public string count; 
	public GroupQuestion[] groupQuestions;

	public LevelQuestion(){

	}

	public LevelQuestion(JSONObject jsonObject){
		id = jsonObject ["id"].Str;
		name = jsonObject ["name"].Str;
		count = jsonObject ["count"].Str;
		JSONArray groupQuestionArray = jsonObject ["groups"].Array;
		for(int i = 0; i < groupQuestionArray.Length; i++){
			GroupQuestion groupQuestion = new GroupQuestion (groupQuestionArray[i].Obj);
			addGroupQuestion (groupQuestion, groupQuestionArray.Length, i);
		}
	}

	public void addGroupQuestion(GroupQuestion groupQuestion, int total, int position){
		if(groupQuestions==null)
			groupQuestions = new GroupQuestion[total];
		groupQuestions [position] = groupQuestion;
	}


}
