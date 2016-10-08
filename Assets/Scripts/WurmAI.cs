﻿using UnityEngine;
using System.Collections;

public class WurmAI : MonoBehaviour {

	public float countdownToShaking = 0;
	public float countdownToDisappear = 0;
	public bool appeared = false;
	public bool appearing = false;
	public bool disappearing = false;
	GameObject orfeo;
	public BoxCollider2D collider;
    public GameObject leftMovementLimit;
	// Use this for initialization
	void Start () {
		countdownToShaking=Random.Range (4f, 9f);
		orfeo = GameObject.Find("orfeo");
		collider=GetComponent<BoxCollider2D> ();
		collider.enabled = false;
		GetComponent<EnemyScript> ().aimable = false;
		GetComponent<EnemyScript> ().HideSequence ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!GetComponent<EnemyScript> ().good) {
			countdownToShaking -= Time.deltaTime;
			countdownToDisappear -= Time.deltaTime;

			if (countdownToShaking <= 0 && !appearing) {
				appearing = true;
				GetComponent<CameraShaking> ().StartShaking ();
				Invoke ("ShowWurm", 1f);
			}
			if (countdownToDisappear <= 0 && appeared && !disappearing ) {
				disappearing = true;
				GetComponent<WurmScript> ().Disappear ();
				collider.enabled = false;
				GetComponent<EnemyScript> ().aimable = false;
				GetComponent<EnemyScript> ().HideSequence ();
				Invoke ("HideWurm", 1f);
			}
			if (!appearing)
				FollowPlayer ();
		}
	}

	void ShowWurm(){
		Debug.Log ("Called show");
		appeared = true;
		GetComponent<WurmScript> ().Appear ();
		countdownToDisappear=Random.Range (3.5f, 5.5f);
		Invoke ("FinishAppearing", 0.5f);
	}

	void FinishAppearing(){
		collider.enabled = true;
		GetComponent<EnemyScript> ().aimable = true;
		GetComponent<EnemyScript> ().ShowSequence ();
	}

	void HideWurm(){
		Debug.Log ("Called hide");
		countdownToShaking = Random.Range (4f, 9f);
		appeared = false;
		appearing = false;
		disappearing = false;

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

	void FollowPlayer(){
        if(leftMovementLimit == null || transform.position.x >= leftMovementLimit.transform.position.x)
		    transform.position = new Vector3 (orfeo.transform.position.x, transform.position.y, transform.position.z);
	}
}