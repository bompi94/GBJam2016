using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    public int speed;
    public int jumpforce;
    Animator anim; 

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>(); 
        //Physics2D.IgnoreCollision(GetComponent<Collider2D>(), GameObject.Find("eurydice").GetComponent<Collider2D>()); 
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            anim.SetBool("walking",true); 
            transform.localScale = new Vector3(-1,transform.localScale.y); 
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            anim.SetBool("walking", true);
            transform.localScale = new Vector3(1, transform.localScale.y);
        }
        else
        {
            anim.SetBool("walking", false);
        }
        transform.position += new Vector3(Input.GetAxis("Horizontal"),0,0) * Time.deltaTime * speed;
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            PickUpEurydice(); 
	}

    public void PickUpEurydice()
    {
        GameObject eurydice = GameObject.Find("eurydice");
        Vector3 eurypos = eurydice.transform.position;
        if (Mathf.Abs(eurypos.x-transform.position.x)<3 && Mathf.Abs(eurypos.y - transform.position.y) < 20 
            && Mathf.Abs(eurypos.y - transform.position.y)>0)
            eurydice.GetComponent<EurydiceScript>().Up(transform.position); 
    }

    public void Jump()
    {
        anim.SetTrigger("jump"); 
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpforce), ForceMode2D.Impulse);
    }
}
