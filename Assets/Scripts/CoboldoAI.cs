using UnityEngine;
using System.Collections;

public class CoboldoAI : MonoBehaviour
{

    public float sightRange;
    public bool attacking;
    public float speed;
    public float chargeDistance; 
    GameObject orfeo;
    Vector3 startingPosition;
    public Vector3 targetPos; 
    public bool steppingBack;
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
                steppingBack = false; 
            //    GoTo(startingPosition);
            }
        }

        else
            anim.SetBool("attacking", false);
    }

    public void AttackOrfeo()
    {
        anim.SetBool("attacking", true);
        if (steppingBack)
        {
            print("A");
            GoTo(targetPos); 
            if (Vector3.Distance(transform.position, targetPos) < .2f)
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
        }
    }
}
