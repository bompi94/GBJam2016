using UnityEngine;
using System.Collections;

public class EurydiceScript : MonoBehaviour {
    GameObject orfeo;
    public float speed;
    public bool inStopZone; 

	// Use this for initialization
	void Start () {
	    orfeo = GameObject.Find("orfeo");
    }
	
	// Update is called once per frame
	void Update () {
        if (!inStopZone)
        {
            Vector3 dir = orfeo.transform.position - transform.position;
            dir.y = 0;
            transform.position += dir.normalized * Time.deltaTime * speed;
        }
	}

    public void Up(Vector3 pos)
    {
        transform.position = pos; 
    }

    public void SeeYou(float time)
    {

        Color temp = GetComponent<SpriteRenderer>().color;
        temp.a *= (1 + time);
        temp.a = Mathf.Clamp(temp.a, 0,1);  
        GetComponent<SpriteRenderer>().color = temp; 
    }
}
