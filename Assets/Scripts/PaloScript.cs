using UnityEngine;
using System.Collections;

public class PaloScript : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.name == "euridice" && Mathf.Abs(transform.parent.position.x - coll.gameObject.transform.position.x) < 0.2)
            GetComponent<Collider2D>().enabled = false; 


    }
}
