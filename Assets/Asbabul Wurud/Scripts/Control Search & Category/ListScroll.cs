using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ListScroll : MonoBehaviour {

	public static ListScroll instance;

	public Transform scroller;
	public int heightScroller;
	public int tittleCount;

	RectTransform rt;

	void Awake () {
		instance = this;
	}

	void Start () {
		rt = scroller.gameObject.GetComponent<RectTransform> ();
	}
		
	public void ChangePosScroller () {
		
		if (tittleCount <= heightScroller) {
			rt.sizeDelta = new Vector2 (0, heightScroller * 100);
			rt.localPosition = new Vector3 (0,0,0);
		} else {
			rt.sizeDelta = new Vector2 (0,100 * tittleCount);
			rt.localPosition = new Vector3 (0,(tittleCount - heightScroller) * -50,0);
		}
	}

	public void DestroyList () {
		tittleCount = 0;
		foreach (Transform child in scroller.transform) {
			GameObject.Destroy(child.gameObject);
		}
	}
}
