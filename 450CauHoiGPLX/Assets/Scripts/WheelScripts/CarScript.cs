using UnityEngine;
using System.Collections;

public class CarScript : MonoBehaviour, CarBehaviorInterface {

	public GameObject[] targetPoint;
	public GameObject popUp;
	public float currentSpeed;

	private float defaultSpeed;
	private bool isMoving;
	private int pointPosition;
	private float speedRate;
	private GameObject currentPoint;

	private const float defaultCelerate = 1f;
	private const float fastCelerate = 0.5f;
	private const float slowCelerate = 1.5f;

	private void init(){
		isMoving = false;
		currentSpeed = 0;
		defaultSpeed = 15f;
		pointPosition = -1;
		speedRate = 0.5f;
	}

	// Use this for initialization
	void Start () {
		init ();
		startMoving ();
	}
	
	// Update is called once per frame
	void Update () {
		if (CommonMethods.distanceToPoint (transform.position, currentPoint.transform.position) < 0.3f && isMoving) {
			if (currentPoint.GetComponent<TargetPoint> ().isCheckPoint||currentPoint.GetComponent<TargetPoint> ().isStopPoint) {
				stop ();
				if(currentPoint.GetComponent<TargetPoint> ().isCheckPoint)
					showPopupInfo ();
			} 
			else if(currentPoint.GetComponent<TargetPoint> ().isWaitPoint){
				StartCoroutine(waitForSeconds (currentPoint.GetComponent<TargetPoint> ().waitingTime));
				moveToNextPoint ();
			}
			else {
				moveToNextPoint ();
			}
		}

		// Car driving
		if(isMoving)
			transform.Translate((currentPoint.transform.position - transform.position).normalized*currentSpeed*speedRate*Time.deltaTime);
	}

	public void startMoving(){
		isMoving = true;
//		currentSpeed = defaultSpeed;
		speedChange (defaultSpeed, slowCelerate);
		moveToNextPoint ();
	}
	public void moveToNextPoint (){
		isMoving = true;
		pointPosition++;
//		speedChange(defaultSpeed, defaultCelerate);
		if (currentPoint != null) {
			if(currentPoint.GetComponent<TargetPoint>().speed!=0)
				speedChange(currentPoint.GetComponent<TargetPoint>().speed, defaultCelerate);
			else
				speedChange(currentPoint.GetComponent<TargetPoint>().speed, fastCelerate);
		}
		if (pointPosition < targetPoint.Length) {
			currentPoint = targetPoint [pointPosition];
			SmoothLook (currentPoint.transform);
//			transform.LookAt (currentPoint.transform);
//			iTween.MoveTo (gameObject, iTween.Hash ("position", currentPoint.transform.position, 
//													"speed", currentSpeed, 
//													"EaseType", iTween.EaseType.linear));

//			iTween.MoveUpdate (gameObject, iTween.Hash ("position", currentPoint.transform.position, "time", 1));

//			transform.Translate((currentPoint.transform.position - transform.position).normalized*currentSpeed*Time.deltaTime);
		}
	}

	public void stop (){
		isMoving = false;
	}

	public void showPopupInfo (){
		popUp.SetActive (true);
	}

	public void hidePopupInfo (){
		popUp.SetActive (false);
	}

	public void startEngine (){
	
	}

	public void speedChange (float nextSpeed, float celerate){
		float startSpeed = currentSpeed;
		iTween.ValueTo (gameObject, iTween.Hash("from", startSpeed, 
												"to", nextSpeed, 
												"onupdate", "tweenOnUpdateCallBack",
												"time", celerate));
		
	}

	void tweenOnUpdateCallBack( int newValue )
	{
		currentSpeed = newValue;

		Debug.Log ("speedChange - Speed : " + currentSpeed);
	}
		
	private void SmoothLook(Transform target){
//		transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(newDirection), Time.deltaTime);
		iTween.LookTo(gameObject, iTween.Hash("looktarget", target , "time", 5f));
	}

	IEnumerator waitForSeconds(float seconds) {
		yield return new WaitForSeconds(seconds);
		Debug.Log ("speedChange - defaultSpeed");
		speedChange(defaultSpeed, defaultCelerate);
	}

}
