using UnityEngine;
using System.Collections;

public class Attacker : MonoBehaviour
{

    public GameObject targetEnemy;
    public int range;
    Health health; 
    // Use this for initialization


    // Update is called once per frame
    void Update()
    {
        FindNearestEnemy();

        if (targetEnemy != null)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                targetEnemy.GetComponent<EnemyScript>().MatchSequence(0);
            }
            if (Input.GetButtonDown("Fire2"))
            {
                targetEnemy.GetComponent<EnemyScript>().MatchSequence(1);
            }
        }

        
    }

    public void FindNearestEnemy()
    {
        if (targetEnemy == null || targetEnemy.GetComponent<EnemyScript>().good)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in enemies)
            {
                if (Vector3.Distance(transform.position, enemy.transform.position) < range)
                {
                    targetEnemy = enemy;
                }
                if (targetEnemy != null)
                {
                    targetEnemy.GetComponent<EnemyScript>().ShowSequence();
                    break;
                }
                
            }
        }
        else
        {
            if (Vector3.Distance(transform.position, targetEnemy.transform.position) > range)
            {
                targetEnemy.GetComponent<EnemyScript>().HideSequence();
                targetEnemy = null;
            }
        }
    }

    public void ShowHit()
    {
        StartCoroutine(GotHit()); 
    }

    IEnumerator GotHit()
    {
        if (health == null)
            health = GameObject.Find("Health").GetComponent<Health>();
        health.orfeocantakedamage = false; 
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
        health.orfeocantakedamage = true;
    }
}
