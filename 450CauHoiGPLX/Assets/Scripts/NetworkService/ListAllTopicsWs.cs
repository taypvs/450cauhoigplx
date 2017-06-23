using UnityEngine;
using System.Collections;

public class ListAllTopicsWs : MonoBehaviour {

	public HttpApiLoader httpApiLoader;

	public void initialize (){
		httpApiLoader.initialize ();
	}

	public void doGetListTopic(System.Action onComplete){
		httpApiLoader.GET (UtilsConstanst.API_GET_ALL_TOPICS, onComplete);
	}
}
