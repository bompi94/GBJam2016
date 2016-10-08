using UnityEngine;
using System.Collections;

public class PotionScript : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D coll)
    {
        GameObject.Find("Health").GetComponent<Health>().FullHealth();
        Destroy(gameObject); 
    }
}
