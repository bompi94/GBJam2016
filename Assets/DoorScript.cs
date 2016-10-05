using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour {

	GameState gameState;
	public int doorindex;
	public string keyNameNeeded;
	BoxCollider2D wallCollider;
	// Use this for initialization
	void Start () {
		gameState = GameObject.Find ("GameState").GetComponent<GameState> ();
		wallCollider = gameObject.transform.FindChild ("Wall").GetComponent<BoxCollider2D> ();
		if (gameState.doorsState.ContainsKey (doorindex)) {
			if (gameState.doorsState[doorindex]) { // if open
				OpenDoor();
			}
		} else {
			gameState.doorsState.Add (doorindex, false); // not open
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D coll){
		if(coll.tag=="Player" && gameState.keysOwned.Contains(keyNameNeeded)){
			OpenDoor ();
			gameState.keysOwned.Remove (keyNameNeeded);
		}
	}

	void OpenDoor(){
		Debug.Log ("Open Door");
		wallCollider.enabled = false;
		GetComponent<SpriteRenderer> ().enabled = false;
		GetComponent<BoxCollider2D> ().enabled = false;
		//enabled = false;
	}
}
