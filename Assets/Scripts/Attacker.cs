using UnityEngine;
using System.Collections;

public class Attacker : MonoBehaviour
{

    public GameObject targetEnemy;
    public int range;
    Health health;
    bool beingHit;
    public NoteSpawner noteSpawner; 
    // Use this for initialization
	public bool attacking=false;


    // Update is called once per frame
    void Update()
    {
        FindNearestEnemy();

        if (targetEnemy != null)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                noteSpawner.SpawnRandomNote();
                targetEnemy.GetComponent<EnemyScript>().MatchSequence(0);
				attacking = true;
            }
            if (Input.GetButtonDown("Fire2"))
            {
                noteSpawner.SpawnRandomNote();
                targetEnemy.GetComponent<EnemyScript>().MatchSequence(1);
				attacking = true;
            }
        }  
    }

    public void FindNearestEnemy()
    {
        if (targetEnemy == null || targetEnemy.GetComponent<EnemyScript>().good)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            float minDist = Mathf.Infinity;
            foreach (GameObject enemy in enemies)
            {
                float tempdist = Vector3.Distance(transform.position, enemy.transform.position);
                if (tempdist < range && tempdist<minDist )
                {
                    minDist = tempdist;
                    targetEnemy = enemy;
                }  
            }
            if (targetEnemy != null)
            {
                targetEnemy.GetComponent<EnemyScript>().ShowSequence();
            }
        }

        else
        {
            if (Vector3.Distance(transform.position, targetEnemy.transform.position) > range)
            {
                targetEnemy.GetComponent<EnemyScript>().HideSequence();
                targetEnemy.GetComponent<EnemyScript>().tempcont = targetEnemy.GetComponent<EnemyScript>().cont;
                targetEnemy = null;
				attacking = false;
            }
        }
    }

    public void ShowHit()
    {
        if(!beingHit)
            StartCoroutine(GotHit()); 
    }

    IEnumerator GotHit()
    {
        beingHit = true;
        if (health == null)
            health = GameObject.Find("Health").GetComponent<Health>();
        health.orfeocantakedamage = false; 
        int cont = 0;
        while (cont < 8)
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
        health.orfeocantakedamage = true;
        beingHit = false; 
    }
}
