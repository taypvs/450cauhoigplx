using UnityEngine;
using System.Collections;
using Boomlagoon.JSON;

public class GroupQuestion {
	
	public string id;
	public string gName;
	public string position;
	public string type; // 0 : Đề câu hỏi ôn tập, 1 : Đề thi thử
	public string count; 
	public string timeDone; 
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
		timeDone = "";
		if(jsonObject.ContainsKey("timeDone"))
			timeDone = jsonObject ["timeDone"].Str;
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

	public int numQuestionRight() {
		int count = 0;
		foreach (Question question in questions){
			if (question.result.Equals ("2"))
				count++;
		}
		return count;
	}

	public int numQuestionWrong() {
		int count = 0;
		foreach (Question question in questions){
			if (question.result.Equals ("1"))
				count++;
		}
		return count;
	}


	public GroupQuestion getGroupQuestionInRange(int fromIndex, int toIndex){
		GroupQuestion newGroupQuestion = new GroupQuestion ();
		newGroupQuestion.gName = gName;
		int index = 0;
		for(int i = (fromIndex - 1 ); i < toIndex; i++){
			Question newQuestion = questions [i];
			newGroupQuestion.addQuestion (newQuestion, (toIndex - fromIndex + 1), index);
			index++;
		}
		return newGroupQuestion;
	}
}
