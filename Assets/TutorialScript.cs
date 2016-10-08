using UnityEngine;
using System.Collections;

public class TutorialScript : MonoBehaviour {

	bool used=false;

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.name == "orfeo" && !used) {
			used = true;
			GetComponent<DialogsLevel> ().ShowDialogs ();
		}
	}
}
