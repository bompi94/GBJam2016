using UnityEngine;
using System.Collections;

public class ButtonShowEnemy : MonoBehaviour {

    public GameObject[] showSlaves; 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ShowButtons(int[] intbuttons)
    {
        for(int i = 0; i<showSlaves.Length; i++)
        {
            showSlaves[i].GetComponent<ShowSlave>().ShowButton(intbuttons[i]); 
        }
    }

    public void HideButtons()
    {
        foreach (GameObject g in showSlaves)
        {
            g.GetComponent<ShowSlave>().HideButton(); 
        }
    }

    public void DeHighlightButtons()
    {
        for (int i = 0; i < showSlaves.Length; i++)
        {
            showSlaves[i].GetComponent<ShowSlave>().DeHighLight();
        }
    }
}
