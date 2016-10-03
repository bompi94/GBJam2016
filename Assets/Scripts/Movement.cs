using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{

    public int speed;
    public int jumpforce;
    Animator anim;
    public int handRange = 1;
    public bool pickedUp = false;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), GameObject.Find("euridice").GetComponent<Collider2D>());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            Jump();

        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            PickUpEurydice();

        if (Input.GetAxis("Horizontal") < 0)
        {
            anim.SetBool("walking", true);
            transform.localScale = new Vector3(-1, transform.localScale.y);
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

        transform.position += new Vector3(Input.GetAxis("Horizontal"), 0, 0) * Time.deltaTime * speed;

       

    }

    public void PickUpEurydice()
    {
        GameObject eurydice = GameObject.Find("euridice");
        if (!pickedUp)
        {

            if (Vector3.Distance(transform.position, eurydice.transform.position) <= handRange)
            {
                //change sprite 4 orfeo
                eurydice.GetComponent<EurydiceScript>().GiveHand();
                pickedUp = true;
            }
        }
        else
        {
            eurydice.GetComponent<EurydiceScript>().LeaveHand();
            pickedUp = false;
        }
    }

    public void Jump()
    {
        anim.SetTrigger("jump");
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpforce), ForceMode2D.Impulse);
    }
}
