using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour {

	GameState gameState;
	public int doorindex;
	public string keyNameNeeded;
	BoxCollider2D wallCollider;
    public Sprite aperta; 
	public AudioClip enterInDoorSound;
	// Use this for initialization
	void Start () {
		gameState = GameObject.Find ("GameState").GetComponent<GameState> ();
		enterInDoorSound = GameObject.Find ("SoundsManager").GetComponent<SoundsScript> ().enterInDoorSound;
		wallCollider = gameObject.transform.FindChild ("Wall").GetComponent<BoxCollider2D> ();
		if (gameState.doorsState.ContainsKey (doorindex)) {
			if (gameState.doorsState[doorindex]) { // if open
				OpenDoor(false);
			}
		} else {
			gameState.doorsState.Add (doorindex, false); // not open
		}
	}

	void OnTriggerEnter2D(Collider2D coll){
		if(coll.tag=="Player" && gameState.keysOwned.Contains(keyNameNeeded)){
			OpenDoor (true);
			gameState.keysOwned.Remove (keyNameNeeded);
		}
	}

	void OpenDoor(bool playSound){
		Debug.Log ("Open Door");
		if(playSound)
			SoundsScript.PlayOneShot ("enterInDoor", enterInDoorSound, GameObject.Find("SoundsManager").GetComponent<AudioSource> ());
        GetComponent<SpriteRenderer>().sprite = aperta;
        wallCollider.enabled = false;
		GetComponent<BoxCollider2D> ().enabled = false;
		if (gameState.doorsState.ContainsKey (doorindex)) {
			gameState.doorsState[doorindex] = true;
		} 
		//enabled = false;
	}
}
