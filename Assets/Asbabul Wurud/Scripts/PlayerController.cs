using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float gearDistance;

	void Update () {
		if (transform.position.x >= 7f) {
			print ("finish");
		}
	}

	public void ChangePos (int gear) {
		transform.position += new Vector3 (gearDistance * gear, 0, 0);
	}
}
