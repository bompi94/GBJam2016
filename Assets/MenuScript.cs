using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class MenuScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnStartPressed(){
		UnityEngine.SceneManagement.SceneManager.LoadScene (1);
	}

	public void OnCreditsPressed(){
	}

	public void OnExitPressed(){
		Application.Quit ();
	}


}
