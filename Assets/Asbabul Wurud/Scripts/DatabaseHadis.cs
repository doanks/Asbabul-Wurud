using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using System;

[System.Serializable]
public class Hadis {
	//public int id;
	public string kategori;
	public string title;
	public string perawi;
	public string teks;
	public string url_ayat;

	//public Hadis (int id, string kategori, string title, string perawi, string teks, string url_ayat) {
	public Hadis (string kategori, string title, string perawi, string teks, string url_ayat) {
		//this.id = id;
		this.kategori = kategori;
		this.title = title;
		this.perawi = perawi;
		this.teks = teks;
		this.url_ayat = url_ayat;
	}

	public Hadis (IDictionary<string, object> dict) {
		//this.id = Convert.ToInt32(dict ["id"]);
		this.kategori = dict ["kategori"].ToString ();
		this.title = dict ["title"].ToString ();
		this.perawi = dict ["perawi"].ToString ();
		this.teks = dict ["teks"].ToString ();
		this.url_ayat = dict ["url_ayat"].ToString ();
	}
}

public class DatabaseHadis : MonoBehaviour {

	public static DatabaseHadis instance;

	public GameObject menu, req;

	public List<Hadis> hadisList = new List<Hadis> ();
	public List<Hadis> tempList = new List<Hadis> ();

	DatabaseReference baseRef;


	void Awake() {
		instance = this;

		//FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://asbabul-wurud.firebaseio.com/");
		FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://hadis-c469a.firebaseio.com/");
		baseRef = FirebaseDatabase.DefaultInstance.RootReference;

		hadisList.Clear ();

		GetHaidis (result => {
			hadisList = result;
			Debug.Log(hadisList[0].kategori);
		});
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			
		}
	}

	public void GetHaidis(Action<List<Hadis>> completionBlock) {
		List<Hadis> tmpList = new List<Hadis> ();

		baseRef.GetValueAsync ().ContinueWith (task => {

			if (task.IsFaulted) {
				// Handle the error...
			}
			else if (task.IsCompleted) {
				DataSnapshot snapshot = task.Result;
				req.SetActive(true);

				DataSnapshot hadis = task.Result;

				foreach(DataSnapshot hadisNode in hadis.Children){
					var hadisDict = (IDictionary<string, object>)hadisNode.Value;
					Hadis newHadis = new Hadis(hadisDict);
					tmpList.Add(newHadis);
				}

				completionBlock(tmpList);
				menu.SetActive(true);
				req.SetActive(false);
			}
		});
	}
}