using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour, ISelectHandler, IPointerEnterHandler, IPointerExitHandler
{
	public AudioClip UISelect;
	public AudioClip UIMouseOver;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnSelect(BaseEventData eventData)
    {
        print("selected" + gameObject.name);
		GetComponentInChildren<Text>().color = Color.HSVToRGB(0, 84, 81);
		PlaySound (UIMouseOver);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        print("selected" + gameObject.name);
        GetComponentInChildren<Text>().color = Color.HSVToRGB(0, 84, 81);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        print("selected" + gameObject.name);
        GetComponentInChildren<Text>().color = Color.white; 
    }

	public void OnPointerClick(){
		print("clicked" + gameObject.name);
		PlaySound (UISelect);
	}

	public void OnDeselect(){
		print("deselected" + gameObject.name);
		GetComponentInChildren<Text>().color = Color.white; 
	}

	public void PlaySound(AudioClip sound){
		GetComponent<AudioSource> ().clip = sound;
		GetComponent<AudioSource> ().Play ();
	}
}
