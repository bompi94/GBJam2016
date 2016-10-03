using UnityEngine;
using System.Collections;

public class orfeoEyes : MonoBehaviour {
    float timer = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer >= .2f)
        {
            timer = 0; 
            GameObject eurydice = GameObject.Find("euridice");
            Debug.DrawRay(transform.position, eurydice.transform.position - transform.position, Color.blue, 10000000);
            RaycastHit2D[] ray = Physics2D.RaycastAll(transform.position, eurydice.transform.position - transform.position);
            if (ray[0].collider.gameObject.name == "euridice")
            {
                ray[0].collider.gameObject.GetComponent<EurydiceScript>().SeeYou(-0.20f); 
            }
            else
            {
                GameObject.Find("euridice").GetComponent<EurydiceScript>().SeeYou(0.15f);
            }
        }
    }
}
