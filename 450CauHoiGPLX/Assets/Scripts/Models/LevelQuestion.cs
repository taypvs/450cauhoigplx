using UnityEngine;
using System.Collections;
using Boomlagoon.JSON;

public class LevelQuestion {

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
			addGroupQuestion (groupQuestion, groupQuestionArray.Length, i);
			PreferencesUtils.saveJsonGroupQuestionsById (groupQuestion.id, JsonParser.groupQuestionToJson (groupQuestion));
		}
	}

	public void addGroupQuestion(GroupQuestion groupQuestion, int total, int position){
		if(groupQuestions==null)
			groupQuestions = new GroupQuestion[total];
		groupQuestions [position] = groupQuestion;
	}

	public GroupQuestion getGroupQuestionById(string id){
		for(int i = 0; i < groupQuestions.Length; i++){
			GroupQuestion groupQuestion = groupQuestions [i];
			if (groupQuestion.id.Equals (id))
				return groupQuestion;
		}
		return null;
	}

	public GroupQuestion getGroupQuestionInrangeByName(string name){
		GroupQuestion groupAll = new GroupQuestion();
		foreach (GroupQuestion currentGroup in groupQuestions) {
			if (CommonMethods.getGroupQuestionName (currentGroup.gName).ToLower().Equals ("toàn bộ câu hỏi")) {
				groupAll = currentGroup;
				break;
			}
		}
		if (CommonMethods.getGroupQuestionName(name).ToLower().Equals ("toàn bộ câu hỏi")) {
			return groupAll;
		} else if (CommonMethods.getGroupQuestionName (name).ToLower().Equals ("khái niệm và quy tắc")) {
			if (PreferencesUtils.getCurrentLevelSelected ().Equals (PreferencesUtils.LEVEL_DRIVER_TYPE_A)) {
				GroupQuestion returnGroup = groupAll.getGroupQuestionInRange (1, 72);
				return returnGroup;
			} else {
				GroupQuestion returnGroup = groupAll.getGroupQuestionInRange (1, 145);
				return returnGroup;
			}
		} else if (CommonMethods.getGroupQuestionName (name).ToLower().Equals ("nghiệp vụ vận tải")) {
			GroupQuestion returnGroup = groupAll.getGroupQuestionInRange (146, 175);
			return returnGroup;
		} else if (CommonMethods.getGroupQuestionName (name).ToLower().Equals ("văn hoá và đạo đức")) {
			if (PreferencesUtils.getCurrentLevelSelected ().Equals (PreferencesUtils.LEVEL_DRIVER_TYPE_A)) {
				GroupQuestion returnGroup = groupAll.getGroupQuestionInRange (73, 77);
				return returnGroup;
			} else {
				GroupQuestion returnGroup = groupAll.getGroupQuestionInRange (176, 200);
				return returnGroup;
			}
		} else if (CommonMethods.getGroupQuestionName (name).ToLower().Equals ("kỹ thuật lái xe")) {			
			GroupQuestion returnGroup = groupAll.getGroupQuestionInRange (201, 235);
			return returnGroup;
		} else if (CommonMethods.getGroupQuestionName (name).ToLower().Equals ("cấu tạo và sửa chữa")) {			
			GroupQuestion returnGroup = groupAll.getGroupQuestionInRange (236, 255);
			return returnGroup;
		} else if (CommonMethods.getGroupQuestionName (name).ToLower().Equals ("biển báo đường bộ")) {			
			if (PreferencesUtils.getCurrentLevelSelected ().Equals (PreferencesUtils.LEVEL_DRIVER_TYPE_A)) {
				GroupQuestion returnGroup = groupAll.getGroupQuestionInRange (78, 112);
				return returnGroup;
			} else {
				GroupQuestion returnGroup = groupAll.getGroupQuestionInRange (256, 355);
				return returnGroup;
			}
		} else if (CommonMethods.getGroupQuestionName (name).ToLower().Equals ("sa hình")) {			
			if (PreferencesUtils.getCurrentLevelSelected ().Equals (PreferencesUtils.LEVEL_DRIVER_TYPE_A)) {
				GroupQuestion returnGroup = groupAll.getGroupQuestionInRange (113, 147);
				return returnGroup;
			} else {
				GroupQuestion returnGroup = groupAll.getGroupQuestionInRange (356, 450);
				return returnGroup;
			}
		}
		return groupAll;
	}

}
