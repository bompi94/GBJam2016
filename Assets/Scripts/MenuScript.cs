using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class MenuScript : MonoBehaviour {

	public void OnStartPressed(){
		UnityEngine.SceneManagement.SceneManager.LoadScene ("game");
	}

	public void OnCreditsPressed(){
	}

	public void OnExitPressed(){
		Application.Quit ();
	}
}
