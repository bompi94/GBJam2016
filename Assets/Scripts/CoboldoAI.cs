﻿using UnityEngine;
using System.Collections;

public class CoboldoAI : MonoBehaviour
{

    public float sightRange;
    public bool attacking;
    protected float speed;
    public float chargeDistance; 
    protected GameObject orfeo;
    protected Vector3 startingPosition;
    public Vector3 targetPos; 
    public bool steppingBack;
    protected Animator anim;
    public GameObject buttonShower;
    public GameObject eyes; 

	public float hForce;

	//Rigidbody2D enemyRigidbody;

    void Start()
    {
        orfeo = GameObject.Find("orfeo");
		GameObject euridice = GameObject.Find ("euridice");
        startingPosition = transform.position;
        anim = GetComponent<Animator>();
	//	enemyRigidbody = GetComponent<Rigidbody2D> ();
		Physics2D.IgnoreCollision (GetComponent<PolygonCollider2D> (), orfeo.GetComponent<BoxCollider2D> ());
		Physics2D.IgnoreCollision (GetComponent<PolygonCollider2D> (), euridice.GetComponent<BoxCollider2D> ());
        speed = .5f;
    }

    // Update is called once per frame
    void Update()
    {

        Flip();
       
        if (Vector3.Distance(transform.position, orfeo.transform.position) <= sightRange 
            && 
            CanSeeHim())
            attacking = true;
        else
        {
            attacking = false;
            anim.SetBool("attacking", false);
        }

        if (!GetComponent<EnemyScript>().good)
        {
            if (attacking)
            {
                
                AttackOrfeo();
            }

            else
            {
                steppingBack = false; 
            //    GoTo(startingPosition);
            }
        }

        else
            anim.SetBool("attacking", false);
    }

    protected void Flip()
    {
        if (orfeo.transform.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 0);
            buttonShower.transform.localScale = new Vector3(-1, 1, 0);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 0);
            buttonShower.transform.localScale = new Vector3(1, 1, 0);
        }
    }

    protected bool CanSeeHim()
    {

        RaycastHit2D[] rays =  Physics2D.RaycastAll(eyes.transform.position, orfeo.transform.position - eyes.transform.position, 100);

        foreach(RaycastHit2D r in rays)
        {
            if (r.collider.gameObject.name == "orfeo")
                return true;
            if (r.collider.gameObject.name.StartsWith("plat"))
                return false; 
        }

        return false; 
    }

    public void AttackOrfeo()
    {
        anim.SetBool("attacking", true);
        if (steppingBack)
        {
            print("A");
            GoTo(targetPos); 
			if (Mathf.Abs(transform.position.x - targetPos.x) < .2f)
			{
				steppingBack = false;
				targetPos = Vector3.zero;
			}
        }

        else if (Vector3.Distance(transform.position, orfeo.transform.position)<.2f && !steppingBack)
        {
            print("B");
            targetPos = Vector3.zero;
            steppingBack = true;
            if(orfeo.transform.position.x<transform.position.x)
                targetPos += transform.position + new Vector3(chargeDistance, 0, 0); 
            else
                targetPos += transform.position + new Vector3(-chargeDistance, 0, 0);
            GoTo(targetPos);
        }

        else if(!steppingBack)
        {
            print("C");
            GoTo(orfeo.transform.position);
        } 
    }

    public void GoTo(Vector3 position)
    {
        Vector3 dir = position - transform.position;
        if (dir.magnitude > .1f)
        {
            dir = new Vector3(dir.x, 0, 0);
            transform.position += dir.normalized * speed * Time.deltaTime;
		//	enemyRigidbody.AddForce (dir.normalized * hForce * Time.deltaTime, ForceMode2D.Impulse);
			/*if (enemyRigidbody.velocity.magnitude > 0.5f) {
				enemyRigidbody.velocity = new Vector2 (0.5f, -enemyRigidbody.gravityScale);
			}*/
        }
    }
}
