using UnityEngine;
using System.Collections;

public class CarScript : MonoBehaviour, CarBehaviorInterface {

	public GameObject[] targetPoint;
	public float currentSpeed;
	public bool isMainCar;
	public float defaultSpeed;
	public float turnRate;
	public GameObject truckBody;
	public bool isMoving;
	public AudioSource soundSource;
	public AudioClip finishSound;
	public AudioClip startEngineSound;
	public AudioClip runEngineSound;

	private int pointPosition;
	private float speedRate;
	private float pitchRate;
	private GameObject currentPoint;
	public bool isBackward;
	private const float defaultCelerate = 1f;
	private const float fastCelerate = 0.5f;
	private const float slowCelerate = 1.2f;
	private const float pitchDefault = 0.1f;

	private void init(){
		isBackward = false;
		isMoving = false;
		currentSpeed = 0;
		pointPosition = -1;
		speedRate = 0.5f;
		pitchRate = 0.025f;
	}

	// Use this for initialization
	void Start () {
		startEngine ();
		init ();
//		startMoving ();
	}
	
	// Update is called once per frame
	void Update () {
		if (currentPoint != null) {
			if (currentPoint.GetComponent<TargetPoint> ().isTruckTurnBack && isMoving) {
				GameObject.Find ("BackwardBody").GetComponent<TruckBody> ().backwardTarget = targetPoint [pointPosition+4];
			}
			if (CommonMethods.distanceToPoint (transform.position, currentPoint.transform.position) < 0.3f && isMoving) {
				if (currentPoint.GetComponent<TargetPoint> ().popUp!=null) {
					currentPoint.GetComponent<TargetPoint> ().showPopup ();
				}
				if (currentPoint.GetComponent<TargetPoint> ().isSwitchBack)
					switchTurnBack ();
				if (currentPoint.GetComponent<TargetPoint> ().isSwitchFront)
					switchTurnForward ();
				
				if (currentPoint.GetComponent<TargetPoint> ().isCheckPoint) {
					pause ();
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
			if(currentPoint!=null)
				transform.Translate ((currentPoint.transform.position - transform.position).normalized * currentSpeed * speedRate * Time.deltaTime);
			if (runEngineSound != null && !soundSource.isPlaying) {				
				runEngine ();
			}
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
			if (currentPoint!=null&&currentPoint.GetComponent<TargetPoint> ().isSwitchRotateChild)
				truckBody.GetComponent<BoxFollow> ().switchActiveRotate ();
			currentPoint = targetPoint [pointPosition];
			SmoothLook (currentPoint.transform);;
		}
	}


	public void pause(){
		isMoving = false;
	}
	public void stop (){
		if(!isMainCar)
			isMoving = false;
		else{
			if(!soundSource.isPlaying)
				soundSource.PlayOneShot (finishSound);
		}
	}

	public void startEngine (){
		if (startEngineSound != null) {
			soundSource.PlayOneShot (startEngineSound);
		}
	}

	public void runEngine (){
		if (runEngineSound != null) {
			Debug.Log ("Run !!! ");
			soundSource.PlayOneShot (runEngineSound);
			engineSoundPlay ();
		}
	}

	private void engineSoundPlay(){
		soundSource.pitch = pitchDefault + currentSpeed * pitchRate;
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

	private void switchTurnForward(){
		isBackward = false;
		truckBody.GetComponent<BoxFollow> ().switchForward ();
	}

	IEnumerator waitForSeconds(float seconds) {
		yield return new WaitForSeconds(seconds);
		isMoving = true;
		speedChange(defaultSpeed, defaultCelerate);
	}

}
