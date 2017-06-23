using UnityEngine;
using UnityEngine.UI;
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

	public GameObject headMotor;
	public Text baithiText;

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

		Screen.orientation = ScreenOrientation.Portrait;

//		startMoving ();
	}
	
	// Update is called once per frame
	void Update () {
		if (currentPoint != null) {
			if (currentPoint.GetComponent<TargetPoint> ().isTruckTurnBack && isMoving) {
				GameObject.Find ("BackwardBody").GetComponent<TruckBody> ().backwardTarget = targetPoint [pointPosition+4];
			}

			if (CommonMethods.distanceToPoint (transform.position, currentPoint.transform.position) < 0.3f && isMoving) {

				if (currentPoint.GetComponent<TargetPoint> ().isSwitchLight) {
					currentPoint.GetComponent<TargetPoint> ().switchLight ();
				}

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
					if (currentPoint.GetComponent<TargetPoint> ().testName!=null&&!currentPoint.GetComponent<TargetPoint> ().testName.Equals (""))
						baithiText.text = currentPoint.GetComponent<TargetPoint> ().testName;
					moveToNextPoint ();
				}

			}

		}

		// Car driving
		if (isMoving) {
			if(currentPoint!=null)
				transform.Translate ((currentPoint.transform.position - transform.position).normalized * currentSpeed * speedRate * Time.deltaTime);
			if (runEngineSound != null) {				
				if(!soundSource.isPlaying)
					runEngine ();
				engineSoundPlay ();
			}
		}
	}

	void OnDestroy() {
		Screen.orientation = ScreenOrientation.AutoRotation;
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
			if(pointPosition< targetPoint.Length - 1) 
				SmoothLook (currentPoint.transform, targetPoint[pointPosition + 1].transform);
			else
				SmoothLook (currentPoint.transform, null);

		}
	}

	public void continueMoving(float seconds){
		StartCoroutine (continueAfterSeconds (seconds));
	}

	public void pause(){
		isMoving = false;
	}
	public void stop (){
		if(!isMainCar)
			isMoving = false;
		else{
			if(finishSound != null)
				soundSource.PlayOneShot (finishSound);
		}
	}

	public void startEngine (){
		if (startEngineSound != null) {
			soundSource.PlayOneShot (startEngineSound);
		}
		StartCoroutine (startAfterSeconds (2));
	}

	public void runEngine (){
		if (runEngineSound != null) {
			Debug.Log ("Run !!! ");
			soundSource.PlayOneShot (runEngineSound);
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
		
	private void SmoothLook(Transform target, Transform nextTarget){
//		transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(newDirection), Time.deltaTime);
		Vector3 targetLook;
		if (isBackward)
			targetLook = new Vector3 (transform.position.x * 2 - target.position.x, target.position.y, transform.position.z * 2 - target.position.z);
		else
			targetLook = target.position;
		iTween.LookTo(gameObject.transform.Find("Root").gameObject, iTween.Hash("looktarget", targetLook , "time", 0.4f*turnRate, "easeType", iTween.EaseType.linear));
		if (headMotor != null) {
			headMotor.GetComponent<MotoHead> ().smoothLookTo (nextTarget);
		}

	}

	private void switchTurnBack(){
		isBackward = true;
		if(truckBody!=null)
			truckBody.GetComponent<BoxFollow> ().switchBackward ();
	}

	private void switchTurnForward(){
		isBackward = false;
		if(truckBody!=null)
			truckBody.GetComponent<BoxFollow> ().switchForward ();
	}

	IEnumerator waitForSeconds(float seconds) {
		yield return new WaitForSeconds(seconds);
		isMoving = true;
		speedChange(defaultSpeed, defaultCelerate);
	}

	IEnumerator startAfterSeconds(float seconds) {
		yield return new WaitForSeconds(seconds);
	}
		
	IEnumerator continueAfterSeconds(float seconds) {
		yield return new WaitForSeconds(seconds);
		isMoving = true;
		if (currentSpeed == 0) {
			currentSpeed = 5;
			speedChange (currentSpeed, slowCelerate);
		}
	}
}
