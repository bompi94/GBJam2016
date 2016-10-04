using UnityEngine;
using System.Collections;

public class PlatformScript : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D coll)
    {

        if (coll.gameObject.name == "orfeo" && coll.gameObject.transform.position.y > transform.position.y)
            coll.gameObject.GetComponent<Movement>().Grounded(); 
    }
}
