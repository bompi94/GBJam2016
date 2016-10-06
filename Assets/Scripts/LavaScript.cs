using UnityEngine;
using System.Collections;

public class LavaScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.name == "orfeo" || coll.gameObject.name == "euridice")
        {
            GameObject.Find("Health").GetComponent<Health>().Die();
        }
        else
            coll.gameObject.GetComponent<EnemyScript>().GetGood(); 
    }
}
