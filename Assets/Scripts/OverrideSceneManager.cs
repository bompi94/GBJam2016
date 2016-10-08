using UnityEngine;
using System.Collections;

public class OverrideSceneManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<DialogsLevel> ().ShowDialogs ();
	}
}
