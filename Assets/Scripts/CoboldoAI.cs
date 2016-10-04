using UnityEngine;
using System.Collections;

public class CoboldoAI : MonoBehaviour
{

    public float sightRange;
    public bool attacking;
    public float speed;
    GameObject orfeo;
    Vector3 startingPosition;
    bool steppingBack;
    Animator anim;
    public GameObject buttonShower;

    void Start()
    {
        orfeo = GameObject.Find("orfeo");
        startingPosition = transform.position;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
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
        if (Vector3.Distance(transform.position, orfeo.transform.position) <= sightRange)
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
                GoTo(startingPosition);
            }
        }

        else
            anim.SetBool("attacking", false);
    }

    public void AttackOrfeo()
    {
        anim.SetBool("attacking", true);
        
       
        GoTo(orfeo.transform.position);
        
    }

    public void GoTo(Vector3 position)
    {
        Vector3 dir = position - transform.position;
        if (dir.magnitude > .1f)
        {
            dir = new Vector3(dir.x, 0, 0);
            transform.position += dir.normalized * speed * Time.deltaTime;
        }
    }
}
