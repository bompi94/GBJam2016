using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameState : MonoBehaviour {

	public Dictionary<int,bool[]> levelState = new Dictionary<int,bool[]> ();

	public List<string> keysOwned = new List<string> ();

	public List<string> keysTaken = new List<string>();

	public Dictionary<int,bool> doorsState = new Dictionary<int, bool> ();


	public GameObject pausePanel;

	public bool inPause=false;

	void Update(){
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (inPause) {//sono in pausa
				pausePanel.SetActive (false);
				inPause = false;
				Time.timeScale = 1;
			} else {//non sono in pausa
				pausePanel.SetActive (true);
				inPause = true;
				Time.timeScale = 0;
			}
		}
	}
}
