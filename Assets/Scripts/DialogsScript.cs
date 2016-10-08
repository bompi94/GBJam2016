using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DialogsScript : MonoBehaviour {

	string[] dialogs;//nel formato indiceCharacter:messaggio

	public int dialogIndex = -1;

	DialogGameObject[] charactersCanvas;

	public bool dialogFinished=true;

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
			Time.timeScale = 0;
			dialogIndex = -1;
			dialogFinished = false;
			this.dialogs = dialogs;
			for(int i=0;i<bubbles.Length;i++){
				charactersCanvas[i].GetComponentInChildren<Image> ().sprite = bubbles [i];
				//canvas.gameObject.SetActive (false);
			}
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
