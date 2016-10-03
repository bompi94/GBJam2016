using UnityEngine;
using System.Collections;

public class CoboldoScript : MonoBehaviour {

	public void OnTriggerEnter2D(Collider2D coll)
    {
        if (!GetComponent<EnemyScript>().good)
        {
            if (coll.gameObject.name == "orfeo")
            {
                GetComponent<EnemyScript>().DealDamage(1,"orfeo");
            }
            else if (coll.gameObject.name == "euridice")
                GetComponent<EnemyScript>().DealDamage(2,"euridice");
        }
    }
}
