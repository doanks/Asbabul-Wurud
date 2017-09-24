using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

public class FirebaseInit: MonoBehaviour {

	DatabaseReference baseRef;

	void Start() {
		FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://asbabul-wurud.firebaseio.com/");

		baseRef  = FirebaseDatabase.DefaultInstance.RootReference;

		baseRef.ValueChanged += GetData;
	}

	public DatabaseReference Nikah() {
		return baseRef.Child ("Nikah");
	}

	void GetData (object sender, ValueChangedEventArgs args) {
		if (args.DatabaseError != null) {
			return;
		}
		if (args.Snapshot.Value != null) {
			//Debug.Log (args.Snapshot.Child("fak").Value.ToString());
		}
	}
		
//	void GetData () {
//		Nikah().GetValueAsync().ContinueWith(task => {
//			DataSnapshot dataNikah = task.Result; 
//			Debug.Log(dataNikah);
//
//			foreach (DataSnapshot nnode in dataNikah.Children) {
//				var dict = (IDictionary<string, object>)nnode.Value;
//				Debug.Log("asd");
//			}
//		});
//	}
}


