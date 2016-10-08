using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DialogsScript : MonoBehaviour {

	string[] dialogs;//nel formato indiceCharacter:messaggio

	int dialogIndex = -1;

	DialogGameObject[] charactersCanvas;

	bool dialogFinished=true;

	public bool dialogsEnabled;

	// Use this for initialization
	void Start () {
		charactersCanvas = GameObject.Find ("Dialog").GetComponentsInChildren<DialogGameObject> ();
	}

	public void StartDialogs(string[] dialogs, Sprite[] bubbles){
		Debug.Log ("Start Dialogs");
		if (!dialogsEnabled) {
			dialogFinished = true;
		} else {
			dialogIndex = -1;
			dialogFinished = false;
			this.dialogs = dialogs;
			int i = 0;
			foreach (DialogGameObject canvas in charactersCanvas) {
				canvas.GetComponentInChildren<Image> ().sprite = bubbles [i];
				i++;
				//canvas.gameObject.SetActive (false);
			}
			Time.timeScale = 0;
			ShowNextMessage ();
		}

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
			//Destroy (gameObject);
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
