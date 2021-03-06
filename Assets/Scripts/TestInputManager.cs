﻿using UnityEngine;
using System.Collections;

public class TestInputManager : MonoBehaviour {
	public SceneManager scnMng;

	int i=0;
	int[][] transitions=new int[3][]{new int[3]{1,2,-1},new int[3]{3,4,0},new int[3]{5,6,0}};
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.G)) {
			Debug.Log ("Next scene=" + transitions[i][0]);
			SceneManager.ChangeScene (transitions[i][0],false);
			i = transitions [i] [0];
		} else if (Input.GetKeyDown (KeyCode.H)) {
			Debug.Log ("Next scene=" + transitions[i][1]);
			SceneManager.ChangeScene (transitions[i][1],false);
			i = transitions [i] [1];
		} else if (Input.GetKeyDown (KeyCode.B)) {
			Debug.Log ("Next scene=" + transitions[i][2]);
			SceneManager.ChangeScene (transitions[i][2],true);
			if (transitions [i] [2] != -1) {
				i = transitions [i] [2];
			} else {
				i = 0;
			}
		}
	}
}
