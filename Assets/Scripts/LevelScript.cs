using UnityEngine;
using System.Collections;
using System;

public class LevelScript : MonoBehaviour {

	public int levelIndex;
	public GameObject[] enemies;
	GameState state;
	public TransitionPointScript[] portals;
	public bool isCheckpoint;
	// Use this for initialization
	void Start () {
		state=GameObject.Find ("GameState").GetComponent<GameState> ();
		portals = GetComponentsInChildren<TransitionPointScript> ();
		if (!state.enemyState.ContainsKey (levelIndex)) {
			//è la prima volta che accedo a questo livello, setto tutti a true
			Debug.Log("First load of this level:"+levelIndex);
			if (enemies.Length > 0) {
				bool[] livingEnemies = new bool[enemies.Length];
				for (int i = 0; i < enemies.Length; i++) {
					livingEnemies [i] = true;
				}
				state.enemyState.Add (levelIndex, livingEnemies);
			} else {
				state.enemyState.Add (levelIndex, new bool[0]);
			}
		} else {
			Debug.Log("Not first load, destroing enemies (level:"+levelIndex+")");
			//non è la prima volta che accedo a questo livello, leggo dal dizionario chi uccidere
			bool[] livingEnemies=state.enemyState[levelIndex];
			for (int i = 0; i < livingEnemies.Length; i++) {
				if (!livingEnemies [i]) {
					Debug.Log ("killing enemy " + enemies [i]);
					enemies [i].SetActive (false);
				}
			}
		}
		if(IsAllEnemyDied ()){
			//se sono morti tutti, chiamo la funzione AllEnemyDied
			Debug.Log("All Enemy of level "+levelIndex+" Died!");
			AllEnemyDied();
		}
		if (isCheckpoint) {
			state.indexLastCheckpointVisited = levelIndex;
		}
	}

	public void EnemyDied(GameObject enemy){
		Debug.Log ("enemy ad index " + Array.IndexOf (enemies, enemy) + " died");
		state.enemyState [levelIndex] [Array.IndexOf (enemies, enemy)] = false;
		if(IsAllEnemyDied ()){
			//se sono morti tutti, chiamo la funzione AllEnemyDied
			Debug.Log("All Enemy of level "+levelIndex+" Died!");
			AllEnemyDied();
		}

	}

	public bool IsAllEnemyDied(){
		foreach (bool enemy in state.enemyState [levelIndex]) {
			Debug.Log ("enemy died " + enemy);
		}
		bool someoneAlive=Array.Find (state.enemyState [levelIndex], (item) => {
			return item;
		});
		return !someoneAlive;
	}

	void AllEnemyDied(){
		//attivo i portali
		foreach (TransitionPointScript portal in portals) {
			portal.GetComponent<BoxCollider2D> ().enabled = true;
		}
	}
		
}
