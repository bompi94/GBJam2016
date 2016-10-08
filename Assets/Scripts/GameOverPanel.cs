using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverPanel : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Activate()
    {
        GetComponent<Image>().enabled = true;
        GetComponentInChildren<Text>().enabled = true;
        StartCoroutine(WaitAndDeactivate());
    }

    IEnumerator WaitAndDeactivate()
    {
        print("alfa"); 
        yield return new WaitForSeconds(3);
        Deactivate(); 
    }

    public void Deactivate()
    {
        print("beta"); 
        GetComponent<Image>().enabled = false;
        GetComponentInChildren<Text>().enabled = false;
    }
}
