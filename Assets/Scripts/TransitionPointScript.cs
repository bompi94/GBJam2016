using UnityEngine;
using System.Collections;

public class TransitionPointScript : MonoBehaviour {

	public int goToScene;
	public bool goingBack;

	public bool playerExited = true;


	void OnTriggerEnter2D(Collider2D coll){
		if (coll.name == "orfeo" && coll.GetComponent<Movement> ().pickedUp && playerExited) {
			//scnManager.SceneChange (goToScene,goingBack);
			SceneManager.UnityStronzo ();
			SceneManager.ChangeScene (goToScene,goingBack);
		}
		if (coll.name == "orfeo" && !coll.GetComponent<Movement> ().pickedUp && playerExited) {
			Debug.Log ("Prendi Euridice coglione!");
		}
	}

	void OnTriggerExit2D(Collider2D coll){
		if (!playerExited) {
			playerExited = true;
			Debug.Log ("Trigger Reactived");
		}
	}

	public void DeactivateUntilExit(){
		//disattivo il trigger finchè il player non si sposta
		playerExited=false;
	}
}
