using UnityEngine;
using System.Collections;

public class TouchUtils {

	public static float get2Ddistance(Vector3 vectorA, Vector3 vectorB){
		return Vector3.Distance (new Vector3 (vectorA.x, vectorA.y, 0), new Vector3 (vectorB.x, vectorB.y, 0));
	}

	public static string getDragDirection(Vector3 vectorA, Vector3 vectorB){
		float horizontalDistance = vectorB.x - vectorA.x;
		if (horizontalDistance < 0)
			horizontalDistance = -horizontalDistance;
		float verticalDistance = vectorB.y - vectorA.y;
		if (verticalDistance < 0)
			verticalDistance = -verticalDistance;
		if (horizontalDistance < verticalDistance)
			return UtilsConstanst.VERTICAL;
		else
			return UtilsConstanst.HORIZONTAL;
	}

	public static string getDragHorizontalDirection(Vector2 begin, Vector2 end){	
		float horizontalDistance = begin.x - end.x;
		if (horizontalDistance < 0)
			return UtilsConstanst.DRAG_LEFT;
		return UtilsConstanst.DRAG_RIGHT;
	}
}	
