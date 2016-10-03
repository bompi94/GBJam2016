using UnityEngine;
using System.Collections;

public class TransitionPointScript : MonoBehaviour {

	SceneManager scnManager;

	public int goToScene;

	void Start(){
		scnManager = GameObject.Find ("SceneManager").GetComponent<SceneManager> ();
	}

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.name == "orfeo" && coll.GetComponent<Movement> ().pickedUp) {
			scnManager.SceneChange (goToScene);
		}
		if (coll.name == "orfeo" && !coll.GetComponent<Movement> ().pickedUp) {
			Debug.Log ("Prendi Euridice coglione!");
		}
	}
}
