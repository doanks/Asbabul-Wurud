using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

	public void GantiScene (string namaScene) {
		SceneManager.LoadScene (namaScene);
	}

	public void BlinkBlink (GameObject obj) {

	}
}
