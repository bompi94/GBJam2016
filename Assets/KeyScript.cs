using UnityEngine;
using System.Collections;

public class KeyScript : MonoBehaviour {

	public string keyName;

	GameState state;

	void Start(){
		state = GameObject.Find ("GameState").GetComponent<GameState> ();
		if (state.keysTaken.Contains (keyName)) {
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.tag == "Player" && !state.keysOwned.Contains(keyName)) {
			state.keysOwned.Add (keyName);
			state.keysTaken.Add (keyName);
			Destroy (gameObject);
		}
	}
}
