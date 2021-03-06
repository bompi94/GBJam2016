﻿using UnityEngine;
using System.Collections;

public class EyeAI : MonoBehaviour {

    GameObject orfeo;
    public float shootFrequency;
    public float speed; 
    float timer;
    public GameObject projectile; 

	public AudioClip eyeShotSound;
	// Use this for initialization
	void Start () {
        orfeo = GameObject.Find("orfeo");
		eyeShotSound = GameObject.Find ("SoundsManager").GetComponent<SoundsScript> ().eyeshotSounds;

	}
	
	// Update is called once per frame
	void Update () {
        Vector3 dir = orfeo.transform.position - transform.position;
        dir = dir.normalized; 
        transform.position += new Vector3(dir.x,0,0) * Time.deltaTime * speed;

        timer += Time.deltaTime;
        if (timer >= shootFrequency && !GetComponent<EnemyScript>().good)
        {
            Shoot();
            timer = 0; 
        }
	}

    public void Shoot()
    {
        Instantiate(projectile,transform.position,Quaternion.identity);
		SoundsScript.PlayOneShot("eyeShot",eyeShotSound,GameObject.Find ("SoundsManager").GetComponent<AudioSource>());
    }
}
