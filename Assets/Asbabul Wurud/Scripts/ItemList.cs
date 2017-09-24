using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ItemList : MonoBehaviour {

	public Text tittle;
	public Text note;
	public int id;

	public void ClickHolder () {
		MenuManager.instance.ShowDetail (id);
	}
}
