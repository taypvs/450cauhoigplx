using UnityEngine;
using System.Collections;
using Boomlagoon.JSON;

public class AllLevel : MonoBehaviour {

	public LevelQuestion[] levels;

	public AllLevel(){

	}

	public AllLevel(JSONArray jsonArray){
		levels = new LevelQuestion[jsonArray.Length];
		for(int i = 0; i < jsonArray.Length; i++){
			LevelQuestion level = new LevelQuestion (jsonArray[i].Obj);
			levels [i] = level;
			PreferencesUtils.saveJsonGroupQuestionsInLevel(CommonMethods.getLevelString(level.lName), JsonParser.levelToJson(level));
		}

	}

}
