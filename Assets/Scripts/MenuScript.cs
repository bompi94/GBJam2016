using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class MenuScript : MonoBehaviour {

	public void OnStartPressed(){
		UnityEngine.SceneManagement.SceneManager.LoadScene ("game");
	}

	public void OnCreditsPressed(){
        UnityEngine.SceneManagement.SceneManager.LoadScene("creditsScene");
    }

    public void OnBackPressed()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }

	public void OnExitPressed(){
		Application.Quit ();
	}
}
