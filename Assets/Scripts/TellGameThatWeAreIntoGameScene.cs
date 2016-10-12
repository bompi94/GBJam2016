using UnityEngine;
using System.Collections;

public class TellGameThatWeAreIntoGameScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject.Find ("GameState").GetComponent<GameState> ().onChangeScene ();
	}
}
