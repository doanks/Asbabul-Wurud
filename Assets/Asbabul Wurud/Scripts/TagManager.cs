using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class TagManager : MonoBehaviour {

	public static TagManager instance;

	public Transform scroller;
	public int heightScroller;

	public int tittleCount;
	public Canvas cv;
	RectTransform rt;

	public ListDatabase ldb;
	public GameObject item;

	void Awake () {
		instance = this;
	}

	void Start () {

		rt = scroller.gameObject.GetComponent<RectTransform> ();
		//ShowAllData ();
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

	void ShowAllData () {
		for (int i = 0; i < ldb.listDb.Count; i++) {
			tittleCount++;
			GameObject temp = Instantiate(item, Vector2.zero, Quaternion.identity) as GameObject;
			temp.transform.SetParent(scroller);
			temp.transform.GetComponent<RectTransform>().localScale = Vector3.one;
			ItemList il = temp.GetComponent<ItemList> ();
			il.tittle.text = ldb.listDb [i].tittle;
			il.note.text = ldb.listDb [i].text;
			il.id = ldb.listDb [i].id;
		}
		ChangePosScroller ();
	}

	public void SearchData (int id) {
		
		DestroyList ();
		for (int i = 0; i < ldb.listDb.Count; i++) {
			if (TagSearching(id, i)) {
				tittleCount++;
				GameObject temp = Instantiate(item, Vector2.zero, Quaternion.identity) as GameObject;
				temp.transform.SetParent(scroller);
				temp.transform.GetComponent<RectTransform>().localScale = new Vector3 (1,1,1);
				ItemList il = temp.GetComponent<ItemList> ();
				il.tittle.text = ldb.listDb [i].tittle;
				il.note.text = ldb.listDb [i].text;
				il.id = ldb.listDb [i].id;
			}
		}
		ChangePosScroller ();
	}

	bool TagSearching (int id, int lid) {
		if (id == 0) {
			return ldb.listDb [lid].ibnu;
		} 
		else {
			return ldb.listDb [lid].imam;
		}
			
	}
}
