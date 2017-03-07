using UnityEngine;
using System.Collections;

public class ListAllQuestionsWs : MonoBehaviour {

	public HttpApiLoader httpApiLoader;

	public void initialize (){
		httpApiLoader.initialize ();
	}

	public void doGetListQuestion(System.Action onComplete){
		httpApiLoader.GET (UtilsConstanst.API_GET_ALL_QUESTIONS, onComplete);
	}
}
