using UnityEngine;
using System.Collections;

public class CarScript : MonoBehaviour, CarBehaviorInterface {

	public GameObject[] targetPoint;
	public GameObject popUp;
	public float currentSpeed;
	public AudioSource finishSound;
	public bool isMainCar;
	public float defaultSpeed;
	public float turnRate;
	public GameObject truckBody;

	private bool isMoving;
	private int pointPosition;
	private float speedRate;
	private GameObject currentPoint;
	private GameObject previousPoint;
	public bool isBackward;
	private const float defaultCelerate = 1f;
	private const float fastCelerate = 0.5f;
	private const float slowCelerate = 1.2f;

	private void init(){
		isBackward = false;
		isMoving = false;
		currentSpeed = 0;
		pointPosition = -1;
		speedRate = 0.5f;
	}

	// Use this for initialization
	void Start () {
		init ();
//		startMoving ();
	}
	
	// Update is called once per frame
	void Update () {
		if (currentPoint != null) {
			if (CommonMethods.distanceToPoint (transform.position, currentPoint.transform.position) < 0.3f && isMoving) {

				if (currentPoint.GetComponent<TargetPoint> ().isSwitchBack)
					switchTurnBack ();
				
				if (currentPoint.GetComponent<TargetPoint> ().isCheckPoint) {
					pause ();
					showPopupInfo ();
				} else if (currentPoint.GetComponent<TargetPoint> ().isStopPoint) {
					stop ();
					moveToNextPoint ();
				}
				else if (currentPoint.GetComponent<TargetPoint> ().isWaitPoint) {
					StartCoroutine (waitForSeconds (currentPoint.GetComponent<TargetPoint> ().waitingTime));
					moveToNextPoint ();
				} else {
					moveToNextPoint ();
				}

			}
		}

		// Car driving
		if (isMoving) {
			transform.Translate ((currentPoint.transform.position - transform.position).normalized * currentSpeed * speedRate * Time.deltaTime);
		}
	}

	public void startMoving(){
		isMoving = true;
		currentSpeed = 5;
		speedChange (currentSpeed, slowCelerate);
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
				speedChange(currentPoint.GetComponent<TargetPoint>().speed, slowCelerate);
		}
		if (pointPosition < targetPoint.Length) {
			previousPoint = targetPoint [pointPosition-1];
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


	public void pause(){
		isMoving = false;
	}
	public void stop (){
		if(!isMainCar)
			isMoving = false;
		else
			finishSound.Play ();
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

	}
		
	private void SmoothLook(Transform target){
//		transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(newDirection), Time.deltaTime);
		Vector3 targetLook;
		if (isBackward)
			targetLook = new Vector3 (transform.position.x * 2 - target.position.x, target.position.y, transform.position.z * 2 - target.position.z);
		else
			targetLook = target.position;
		iTween.LookTo(gameObject.transform.Find("Root").gameObject, iTween.Hash("looktarget", targetLook , "time", 0.4f*turnRate, "easeType", iTween.EaseType.linear));

	}

	private void switchTurnBack(){
		isBackward = true;
		truckBody.GetComponent<BoxFollow> ().switchBackward ();
	}

	IEnumerator waitForSeconds(float seconds) {
		yield return new WaitForSeconds(seconds);
		speedChange(defaultSpeed, defaultCelerate);
	}

}
