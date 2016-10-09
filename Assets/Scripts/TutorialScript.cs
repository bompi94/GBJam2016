using UnityEngine;
using System.Collections;

public class TutorialScript : MonoBehaviour {

	public int tutorialIndex;
	bool used=false;

	GameState game;

	void Start(){
		game = GameObject.Find ("GameState").GetComponent<GameState> ();

		if (!game.tutorialsState.ContainsKey (tutorialIndex)) {
			game.tutorialsState.Add (tutorialIndex, false);
			Debug.Log ("tutorial non visto");
		} else {
			Debug.Log ("tutorial gia visto");
		}
	}

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.name == "orfeo" && !used && game!=null && game.tutorialsState.ContainsKey(tutorialIndex) && !game.tutorialsState[tutorialIndex]) {
			used = true;
			game.tutorialsState [tutorialIndex] = true;
			GetComponent<DialogsLevel> ().ShowDialogs ();
		}
	}

	void OnTriggerStay2D(Collider2D coll){
		if (coll.name == "orfeo" && !used && game.tutorialsState.ContainsKey(tutorialIndex) && !game.tutorialsState[tutorialIndex]) {
			used = true;
			game.tutorialsState [tutorialIndex] = true;
			GetComponent<DialogsLevel> ().ShowDialogs ();
		}
	}
}
