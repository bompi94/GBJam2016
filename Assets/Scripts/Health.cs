using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Health : MonoBehaviour {

    public int health = 100;
    public bool orfeocantakedamage = true;
    public bool euridicecantakedamage = true;
    public Slider healthSlider; 
	// Use this for initialization
	void Start () {
        healthSlider.maxValue = health;
        healthSlider.value = health;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void TakeDamage(int amount,string characterHit)
    {
        
        if(characterHit == "orfeo")
        {
            if(orfeocantakedamage)
                health -= amount;
        }

        if (characterHit == "euridice")
        {
            if (euridicecantakedamage)
                health -= amount;
        }

        healthSlider.value = health; 

    }
}
