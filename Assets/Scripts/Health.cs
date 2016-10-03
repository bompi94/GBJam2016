using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    public int health = 100;
    public bool orfeocantakedamage = true;
    public bool euridicecantakedamage = true; 
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void TakeDamage(int amount,string characterHit)
    {
        if(characterHit == "orfeo")
        {
            
        }
        health -= amount; 
    }
}
