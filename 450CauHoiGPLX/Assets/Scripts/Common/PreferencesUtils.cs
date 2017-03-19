using UnityEngine;
using System.Collections;

public class PreferencesUtils {
	public static string LEVEL_DRIVER_TYPE_A = "LEVEL_DRIVER_TYPE_A";
	public static string LEVEL_DRIVER_TYPE_B = "LEVEL_DRIVER_TYPE_B";
	public static string LEVEL_DRIVER_TYPE_FC = "LEVEL_DRIVER_TYPE_FC";

	public static string LEVEL_DRIVER_TYPE = "LEVEL_DRIVER_TYPE_";
	public static string CURRENT_LEVEL_SELECTED = "CURRENT_LEVEL_SELECTED";
	public static string CURRENT_GROUP_QUESTION_SELECTED = "CURRENT_GROUP_QUESTION_SELECTED";

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
		string savedLevel = LEVEL_DRIVER_TYPE + level;
		return PlayerPrefs.GetString (savedLevel);
	}
		

	// Group Question Id Select to Test
	public static void setCurrentSelectedGroupQuestion(string id){
		PlayerPrefs.SetString (CURRENT_GROUP_QUESTION_SELECTED, id);
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
}
