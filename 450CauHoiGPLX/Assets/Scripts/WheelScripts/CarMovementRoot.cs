using UnityEngine;
using System.Collections;

public class CarMovementRoot : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void smoothTurnTo(Transform target){
		iTween.LookTo(gameObject, iTween.Hash("looktarget", target , "time", 0.4f, "easeType", iTween.EaseType.linear));
	}
}
