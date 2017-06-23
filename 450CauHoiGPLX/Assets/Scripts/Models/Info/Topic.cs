using UnityEngine;
using System.Collections;
using Boomlagoon.JSON;

public class Topic {
	public string id;
	public string tName;
	public string position;
	public string type_name; 
	public SmallTopic[] smallTopics;

	public Topic(){

	}

	public Topic(JSONObject jsonObject){
		id = jsonObject ["id"].Str;
		tName = jsonObject ["name"].Str;
		position = jsonObject ["position"].Str;
		type_name = jsonObject ["type_name"].Str;
		JSONArray smallTopicArray = jsonObject ["small_topic"].Array;
		for(int i = 0; i < smallTopicArray.Length; i++){
			SmallTopic smallTopic = new SmallTopic (smallTopicArray[i].Obj);
			addSmallTopic (smallTopic, smallTopicArray.Length, i);
		}
	}

	public void addSmallTopic(SmallTopic smallTopic, int total, int position){
		if(smallTopics==null)
			smallTopics = new SmallTopic[total];
		smallTopics [position] = smallTopic;
	}
}
