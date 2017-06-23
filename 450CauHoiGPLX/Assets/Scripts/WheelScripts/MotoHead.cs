using UnityEngine;
using System.Collections;

public class MotoHead : MonoBehaviour {

	public float turnRate = 2;

	public void smoothLookTo(Transform targetLook){
		iTween.LookTo(gameObject, iTween.Hash("looktarget", targetLook , "time", 0.4f*turnRate, "easeType", iTween.EaseType.linear));
	}
}
