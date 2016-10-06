using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Health : MonoBehaviour {

    public int health;
    public int maxHealth = 100; 
    public bool orfeocantakedamage = true;
    public bool euridicecantakedamage = true;
    public Slider healthSlider;
    public int lives = 30; 

	// Use this for initialization
	void Start () {
        Init();
    }

    void Init()
    {
        health = maxHealth;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = health;
        if (GameObject.Find("euridice") != null)
        {
            Color c = GameObject.Find("euridice").GetComponent<SpriteRenderer>().color;
            c.a = 1;
            GameObject.Find("euridice").GetComponent<SpriteRenderer>().color = c;
        }
    }
	
	// Update is called once per frame
	void Update () {
        //GameObject.Find("LivesText").GetComponent<Text>().text = "x " + lives; 
	}

    public void TakeDamage(int amount,string characterHit)
    {
        
        if(characterHit == "orfeo")
        {
            if (orfeocantakedamage)
            {
                health -= amount;
                GameObject.Find("orfeo").SendMessage("ShowHit");
            }
        }

        if (characterHit == "euridice")
        {
            if (euridicecantakedamage)
            {
                health -= amount;
                GameObject.Find("euridice").SendMessage("ShowHit");
            }
        }

        if (health < 0)
            health = 0;

        if (health == 0)
            Die();

        healthSlider.value = health; 

    }

    public void Die()
    {
        Init();
        Debug.Log("sei morto");
        lives--;
		SceneManager.RespawnScene ();
    }
}
