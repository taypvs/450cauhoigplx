using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TestSimulate_TimeManager : MonoBehaviour {

	public int TotalTimeInSeconds;
	private float tempTime;
	private float nextTime;
	public Text timeTxt;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		nextTime = Time.time;
		if (nextTime - tempTime >= 1) {
			tempTime = nextTime;
			timeTxt.text = CommonMethods.secondsToMMSS (TotalTimeInSeconds--);
		}
	}
}
