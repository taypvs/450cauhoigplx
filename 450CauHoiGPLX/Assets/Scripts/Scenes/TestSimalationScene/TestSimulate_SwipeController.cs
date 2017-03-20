using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class TestSimulate_SwipeController : MonoBehaviour, IDragHandler {

	public Text debugText;
	public Text questionNumber;
	public int totalQuestion;
	public int index;

	private bool isTouched;
	private Vector2 touchPosition;

	private Vector3 beginTouchPosition;
	private Vector3 endTouchPosition;
	private float dragVerticalSmooth;
	private float elemScreenWidth;
	private float smoothAutoDrag;

	public GameObject slides;
	// Use this for initialization

	private void initSimulation(){
		isTouched = false;
		dragVerticalSmooth = 0.7f;
		elemScreenWidth = slides.transform.GetChild (0).gameObject.GetComponent<RectTransform> ().rect.width;
		index = 0;
		smoothAutoDrag = 0.2f;
	}

	void Start () {
		initSimulation ();
	}
	
	// Update is called once per frame
	void Update () {
		#if UNITY_EDITOR

		if(Input.GetMouseButtonDown(0)){
			touchPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
			onBeginTouch();
		}

		if (Input.GetMouseButtonUp(0)){
			touchPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
			onEndTouch();
		}

		if (isTouched){
			touchPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
			onDragListener();
		}
		#else
		if (Input.touchCount>0 && Input.GetTouch(0).phase==TouchPhase.Began) {
			touchPosition = Input.GetTouch(0).position;
			onBeginTouch();
		}
		if (Input.touchCount>0 && Input.GetTouch(0).phase==TouchPhase.Moved) {
			touchPosition = Input.GetTouch(0).position;

			onDragListener();
		}


		if (Input.touchCount>0 && Input.GetTouch(0).phase==TouchPhase.Ended) {
			touchPosition = Input.GetTouch(0).position;
			onEndTouch();
		}
		#endif
	}

	public void onDragListener(){
	//	debugText.text = "x : " + Input.mouseScrollDelta.x + " - y : " + Input.mouseScrollDelta.y;
	}

	public void onBeginTouch(){
		isTouched = true;
		beginTouchPosition = touchPosition;
	}

	public void onEndTouch(){
		isTouched = false;
		endTouchPosition = touchPosition;
		Debug.Log (TouchUtils.getDragHorizontalDirection(beginTouchPosition, endTouchPosition));
		debugText.text = "Screen.width : " + Screen.width + " - Delta X :  " + (beginTouchPosition.x - endTouchPosition.x);
		if (TouchUtils.getDragHorizontalDirection (beginTouchPosition, endTouchPosition).Equals (UtilsConstanst.DRAG_LEFT)) {
			if (endTouchPosition.x - beginTouchPosition.x > Screen.width / 3 && index > 0) {
				float drag_x = slides.GetComponent<RectTransform> ().anchoredPosition.x;
				swipeToLeft ();
			} else {
				xChangeSmoothly (-elemScreenWidth * (index), smoothAutoDrag);
			}
		} else if (TouchUtils.getDragHorizontalDirection (beginTouchPosition, endTouchPosition).Equals (UtilsConstanst.DRAG_RIGHT)) {
			if (beginTouchPosition.x - endTouchPosition.x > Screen.width / 3 && index < (slides.transform.childCount - 1)) {
				float drag_x = slides.GetComponent<RectTransform> ().anchoredPosition.x;
				swipeToRight ();
			} else {
				xChangeSmoothly (-elemScreenWidth * (index), smoothAutoDrag);
			}
		}
	}

	public void OnDrag (PointerEventData eventData)
	{
		float drag_x = slides.GetComponent<RectTransform> ().anchoredPosition.x;
		drag_x += (eventData.delta.x)*dragVerticalSmooth;
		slides.GetComponent<RectTransform> ().anchoredPosition = new Vector3 (drag_x, slides.GetComponent<RectTransform> ().anchoredPosition.y);
	}

	public void xChangeSmoothly (float endX_horizontal, float celerate){
		float startX_horizontal = slides.GetComponent<RectTransform> ().anchoredPosition.x;
		iTween.ValueTo (gameObject, iTween.Hash("from", startX_horizontal, 
												"to", endX_horizontal, 
												"onupdate", "xChangeOnUpdateCallBack",
												"time", celerate));

	}

	public void swipeToLeft(){
		if (index > 0) {
			xChangeSmoothly (-elemScreenWidth * (index - 1), smoothAutoDrag);
			index--;
			questionNumber.text = (index + 1) + "/" + totalQuestion;
		}
	}

	public void swipeToRight(){
		if (index < (slides.transform.childCount - 1)) {
			xChangeSmoothly (-elemScreenWidth * (index + 1), smoothAutoDrag);
			index++;
			questionNumber.text = (index + 1) + "/" + totalQuestion;
		}
	}

	void xChangeOnUpdateCallBack( int newValue )
	{
		float drag_x = newValue;
		slides.GetComponent<RectTransform> ().anchoredPosition = new Vector3 (drag_x, slides.GetComponent<RectTransform> ().anchoredPosition.y);
	}

}
