using UnityEngine;
using System.Collections;

public class TargetPoint : MonoBehaviour {

	public bool isCheckPoint;
	public bool isStopPoint;
	public bool isWaitPoint;
	public bool isSwitchBack;
	public bool isSwitchFront;
	public bool isTruckTurnBack;
	public bool isSwitchRotateChild;
	public bool isSwitchLight;

	public float speed;
	public float waitingTime;
	public float switchTrafficLightTime;
	public GameObject popUp;
	public TrafficLightController[] trafficLight;

	public string testName;

	public void showPopup(){
		popUp.SetActive (true);
	}

	public void switchLight(){
		foreach (TrafficLightController tf in trafficLight) {
			if(switchTrafficLightTime==0)
				tf.switchLightAfter (1f);
			else 
				tf.switchLightAfter (switchTrafficLightTime);
		}
	}
}
