using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DialogsScript : MonoBehaviour {

	public string[] dialogs;//nel formato indiceCharacter:messaggio

	public int dialogIndex = -1;

	public DialogGameObject[] charactersCanvas;

	public bool dialogFinished=false;

	// Use this for initialization
	void Start () {
		charactersCanvas=GameObject.Find("Dialog").GetComponentsInChildren<DialogGameObject>();
		Time.timeScale = 0;
		ShowNextMessage ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!dialogFinished) {
			if (Input.GetMouseButtonDown (0)) {
				ShowNextMessage ();
			}
		} else {
			foreach (DialogGameObject canvas in charactersCanvas) {
				canvas.gameObject.SetActive (false);
			}
			Destroy (gameObject);
			Time.timeScale = 1;
		}
	}

	void ShowNextMessage(){
		dialogIndex++;
		if (dialogIndex < dialogs.Length) {
			string[] data = dialogs [dialogIndex].Split (':');
			Debug.Log ("character " + data [0] + " say " + data [1]);
			foreach (DialogGameObject canvas in charactersCanvas) {
				canvas.gameObject.SetActive (false);
			}
			charactersCanvas [int.Parse (data [0])].gameObject.SetActive (true);
			charactersCanvas [int.Parse (data [0])].GetComponentInChildren<Text> ().text = data [1];
		} else {
			dialogFinished = true;
		}
					
	}
}
