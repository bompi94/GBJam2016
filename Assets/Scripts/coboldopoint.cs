using UnityEngine;
using System.Collections;

public class coboldopoint : MonoBehaviour {

    public GameObject coboldo; 

	// Use this for initialization
	void Start () {
	
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.name == "orfeo")
            Instantiate(coboldo, transform.position, Quaternion.identity); 
    }
}
