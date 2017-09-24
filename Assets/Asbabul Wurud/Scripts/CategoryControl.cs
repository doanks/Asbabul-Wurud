using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CategoryControl : MonoBehaviour {
	
	public DatabaseHadis dbase;

	public GameObject item;
	public Transform scroller;
	public GameObject windowItem;
	public GameObject circleMenu;

	void Start () {
		dbase = FindObjectOfType<DatabaseHadis> ();
	}

	//FUNGSI TOMBOL LIST KATEGORI
	public void ButtonHolder (string cat) {

		circleMenu.SetActive (false);
		
		TagManager.instance.DestroyList ();
		dbase.tempList.Clear ();
		int count = 0;

		for (int i = 0; i < dbase.hadisList.Count; i++) {

			if (dbase.hadisList [i].kategori.Contains (cat)) {

				TagManager.instance.tittleCount++;
				GameObject temp = Instantiate(item, Vector2.zero, Quaternion.identity) as GameObject;
				temp.transform.SetParent(scroller);
				temp.transform.GetComponent<RectTransform>().localScale = Vector3.one;
				dbase.tempList.Add (dbase.hadisList [i]);
				ItemList il = temp.GetComponent<ItemList> ();
				il.tittle.text = dbase.hadisList [i].title;
				il.note.text = dbase.hadisList [i].perawi;
				il.id = count;
				count++;
			}
		}
		TagManager.instance.ChangePosScroller ();
		windowItem.SetActive (true);
	}
}
