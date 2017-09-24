using UnityEngine;
using System.Collections;

[System.Serializable]
public class ListData {

	public int id;
	public string tittle;
	[TextArea(3,10)]
	public string text;
	public bool ibnu, imam;

	public ListData(int _id, string _tittle, string _text, bool ibnu, bool imam){
		id = _id;
		tittle = _tittle;
		text = _text;
		this.ibnu = ibnu;
		this.imam = imam;
	}
}

[System.Serializable]
public class FullDatabase {

	public int id;
	public string tittle;
	public string note;
}
