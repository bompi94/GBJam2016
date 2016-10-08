using UnityEngine;
using System.Collections;

public class DialogsLevel : MonoBehaviour {

	public string[] dialogs;

	public Sprite[] bubbleSpeechForCharacters;

	public bool dialogEnabled=true;

	public void ShowDialogs(){
		if(dialogEnabled)
			GameObject.Find ("DialogsManager").GetComponent<DialogsScript> ().StartDialogs (dialogs, bubbleSpeechForCharacters);
	}
}
