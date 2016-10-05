﻿using UnityEngine;
using System.Collections;

public class InsettoAssassinoAI : MonoBehaviour {

    public GameObject startingPos;
    public GameObject endingPos;
    float timer;
    public float startToFallTime; 
    bool seen;
    bool goingDown;
    GameObject orfeo;
    public float downSpeed;
    private bool arrived;
    float uptimer;
    public float downTime;
    LineRenderer lr;
    public GameObject coda; 

    // Use this for initialization
    void Start () {
        orfeo = GameObject.Find("orfeo");
        lr = GetComponent<LineRenderer>(); 
        
	}
	
	// Update is called once per frame
	void Update () {
        lr.SetPosition(0, startingPos.transform.position);
        lr.SetPosition(1, coda.transform.position); 
        timer += Time.deltaTime;
        if (!GetComponent<EnemyScript>().good)
        {
            //startingPos.transform.position = new Vector3(orfeo.transform.position.x,startingPos.transform.position.y,0);
            if (timer >= startToFallTime && !arrived)
            {
                goingDown = true;
                if (goingDown)
                    GoDown();
            }
            else if (arrived)
            {
                goingDown = false;
                GoUp();
            }
            else
            {
                startingPos.transform.position = new Vector3(orfeo.transform.position.x, startingPos.transform.position.y, 0);
            }
        }
	}


    void GoDown()
    {
        Vector3 dir = (endingPos.transform.position - transform.position);
        if (Vector3.Distance(transform.position, endingPos.transform.position) > .2f)
            transform.position += dir.normalized * Time.deltaTime * downSpeed;
        else if(uptimer>=downTime)
        {
            uptimer = 0;
            arrived = true;
        }

        else
        {
            uptimer += Time.deltaTime; 
        }
    }

    void GoUp()
    {
        Vector3 dir = (startingPos.transform.position - transform.position);
        if (Vector3.Distance(transform.position, startingPos.transform.position) > .001f)
            transform.position += dir.normalized * Time.deltaTime * downSpeed;
        else
        {
            timer = 0;
            goingDown = false;
            arrived = false; 
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (!GetComponent<EnemyScript>().good)
        {
            if (coll.gameObject.name == "orfeo")
            {
                GetComponent<EnemyScript>().DealDamage(1, "orfeo");
            }
            else if (coll.gameObject.name == "euridice")
                GetComponent<EnemyScript>().DealDamage(2, "euridice");
        }
    }
}