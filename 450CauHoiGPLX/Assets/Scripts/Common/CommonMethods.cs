using UnityEngine;
using System.Collections;

public class CommonMethods {

	public static string secondsToMMSS(int totalSeconds){
		int minute = totalSeconds / 60;
		int seconds = totalSeconds -  minute * 60;
		return minute + " : " + seconds;
	}

	public static float distanceToPoint(Vector3 point1, Vector3 point2){
		return Vector3.Distance (point1, point2);
	}
}
