using UnityEngine;
using System.Collections;

public class EurydiceScript : MonoBehaviour {
    GameObject orfeo;
    public float speed;
    public bool following;
    public SpringJoint2D spring;
    bool seeing;
    Animator anim;
    Vector3 oldpos;
    Health health; 

    // Use this for initialization
    void Start () {
	    orfeo = GameObject.Find("orfeo");
        anim = GetComponent<Animator>();
        oldpos = transform.position;  
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
        if (following)
        {
            spring.connectedAnchor = orfeo.transform.position;
            if (orfeo.transform.localScale.x != transform.localScale.x)
            {
                spring.enabled = false; 
            }

            else
            {
                if(Vector3.Distance(transform.position,orfeo.transform.position)>=spring.distance)
                spring.enabled = true; 
            }

            if (Vector3.Distance(transform.position, oldpos) <= 0.05f)
                anim.SetBool("moving", false);
            else
                anim.SetBool("moving", true);
            oldpos = transform.position; 
        }
	}

    public void GiveHand()
    {
        following = true; 
        spring = GetComponent<SpringJoint2D>(); 
        spring.enabled = true;
        anim.SetBool("following", true); 
    }

    public void LeaveHand()
    {
        following = false;
        spring.enabled = false;
        anim.SetBool("following", false);
    }

    public void SeeYou(float time)
    {
        Color temp = GetComponent<SpriteRenderer>().color;
        temp.a *= (1 + time);
        temp.a = Mathf.Clamp(temp.a, 0,1);  
        GetComponent<SpriteRenderer>().color = temp; 
    }

    public void JumpWithMe()
    {
        anim.SetTrigger("jump");
    }

    public void ShowHit()
    {
        StartCoroutine(GotHit());
    }

    IEnumerator GotHit()
    {
        if (health == null)
            health = GameObject.Find("Health").GetComponent<Health>();
        health.euridicecantakedamage = false;
        int cont = 0;
        while (cont < 5)
        {
            cont++;
            Color c = GetComponent<SpriteRenderer>().color;
            c.a = 0;
            GetComponent<SpriteRenderer>().color = c;
            yield return new WaitForSeconds(0.1f);
            c.a = 1;
            GetComponent<SpriteRenderer>().color = c;
            yield return new WaitForSeconds(0.1f);

        }
        health.euridicecantakedamage = true;
    }
}
