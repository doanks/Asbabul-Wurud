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

		TagManager.instance.DestroyList ();
		string inputtext = inputf.text.ToLower ();
		for(int i=0; i<db.hadisList.Count; i++){

			string dbtitle = db.hadisList [i].title.ToLower();
			string rawi = db.hadisList [i].perawi.ToLower ();

			if ((dbtitle.Contains(inputtext) || rawi.Contains(inputtext)) && inputtext!= "") {

				TagManager.instance.tittleCount++;
				GameObject temp = Instantiate(item, Vector2.zero, Quaternion.identity) as GameObject;
				temp.transform.SetParent(scroller);
				temp.transform.GetComponent<RectTransform>().localScale = Vector3.one;

				db.tempList.Add (db.hadisList [i]);

				ItemList il = temp.GetComponent<ItemList> ();
				il.tittle.text = db.hadisList [i].title;
				il.note.text = db.hadisList [i].perawi;
				il.id = count;
				count++;

			} else {
				print ("not found");
			}
		}
		TagManager.instance.ChangePosScroller ();
		listhadis.SetActive (true);

		if (TagManager.instance.tittleCount <= 0)
			notfound.SetActive (true);
		else
			notfound.SetActive (false);
			
	}

}
