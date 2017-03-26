using UnityEngine;
using System.Collections;

public interface CarBehaviorInterface{

	void moveToNextPoint ();
	void stop ();
	void startEngine ();
	void runEngine ();
	void speedChange (float nextSpeed, float celerate);

}
