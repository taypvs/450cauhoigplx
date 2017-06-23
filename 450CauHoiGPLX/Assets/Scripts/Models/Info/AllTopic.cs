using UnityEngine;
using System.Collections;
using Boomlagoon.JSON;

public class AllTopic : MonoBehaviour {
	public Topic[] topics;

	public AllTopic(){

	}

	public AllTopic(JSONArray jsonArray){
		topics = new Topic[jsonArray.Length];
		for(int i = 0; i < jsonArray.Length; i++){
			Topic topic = new Topic (jsonArray[i].Obj);
			topics [i] = topic;
			if(topic.type_name.Equals("meo"))
				PreferencesUtils.saveTopicTrick(JsonParser.topicToJson(topic));
			else
				PreferencesUtils.saveTopicSign(JsonParser.topicToJson(topic));
		}

	}
}
