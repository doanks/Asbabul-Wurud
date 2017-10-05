using UnityEngine;
using UnityEngine.UI;
using System.Collections;
//using TMPro;

public class MenuManager : MonoBehaviour {

	public static MenuManager instance;

	public GameObject fade;
	public Animator[] btnAnim;
	public ScrollRect scrl;
	public Text headerText;
	public GameObject content, contentSuccess;
	public RectTransform hadisRt;
	public Text teksTitle;
	public Text teksBody;
//	public TextMeshProUGUI tmBody;
	public Image teksImage;

	[Header("disable this")]
	public GameObject[] panel;

	private bool tagShow = true;

	DatabaseHadis dbase;

	void Awake () {
		instance = this;
		dbase = FindObjectOfType<DatabaseHadis> ();
	}
//
//	void Start () {
//		Vector2 tmHeight = tmBody.GetRenderedValues( (tmBody.text);
//		print (tmHeight);
//	}

	void Update () {
		//print("fps: " + 1f/Time.deltaTime);
	}

	public void ChangeHeader (string ht) {
		headerText.text = ht;
	}

	bool triggerAnim;
	public void ButtonMenu () {
		
		if (!triggerAnim) {
			triggerAnim = true;
			StartCoroutine (DelayAnim ());
		}
	}

	IEnumerator DelayAnim () {
		fade.SetActive (tagShow);
		for (int i = 0; i < btnAnim.Length; i++){
			btnAnim[i].SetBool ("show", tagShow);
			yield return new WaitForSeconds (0.05f);
		}
		tagShow = !tagShow;
		triggerAnim = false;
	}

	public void ShowDetail (int id) {

		StartCoroutine (GetImageDatabase (id, dbase.tempList [id].url_ayat));

		//MENAMPILKAN KONTEN
		content.SetActive (true);

	}

	IEnumerator GetImageDatabase (int id, string url) {

		//yield return null;
		WWW www = new WWW(url);
		yield return www;
		teksImage.sprite = Sprite.Create (www.texture, new Rect (0, 0, www.texture.width, www.texture.height), new Vector2 (0, 0));

		//GENERATE PANJANG IMAGE UNTUK AYAT
		teksImage.SetNativeSize();
		float width = teksImage.gameObject.GetComponent<RectTransform>().rect.width;
		float heigh = (teksImage.gameObject.GetComponent<RectTransform> ().rect.height) / width * 400;
		teksImage.gameObject.GetComponent<RectTransform> ().sizeDelta = new Vector2 (400, heigh);
		teksImage.gameObject.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0,-(heigh / 2) - 100);

		//MENGAMBIL DATA KATEGORI UNTUK DIMASUKKAN KE UI
		teksTitle.text = dbase.tempList [id].title;
		teksBody.text = dbase.tempList [id].teks.Replace ('$', '\n');

		//GENERATE POSISI TEKS SETELAH AYAT(GAMBAR)
		teksBody.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(0,-140 - heigh);

		//GENERATE PANJANG VERTIKAL TEKS & SESUAIKAN KE PARAMETER HEIGHT PARENT
		TextGenerator tg = new TextGenerator ();
		TextGenerationSettings tgs = teksBody.GetGenerationSettings (teksBody.gameObject.GetComponent<RectTransform>().rect.size);
		float textHeight = tg.GetPreferredHeight (teksBody.text, tgs) + heigh + 200;

		hadisRt.sizeDelta = new Vector2(0, textHeight);
		float changePos = -(textHeight - 800) / 2;
		hadisRt.localPosition = new Vector2 (0, changePos);

		contentSuccess.SetActive (true);
	}

	public void Back () {
		teksImage.sprite = null;
	}

	public void DisablePanel () {
		for (int i = 0; i < panel.Length; i++) {
			panel [i].SetActive (false);
		}
	}

	public void Exit () {
		Application.Quit ();
	}
}
