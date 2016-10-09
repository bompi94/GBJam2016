using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameState : MonoBehaviour {

	public Dictionary<int,bool[]> enemyState = new Dictionary<int,bool[]> ();

	public List<string> keysOwned = new List<string> ();

	public List<string> keysTaken = new List<string>();

	public Dictionary<int,bool> doorsState = new Dictionary<int, bool> ();

	public Dictionary<int,bool> tutorialsState = new Dictionary<int, bool> ();

	public GameObject pausePanel;

	public bool inPause=false;

	public int indexLastCheckpointVisited = 0;

	public bool onGameScene=false;

	void Start(){
		GameObject.DontDestroyOnLoad (gameObject);

	}

	void Update(){
		if (onGameScene) {
			if (Input.GetKeyDown (KeyCode.Escape) || Input.GetButtonDown ("pause")) {
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

	public void onChangeScene(){
		onGameScene = true;
		pausePanel = GameObject.Find ("PausePanel");
		pausePanel.SetActive (false);
	}

}
