using UnityEngine;
using System.Collections;

public class JsonParser {

	public static string answerToJson(Answer answer){
		return JsonUtility.ToJson (answer);
	}

	public static string questionToJson(Question question){
		string jsonReturn = "";
		jsonReturn += 
			"{\"id\":\"" + question.id + "\"," +
			"\"name\":\"" + question.name + "\"," +
			"\"image\":\"" + question.image + "\"," +
			"\"position\":\"" + question.position + "\"," +
			"\"answers\":[";
		for(int i = 0; i<question.answers.Length; i++){
			jsonReturn += answerToJson(question.answers[i]);
			if(i<(question.answers.Length - 1 ))
				jsonReturn += ",";
		}

		jsonReturn += "]}";

		return jsonReturn;
	}
}
