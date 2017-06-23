using UnityEngine;
using System.Collections;

public class PreferencesUtils {
	public static string LEVEL_DRIVER_TYPE_A = "LEVEL_DRIVER_TYPE_A1";
	public static string LEVEL_DRIVER_TYPE_B = "LEVEL_DRIVER_TYPE_B";
	public static string LEVEL_DRIVER_TYPE_FC = "LEVEL_DRIVER_TYPE_FC";

	public static string LEVEL_DRIVER_TYPE = "LEVEL_DRIVER_TYPE_";
	public static string CURRENT_LEVEL_SELECTED = "CURRENT_LEVEL_SELECTED";
	public static string CURRENT_GROUP_QUESTION_SELECTED = "CURRENT_GROUP_QUESTION_SELECTED";
	public static string CURRENT_ANSWER_SELECTED = "CURRENT_ANSWER_SELECTED";
	public static string ID_GROUP_QUESTION = "ID_GROUP_QUESTION_";

	public static string TRICK_PREFERENCE = "TRICK_PREFERENCE";
	public static string SIGN_PREFERENCE = "SIGN_PREFERENCE";
	public static string SIGN_CLICKED_PREFERENCE = "SIGN_CLICKED_PREFERENCE";

	public static string CURRENT_SCENE = "CURRENT_SCENE";
	public static string LAST_SCENE = "LAST_SCENE";

	// Current selected Level in Menu 
	public static void setCurrentLevelSelected(string value){
		PlayerPrefs.SetString (CURRENT_LEVEL_SELECTED, value);
	}

	public static string getCurrentLevelSelected(){
		return PlayerPrefs.GetString (CURRENT_LEVEL_SELECTED);
	}


	// Save All Group Question to Memory
	public static void saveJsonGroupQuestionsInLevel(string level, string value){
		string saveLevel = LEVEL_DRIVER_TYPE + level;
		PlayerPrefs.SetString (saveLevel, value);
	}

	public static string getJsonGroupQuestionsInLevel(string level){
		return PlayerPrefs.GetString (level);
	}
		
	// Save Group Question to Memory
	public static void saveJsonGroupQuestionsById(string id, string value){
		string saveGroup = ID_GROUP_QUESTION + id;
		PlayerPrefs.SetString (saveGroup, value);
	}

	public static string getJsonGroupQuestionsById(string id){
		string saveGroup = ID_GROUP_QUESTION + id;
		return PlayerPrefs.GetString (saveGroup);
	}

	// Group Question Id Select to Test
	public static void setCurrentSelectedGroupQuestion(string name){
		PlayerPrefs.SetString (CURRENT_GROUP_QUESTION_SELECTED, name);
	}

	public static string getCurrentSelectedGroupQuestion(){
		return PlayerPrefs.GetString (CURRENT_GROUP_QUESTION_SELECTED);
	}

	public static void clearCurrentSelectedGroupQuestion(){
		PlayerPrefs.DeleteKey (CURRENT_GROUP_QUESTION_SELECTED);
	}


	// Group question saved after Test
	public static void saveGroupQuestionDone(string currentGroupId, string jsonContent){
		PlayerPrefs.SetString (getCurrentLevelSelected() + "_" + currentGroupId, jsonContent);
	}

	public static string getGroupQuestionDone(string currentGroupId){
		return PlayerPrefs.GetString (getCurrentLevelSelected() + "_" + currentGroupId);
	}

	// Save selected Answer Index
	public static void setCurrentAnswerNumberSelect(int index){
		PlayerPrefs.SetInt (CURRENT_ANSWER_SELECTED, index);
	}

	public static int getCurrentAnswerNumberSelect(){
		return PlayerPrefs.GetInt (CURRENT_ANSWER_SELECTED, 0);
	}

	public static void clearAnswerNumberSelect(){
		PlayerPrefs.DeleteKey (CURRENT_ANSWER_SELECTED);
	}

	// TOpics
	public static void saveTopicTrick(string value){
		PlayerPrefs.SetString (TRICK_PREFERENCE, value);
	}

	public static string getTopicTrick(){
		return PlayerPrefs.GetString (TRICK_PREFERENCE);
	}

	public static void saveTopicSign(string value){
		PlayerPrefs.SetString (SIGN_PREFERENCE, value);
	}

	public static string getTopicSign(){
		return PlayerPrefs.GetString (SIGN_PREFERENCE);
	}

	public static void saveTopicIdClicked(string value){
		PlayerPrefs.SetString (SIGN_CLICKED_PREFERENCE, value);
	}

	public static string getTopicIdClicked(){
		return PlayerPrefs.GetString (SIGN_CLICKED_PREFERENCE);
	}

	public static void setCurrentScene(string sceneName){
		PlayerPrefs.SetString (CURRENT_SCENE, sceneName);
	}

	public static string getCurrentScene(){
		return PlayerPrefs.GetString (CURRENT_SCENE);
	}

	public static void setLastScene(string sceneName){
		PlayerPrefs.SetString (LAST_SCENE, sceneName);
	}

	public static string getLastScene(){
		return PlayerPrefs.GetString (LAST_SCENE);
	}
}
