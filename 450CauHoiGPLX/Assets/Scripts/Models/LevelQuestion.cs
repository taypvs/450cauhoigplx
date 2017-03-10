using UnityEngine;
using System.Collections;
using Boomlagoon.JSON;

public class LevelQuestion : MonoBehaviour {

	public string id;
	public string lName;
	public string count; 
	public GroupQuestion[] groupQuestions;

	public LevelQuestion(){

	}

	public LevelQuestion(JSONObject jsonObject){
		id = jsonObject ["id"].Str;
		lName = jsonObject ["name"].Str;
		count = jsonObject ["count"].Str;
		JSONArray groupQuestionArray = jsonObject ["groups"].Array;
		for(int i = 0; i < groupQuestionArray.Length; i++){
			GroupQuestion groupQuestion = new GroupQuestion (groupQuestionArray[i].Obj);
			Debug.Log ("groupQuestion name : " + groupQuestion.gName);
			addGroupQuestion (groupQuestion, groupQuestionArray.Length, i);
		}
	}

	public void addGroupQuestion(GroupQuestion groupQuestion, int total, int position){
		if(groupQuestions==null)
			groupQuestions = new GroupQuestion[total];
		groupQuestions [position] = groupQuestion;
	}


}
