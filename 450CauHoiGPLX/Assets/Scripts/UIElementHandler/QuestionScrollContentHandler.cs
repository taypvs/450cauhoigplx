using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class QuestionScrollContentHandler : MonoBehaviour {

	public void calculateExpandArea(){
		Transform childNumberTxt = transform.GetChild (0);
		Transform childQuestionTxt = transform.GetChild (1);
		Transform imageQuestion = childQuestionTxt.GetChild (0);


		float heightNumberTxt = (-childNumberTxt.gameObject.GetComponent<RectTransform> ().anchoredPosition.y) + childNumberTxt.gameObject.GetComponent<RectTransform> ().sizeDelta.y;
		float heightQuestionTxt = (-childQuestionTxt.gameObject.GetComponent<RectTransform> ().anchoredPosition.y) + childQuestionTxt.gameObject.GetComponent<RectTransform> ().sizeDelta.y;
		float imageHeight = (-imageQuestion.gameObject.GetComponent<RectTransform> ().anchoredPosition.y) + imageQuestion.gameObject.GetComponent<RectTransform> ().sizeDelta.y;

		float answerHeight = calculateAnswerLayout (childQuestionTxt);


		float totalHeight = heightNumberTxt + heightQuestionTxt + imageHeight + answerHeight;

		GetComponent<RectTransform> ().sizeDelta = new Vector2 (GetComponent<RectTransform> ().sizeDelta.x, totalHeight);
	}

	private float calculateAnswerLayout(Transform parent){
		Transform answerLayout = parent.Find ("AnswerLayout(Clone)");
		if (answerLayout != null) {
			float answerHeight = (-answerLayout.gameObject.GetComponent<RectTransform> ().anchoredPosition.y) + answerLayout.Find("Text").gameObject.GetComponent<Text> ().preferredHeight;	
			return answerHeight + calculateAnswerLayout(answerLayout);
		} else
			return 350;
	}
}