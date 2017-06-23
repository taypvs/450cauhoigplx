using UnityEngine;
using System.Collections;
using Boomlagoon.JSON;

public class Content {

	public string id;
	public string title;
	public string detail;
	public string position;
	public string image;

	public Content(){

	}

	public Content(JSONObject jsonObject){
		id = jsonObject ["id"].Str;
		title = jsonObject ["title"].Str;
		position = jsonObject ["position"].Str;
		detail = jsonObject ["detail"].Str;
		image = jsonObject ["image"].Str;
	}

}
