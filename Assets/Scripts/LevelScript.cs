using UnityEngine;
using System.Collections;
using System;

public class LevelScript : MonoBehaviour {

	public int levelIndex;
	public GameObject[] enemies;
	GameState state;
	// Use this for initialization
	void Start () {
		state=GameObject.Find ("GameState").GetComponent<GameState> ();
		if (!state.levelState.ContainsKey (levelIndex)) {
			//è la prima volta che accedo a questo livello, setto tutti a true
			Debug.Log("First load of this level:"+levelIndex);
			if (enemies.Length > 0) {
				bool[] livingEnemies = new bool[enemies.Length];
				for (int i = 0; i < enemies.Length; i++) {
					livingEnemies [i] = true;
				}
				state.levelState.Add (levelIndex, livingEnemies);
			} else {
				state.levelState.Add (levelIndex, new bool[0]);
			}
		} else {
			Debug.Log("Not first load, destroing enemies (level:"+levelIndex+")");
			//non è la prima volta che accedo a questo livello, leggo dal dizionario chi uccidere
			bool[] livingEnemies=state.levelState[levelIndex];
			for (int i = 0; i < livingEnemies.Length; i++) {
				if (!livingEnemies [i]) {
					Debug.Log ("killing enemy " + enemies [i]);
					enemies [i].SetActive (false);
				}
			}
		}
	}

	public void EnemyDied(GameObject enemy){
		Debug.Log ("enemy ad index " + Array.IndexOf (enemies, enemy) + " died");
		state.levelState [levelIndex] [Array.IndexOf (enemies, enemy)] = false;
	}
}
