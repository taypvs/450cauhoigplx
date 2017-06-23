using UnityEngine;
using System.Collections;
using Boomlagoon.JSON;

public class SmallTopic {
	public string id;
	public string title;
	public string position; 
	public Content[] contents;

	public SmallTopic(){

	}

	public SmallTopic(JSONObject jsonObject){
		id = jsonObject ["id"].Str;
		title = jsonObject ["title"].Str;
		position = jsonObject ["position"].Str;
		JSONArray conntentArray = jsonObject ["content"].Array;
		for(int i = 0; i < conntentArray.Length; i++){
			Content content = new Content (conntentArray[i].Obj);
			addContent (content, conntentArray.Length, i);
		}
	}

	public void addContent(Content content, int total, int position){
		if(contents==null)
			contents = new Content[total];
		contents [position] = content;
	}

}
