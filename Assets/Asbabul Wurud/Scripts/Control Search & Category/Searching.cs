using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class Searching : MonoBehaviour {

	public DatabaseHadis db;
	public InputField inputf;
	public GameObject item;
	public Transform scroller;
	public GameObject listhadis;
	public GameObject notfound;

	void Awake () {
		db = FindObjectOfType<DatabaseHadis> ();
	}

	// Use this for initialization
	public void Btnsearch() {
		
		db.tempList.Clear ();
		int count = 0;

		ListScroll.instance.DestroyList ();

		//HASIL INPUTAN DIUBAH JADI HURUF KECIL
		string inputtext = inputf.text.ToLower ();

		//MENCARI SETIAP DATA DARI DATABASE
		foreach (var data in db.hadisList) {
			string dbtitle = data.title.ToLower ();
			string rawi = data.perawi.ToLower ();

			if ((dbtitle.Contains (inputtext) || rawi.Contains (inputtext)) && inputtext != "") {
				
				ListScroll.instance.tittleCount++;
				GameObject temp = Instantiate(item, Vector2.zero, Quaternion.identity) as GameObject;
				temp.transform.SetParent(scroller);
				temp.transform.GetComponent<RectTransform>().localScale = Vector3.one;

				db.tempList.Add (data);
				ItemList il = temp.GetComponent<ItemList> ();
				il.tittle.text = data.title;
				il.note.text = data.perawi;
				il.id = count;
				count++;
			}
		}

		ListScroll.instance.ChangePosScroller ();
		listhadis.SetActive (true);

		if (ListScroll.instance.tittleCount <= 0)
			notfound.SetActive (true);
		else
			notfound.SetActive (false);
			
	}

}
