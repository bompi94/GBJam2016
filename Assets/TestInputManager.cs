using UnityEngine;
using System.Collections;

public class TestInputManager : MonoBehaviour {
	public SceneManager scnMng;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.G)) {
			scnMng.OnSceneChange ();
		}
	}
}
