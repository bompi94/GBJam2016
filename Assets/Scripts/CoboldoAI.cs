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
    public GameObject eyes; 

	public float hForce;

	//Rigidbody2D enemyRigidbody;

    void Start()
    {
        orfeo = GameObject.Find("orfeo");
        startingPosition = transform.position;
        anim = GetComponent<Animator>();
	//	enemyRigidbody = GetComponent<Rigidbody2D> ();
		Physics2D.IgnoreCollision (GetComponent<PolygonCollider2D> (), orfeo.GetComponent<BoxCollider2D> ());
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
        if (Vector3.Distance(transform.position, orfeo.transform.position) <= sightRange 
            && 
            CanSeeHim())
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

    bool CanSeeHim()
    {

        RaycastHit2D[] rays =  Physics2D.RaycastAll(eyes.transform.position, orfeo.transform.position - eyes.transform.position, 100);

        foreach(RaycastHit2D r in rays)
        {
            if (r.collider.gameObject.name == "orfeo")
                return true;
            if (r.collider.gameObject.name.StartsWith("plat"))
                return false; 
        }

        return false; 
    }

    public void AttackOrfeo()
    {
        anim.SetBool("attacking", true);
        if (steppingBack)
        {
            print("A");
            GoTo(targetPos); 
			Vector3 coboldoNoY = transform.position;
			coboldoNoY.y = 0;
			Vector3 targetNoY = targetPos;
			targetNoY.y = 0;
		/*	if (Vector3.Distance(coboldoNoY, targetNoY) < .2f)
            {
                steppingBack = false;
                targetPos = Vector3.zero;
            }
*/
			if (Mathf.Abs(transform.position.x - targetPos.x) < .2f)
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
		//	enemyRigidbody.AddForce (dir.normalized * hForce * Time.deltaTime, ForceMode2D.Impulse);
			/*if (enemyRigidbody.velocity.magnitude > 0.5f) {
				enemyRigidbody.velocity = new Vector2 (0.5f, -enemyRigidbody.gravityScale);
			}*/
        }
    }
}
