using UnityEngine;
using System.Collections;

public class EyeProjectileScript : MonoBehaviour
{

    public float speed; 
    public int damages;
    Vector3 targetPos;
    Vector3 dir;
    float timer;
    float ttl = 4;

    void Start()
    {
        if(Vector3.Distance(GameObject.Find("orfeo").transform.position,transform.position) < Vector3.Distance(GameObject.Find("euridice").transform.position, transform.position))
        {
            targetPos = GameObject.Find("orfeo").transform.position;
        }
        else
        {
            targetPos = GameObject.Find("euridice").transform.position;
        }
        dir = targetPos - transform.position; 
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= ttl)
            Destroy(gameObject); 
        transform.position += dir.normalized * Time.deltaTime * speed; 
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.name == "orfeo")
        {

            GameObject.Find("Health").GetComponent<Health>().TakeDamage(damages * 1, "orfeo");
        }
        if (coll.gameObject.name == "euridice")
        {

            GameObject.Find("Health").GetComponent<Health>().TakeDamage(damages * 2, "euridice");
        }

        if (coll.gameObject.name.StartsWith("eye") != true)
            Destroy(gameObject);

    }
}
