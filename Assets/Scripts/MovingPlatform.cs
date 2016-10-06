using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {

    public float speed;
    public GameObject pos1;
    public GameObject pos2;
    bool goingToPos1; 

	// Use this for initialization
	void Start () {
        transform.position = pos1.transform.position; 
	}
	
	// Update is called once per frame
	void Update () {
        if (Vector3.Distance(transform.position, pos1.transform.position) < 0.1)
        {
            goingToPos1 = false;
        }

        if (Vector3.Distance(transform.position, pos2.transform.position) < 0.1)
        {
            goingToPos1 = true;
        }

        Vector3 dir = Vector3.zero; 

        if (goingToPos1)
        {
            dir = pos1.transform.position - transform.position; 
        }

        else
            dir = pos2.transform.position - transform.position;

        if (GetComponent<Rigidbody2D>() == null)
            transform.position += dir * Time.deltaTime * speed;
        else
            GetComponent<Rigidbody2D>().velocity = (dir.normalized * Time.deltaTime * speed);
        
         
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name == "orfeo")
            coll.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.name == "orfeo")
            coll.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX;
    }
}
