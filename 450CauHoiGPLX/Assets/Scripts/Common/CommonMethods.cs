using UnityEngine;
using System.Collections;
using System.Text;

public static class CommonMethods {

	public static string secondsToMMSS(int totalSeconds){
		int minute = totalSeconds / 60;
		int seconds = totalSeconds -  minute * 60;
		return minute + " : " + seconds;
	}

	public static float distanceToPoint(Vector3 point1, Vector3 point2){
		return Vector3.Distance (point1, point2);
	}

	public static string DecodeFromUtf8(this string utf8String)
	{
		// copy the string as UTF-8 bytes.
		byte[] utf8Bytes = new byte[utf8String.Length];
		for (int i=0;i<utf8String.Length;++i) {
			//Debug.Assert( 0 <= utf8String[i] && utf8String[i] <= 255, "the char must be in byte's range");
			utf8Bytes[i] = (byte)utf8String[i];
		}

		return Encoding.UTF8.GetString(utf8Bytes,0,utf8Bytes.Length);
	}

}
