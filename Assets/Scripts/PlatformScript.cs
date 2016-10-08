using UnityEngine;
using System.Collections;

public class PlatformScript : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D coll)
    {

        if (coll.gameObject.name == "orfeo" && coll.gameObject.transform.position.y > transform.position.y)
            coll.gameObject.GetComponent<Movement>().Grounded(); 

		if (coll.gameObject.name == "warg" && coll.gameObject.transform.position.y > transform.position.y) {
			//Debug.Log ("doggo ground");
			//coll.gameObject.GetComponent<WargAI> ().Grounded (); 
		}
		
    }

	void OnCollisionExit2D(Collision2D coll)
	{
		if (coll.gameObject.name == "warg" && coll.gameObject.transform.position.y > transform.position.y) {
			coll.gameObject.GetComponent<Rigidbody2D> ().isKinematic = false; 
		}
	}
}
