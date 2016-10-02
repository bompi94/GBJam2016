using UnityEngine;
using System.Collections;

public class ShowSlave : MonoBehaviour {

    public Sprite[] buttons; 


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ShowButton(int param)
    {
        GetComponent<SpriteRenderer>().sprite = buttons[param]; 
    }

    public void HideButton()
    {
        GetComponent<SpriteRenderer>().sprite = null; 
    }
}
