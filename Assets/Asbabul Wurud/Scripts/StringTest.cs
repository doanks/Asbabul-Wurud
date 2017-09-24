using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StringTest : MonoBehaviour {

	public Text teks;
	public string str;

	// Use this for initialization
	void Start () {
		str = "asd\nasd";
		//teks.text = "";

		TextGenerator tg = new TextGenerator ();
		TextGenerationSettings tgs = teks.GetGenerationSettings (teks.gameObject.GetComponent<RectTransform>().rect.size);
		Debug.Log (tg.GetPreferredHeight(teks.text, tgs));
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			teks.text = DatabaseHadis.instance.hadisList[0].teks.ToString();
		}
	}
}
