using UnityEngine;
using System.Collections;

public class WargAI : CoboldoAI {

    void Start()
    {
        orfeo = GameObject.Find("orfeo");
		GameObject euridice = GameObject.Find ("euridice");
        startingPosition = transform.position;
        anim = GetComponent<Animator>();
        //	enemyRigidbody = GetComponent<Rigidbody2D> ();
        Physics2D.IgnoreCollision(GetComponent<PolygonCollider2D>(), orfeo.GetComponent<BoxCollider2D>());
		Physics2D.IgnoreCollision(GetComponent<PolygonCollider2D>(), euridice.GetComponent<BoxCollider2D>());
        speed = 2;
    }

    void Update()
    {
        Flip();
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

    void Flip()
    {
        print("canneee");
        if (orfeo.transform.position.x < transform.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 0);
            buttonShower.transform.localScale = new Vector3(-1, 1, 0);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 0);
            buttonShower.transform.localScale = new Vector3(1, 1, 0);
        }
    }
















    /*
        public float sightRange;
        public bool attackingOrfeo;
        public bool attackingEuridice;
        public bool canseeOrfeo;
        public bool canseeEuridice;
        public float speed;
        public float patrolSpeed;
        public float chargeDistance; 
        GameObject orfeo;
        GameObject euridice;
        Vector3 startingPosition;
        public Vector3 targetPos; 
        public bool steppingBack;
        Animator anim;
        public GameObject buttonShower;
        public GameObject eyes;
        public bool euridiceHavePriority=false;
        public float jumpforce;
        public bool grounded = true;

        public float jumpCooldown = 0;
        void Start()
        {
            orfeo = GameObject.Find("orfeo");
            euridice = GameObject.Find ("euridice");
            startingPosition = transform.position;
            anim = GetComponent<Animator>();
            if (Random.Range (0, 10) < 3) {
                euridiceHavePriority = true;//il doggo cerca di attaccare lei invece che lui
            }
            Physics2D.IgnoreCollision (GetComponent<BoxCollider2D> (), orfeo.GetComponent<BoxCollider2D> ());
            Physics2D.IgnoreCollision (GetComponent<BoxCollider2D> (), euridice.GetComponent<BoxCollider2D> ());

        }

        // Update is called once per frame
        void Update()
        {

            if (jumpCooldown > 0) {
                jumpCooldown -= Time.deltaTime;
            }

            canseeOrfeo = CanSeeHim ();
            canseeEuridice = CanSeeHer ();
            if (euridiceHavePriority && !orfeo.GetComponent<Attacker>().attacking) {
                    //Tring to find Euridice
                if (Vector3.Distance (transform.position, euridice.transform.position) > sightRange) {
                    Debug.Log ("Find euridice");
                    FindEuridice ();
                    attackingOrfeo = false;
                } else {
                    Debug.Log ("attacking euridice");
                    attackingEuridice = true;
                }

            } else {
                    if (Vector3.Distance (transform.position, orfeo.transform.position) <= sightRange && CanSeeHim ())
                        attackingOrfeo = true;
                     else {
                        attackingOrfeo = false;
                        attackingEuridice = false;
                        anim.SetBool ("attacking", false);
                    }
            }

            if (!GetComponent<EnemyScript>().good)
            {
                if (attackingOrfeo) {
                    AttackOrfeo ();
                    RotateEnemy (orfeo);
                } else if (attackingEuridice) {
                    AttackEuridice ();
                    RotateEnemy (euridice);
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

        void RotateEnemy(GameObject target){
            if (target.transform.position.x > transform.position.x)
            {
                transform.localScale = new Vector3(1, 1, 0);
                buttonShower.transform.localScale = new Vector3(1, 1, 0);
            }
            else
            {
                transform.localScale = new Vector3(-1, 1, 0);
                buttonShower.transform.localScale = new Vector3(-1, 1, 0);
            }
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

        bool CanSeeHer()
            {

                    RaycastHit2D[] rays =  Physics2D.RaycastAll(eyes.transform.position, euridice.transform.position - eyes.transform.position, 100);

                    foreach(RaycastHit2D r in rays)
                    {
                        if (r.collider.gameObject.name == "euridice")
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

        public void AttackEuridice()
        {
            Debug.Log ("attacking euridice");
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

            else if (Vector3.Distance(transform.position, euridice.transform.position)<.2f && !steppingBack)
            {
                Debug.Log ("arrived to her");
                print("B");
                targetPos = Vector3.zero;
                steppingBack = true;
                if(euridice.transform.position.x<transform.position.x)
                    targetPos += transform.position + new Vector3(chargeDistance, 0, 0); 
                else
                    targetPos += transform.position + new Vector3(-chargeDistance, 0, 0);
                GoTo(targetPos);
            }

            else if(!steppingBack)
            {
                print("C");
                GoTo(euridice.transform.position);
                Debug.Log ("go to her");

            } 
        }


        public void FindEuridice(){
            Vector3 dir = euridice.transform.position - transform.position;
            if (dir.magnitude > .1f)
            {
                dir = new Vector3(dir.x, 0, 0);
                transform.position += dir.normalized * patrolSpeed * Time.deltaTime;
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
            if (jumpCooldown<=0 && position.y - transform.position.y > 0.7f) {
                jumpCooldown = Random.Range (0f, 1f) * 5;
                Jump ();
            }
        }

        public void Jump()
        {

            if (grounded)
            {
                grounded = false;
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpforce), ForceMode2D.Impulse);
            }

        }

        public void Grounded()
        {
            grounded = true;
        } */
}