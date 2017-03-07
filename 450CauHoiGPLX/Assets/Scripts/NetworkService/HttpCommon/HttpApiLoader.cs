using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Boomlagoon.JSON;

public class HttpApiLoader : MonoBehaviour {

	string response;
	//string url = "http://www.thomas-bayer.com/sqlrest/CUSTOMER/3/";
	Dictionary<string, string> headers;

	/*
	 * How to use
	 * 
	 * System.Action logresutl = LogResult;
		GET(url, logresutl);
	 * 
	 */ 

	public string results;
	public bool isError;
	private string urlName;

	public HttpApiLoader (LoadAPIListenner loadApiListener){

	}

	public void initialize(){
		headers = new Dictionary<string, string>();
		// for PUT
		//		headers.Add( "Content-Type", "application/json" );
		//		headers.Add( "X-HTTP-Method-Override", "PUT" );

		//
		headers.Add( "Content-Type", "application/json" );
		//headers.Add( "Authorization", "Basic " + System.Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes("1pacvn:onepac189")));
	}


	public WWW GET(string url, System.Action onComplete) {
		Debug.Log ("Call URL : " + url + "  - header => " + headers );
		WWW www = new WWW (url, null, headers);
		urlName = url;
		StartCoroutine (WaitForRequest (www, onComplete));
		return www;
	}

	public WWW PUT(string url, Dictionary<string,string> putData, System.Action onComplete) {
		// Add header PUT
		headers.Add( "X-HTTP-Method-Override", "PUT" );

		// Create JSON data
		JSONObject jsonObject = new JSONObject();
		foreach(KeyValuePair<string,string> post_arg in putData) {
			jsonObject.Add (post_arg.Key, post_arg.Value);
		}
		Debug.Log ("Call URL : " + url + "  - header => " + headers );

		WWW www = new WWW (url, System.Text.Encoding.UTF8.GetBytes(jsonObject.ToString()), headers);
		urlName = url;

		StartCoroutine (WaitForRequest (www, onComplete));
		return www;
	}

	public WWW DELETE(string url, Dictionary<string,string> putData, System.Action onComplete) {
		// Add header PUT
		headers.Add( "X-HTTP-Method-Override", "DELETE" );

		// Create JSON data
		JSONObject jsonObject = new JSONObject();
		foreach(KeyValuePair<string,string> post_arg in putData) {
			jsonObject.Add (post_arg.Key, post_arg.Value);
		}
		Debug.Log ("Call URL : " + url + "  - header => " + headers );

		WWW www = new WWW (url, System.Text.Encoding.UTF8.GetBytes(jsonObject.ToString()), headers);
		urlName = url;

		StartCoroutine (WaitForRequest (www, onComplete));
		return www;
	}

	public WWW POST(string url, Dictionary<string,string> post, System.Action onComplete) {
		// Create JSON data
		JSONObject jsonObject = new JSONObject();
		foreach(KeyValuePair<string,string> post_arg in post) {
			jsonObject.Add (post_arg.Key, post_arg.Value);
		}
		Debug.Log ("Call URL : " + url + "  - params => " + jsonObject.ToString() );
		WWW www = new WWW (url, System.Text.Encoding.UTF8.GetBytes(jsonObject.ToString()), headers);
		urlName = url;

		StartCoroutine(WaitForRequest(www, onComplete));
		return www;
	}

	private IEnumerator WaitForRequest(WWW www, System.Action onComplete) {
		yield return www;
		// check for errors
		if (www.error == null) {
			results = www.text;
			Debug.Log ("results - " + www.text);
			isError = false;
			onComplete.Invoke();
		} else {
			Debug.Log (www.error + " - " + www.text);
			results = www.text;
			isError = true;
			onComplete.Invoke();
		}
	}

	private void LogResult(){
		Debug.Log ("result -> " + results);
	}
}
