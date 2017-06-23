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
			"\"name\":\"" + question.qName + "\"," +
			"\"image\":\"" + question.image + "\"," +
			"\"position\":\"" + question.position + "\"," +
			"\"result\":\"" + question.result + "\"," +
			"\"answers\":[";
		if (question.answers != null) {
			for (int i = 0; i < question.answers.Length; i++) {
				jsonReturn += answerToJson (question.answers [i]);
				if (i < (question.answers.Length - 1))
					jsonReturn += ",";
			}
		}

		jsonReturn += "]}";

		return jsonReturn;
	}

	public static string groupQuestionToJson(GroupQuestion groupQuestion){
		string jsonReturn = "";
		jsonReturn += 
			"{\"id\":\"" + groupQuestion.id + "\"," +
			"\"name\":\"" + groupQuestion.gName + "\"," +
			"\"position\":\"" + groupQuestion.position + "\"," +
			"\"type\":\"" + groupQuestion.type + "\"," +
			"\"count\":\"" + groupQuestion.count + "\"," +
			"\"isDone\":\"" + groupQuestion.isDone + "\"," +
			"\"timeDone\":\"" + groupQuestion.timeDone + "\"," +
			"\"questions\":[";
		if (groupQuestion.questions != null) {
			for (int i = 0; i < groupQuestion.questions.Length; i++) {
				jsonReturn += questionToJson (groupQuestion.questions [i]);
				if (i < (groupQuestion.questions.Length - 1))
					jsonReturn += ",";
			}
		}

		jsonReturn += "]}";

		return jsonReturn;
	}

	public static string levelToJson(LevelQuestion levelQuestion){
		string jsonReturn = "";
		jsonReturn += 
			"{\"id\":\"" + levelQuestion.id + "\"," +
			"\"name\":\"" + levelQuestion.lName + "\"," +
			"\"count\":\"" + levelQuestion.count + "\"," +
			"\"groups\":[";
		if (levelQuestion.groupQuestions != null) {
			for (int i = 0; i < levelQuestion.groupQuestions.Length; i++) {
				jsonReturn += groupQuestionToJson (levelQuestion.groupQuestions [i]);
				if (i < (levelQuestion.groupQuestions.Length - 1))
					jsonReturn += ",";
			}
		}

		jsonReturn += "]}";

		return jsonReturn;
	}


	//==========================

	public static string contentToJson(Content content){
		return JsonUtility.ToJson (content);
	}

	public static string smallTopicToJson(SmallTopic smallTopic){
		string jsonReturn = "";
		jsonReturn += 
			"{\"id\":\"" + smallTopic.id + "\"," +
			"\"title\":\"" + smallTopic.title + "\"," +
			"\"position\":\"" + smallTopic.position + "\"," +
			"\"content\":[";
		if (smallTopic.contents != null) {
			for (int i = 0; i < smallTopic.contents.Length; i++) {
				jsonReturn += contentToJson (smallTopic.contents [i]);
				if (i < (smallTopic.contents.Length - 1))
					jsonReturn += ",";
			}
		}

		jsonReturn += "]}";

		return jsonReturn;
	}

	public static string topicToJson(Topic topic){
		string jsonReturn = "";
		jsonReturn += 
			"{\"id\":\"" + topic.id + "\"," +
			"\"name\":\"" + topic.tName + "\"," +
			"\"position\":\"" + topic.position + "\"," +
			"\"type_name\":\"" + topic.type_name + "\"," +
			"\"small_topic\":[";
		if (topic.smallTopics != null) {
			for (int i = 0; i < topic.smallTopics.Length; i++) {
				jsonReturn += smallTopicToJson (topic.smallTopics [i]);
				if (i < (topic.smallTopics.Length - 1))
					jsonReturn += ",";
			}
		}

		jsonReturn += "]}";

		return jsonReturn;
	}
}
