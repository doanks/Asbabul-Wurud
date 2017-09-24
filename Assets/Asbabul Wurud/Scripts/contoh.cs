using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class contoh : MonoBehaviour {

	public string[] nama;
	public string[] kelas;
	public int[] umur;

	void Start () {
		
		nama = new string[2];
		kelas = new string[2];
		umur = new int[2];
		nama [0] = "andi";
		nama [1] = "upa";
	}

	public Biodata[] bio;

	void ASD () {
	
		bio = new Biodata[2];
		bio [0].kelas = "andi";
		bio [0].nama = "upa";

		bio [1] = new Biodata ("nia", "IPA");
	}

	public List<Biodata> bioList = new List<Biodata> ();

	void BNM () {
		bioList.Add (new Biodata ("asd", "zxc"));
	}
}

public class Biodata {

	public string nama;
	public string kelas;

	public Biodata(string nm, string kls) {
		nama = nm;
		kelas = kls;
	}
}
