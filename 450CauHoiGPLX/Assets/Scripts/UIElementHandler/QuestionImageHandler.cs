using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class QuestionImageHandler : MonoBehaviour {

	public GameObject questionInnerLayout;
	private float scaleRatio;
	// Use this for initialization
	void Start () {
		scaleRatio = 2.52f;
	}

	public void scaleToSprite(){
		Sprite mSprite = GetComponent<Image> ().sprite;
		if (mSprite != null) {
			float spriteWidth = mSprite.bounds.size.x;
			float spriteHeight = mSprite.bounds.size.y;
			float ratioWH = spriteWidth / spriteHeight;
			if (ratioWH > scaleRatio) {
				float width = questionInnerLayout.GetComponent<RectTransform> ().sizeDelta.x * 3 / 4;
				float height = width / ratioWH;
				GetComponent<RectTransform> ().sizeDelta = new Vector2 (width, height);
			} else {
				float height = questionInnerLayout.GetComponent<RectTransform> ().sizeDelta.x / 4.5f;
				float width = height * ratioWH;
				GetComponent<RectTransform> ().sizeDelta = new Vector2 (width, height);
			}
		}
	}
}
