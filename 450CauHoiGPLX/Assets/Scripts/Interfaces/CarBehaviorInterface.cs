using UnityEngine;
using System.Collections;

public interface CarBehaviorInterface{

	void moveToNextPoint ();
	void stop ();
	void showPopupInfo ();
	void hidePopupInfo ();
	void startEngine ();
	void speedChange (float nextSpeed, float celerate);

}
