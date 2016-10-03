using UnityEngine;
using System.Collections;

public class EurydiceScript : MonoBehaviour {
    GameObject orfeo;
    public float speed;
    public bool inStopZone;
    public bool following;
    public SpringJoint2D spring;
    bool seeing;

    // Use this for initialization
    void Start () {
	    orfeo = GameObject.Find("orfeo");
    }
	
	// Update is called once per frame
	void Update () {
        if(orfeo.transform.position.x < transform.position.x)
        {
            transform.localScale = new Vector3(-1, transform.localScale.y); 
        }
        else
        {
            transform.localScale = new Vector3(1, transform.localScale.y);
        }
        if (!inStopZone && following)
        {
            spring.connectedAnchor = orfeo.transform.position;
            //viene verso di me
            if (orfeo.transform.localScale.x != transform.localScale.x)
            {
                spring.enabled = false; 
            }

            else
            {
                if(Vector3.Distance(transform.position,orfeo.transform.position)>=spring.distance)
                spring.enabled = true; 
            }
        }
	}

    public void GiveHand()
    {
        following = true; 
        spring = GetComponent<SpringJoint2D>(); 
        spring.enabled = true; 
    }

    public void LeaveHand()
    {
        following = false;
        spring.enabled = false;
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
