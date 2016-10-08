using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    public AudioClip[] jumpSounds; 
    public int speed;
    public int jumpforce;
    Animator anim;
    public int handRange = 1;
    public bool pickedUp = false;
    public bool grounded = true;
    public GameObject palo;
	public float hvalue;

	public bool canGoLeft = true;
	public bool canGoRight = true;
    float oldDpadY;
    float localScalex; 

	GameState gameState;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        if (GameObject.Find("euridice") != null)
        {
            Collider2D[] colls = GetComponents<Collider2D>(); 
            foreach(Collider2D c in colls)
                Physics2D.IgnoreCollision(c, GameObject.Find("euridice").GetComponent<Collider2D>());
            
        }
        localScalex = transform.localScale.x; 
		gameState = GameObject.Find ("GameState").GetComponent<GameState> ();
    }

    void Update()
    {
		if (!gameState.inPause) {
			float DpadY = Input.GetAxisRaw ("DpadY");
        
			if (Input.GetKeyDown (KeyCode.UpArrow) || Input.GetKeyDown (KeyCode.W) || (DpadY != oldDpadY && DpadY > 0))
				Jump ();

  

			if (Input.GetKeyDown (KeyCode.DownArrow) || Input.GetKeyDown (KeyCode.S) || (DpadY != oldDpadY && DpadY < 0))
				PickUpEurydice ();

    

			float h = Input.GetAxis ("Horizontal") + Input.GetAxis ("DpadX");

			if (!canGoLeft) {
				h = Mathf.Clamp (h, 0f, 1f);
			} else if (!canGoRight) {
				h = Mathf.Clamp (h, -1f, 0f);
			}
			hvalue = h;
			if (h < 0) {
				anim.SetBool ("walking", true);
				transform.localScale = new Vector3 (-localScalex, transform.localScale.y);
			} else if (h > 0) {
				anim.SetBool ("walking", true);
				transform.localScale = new Vector3 (localScalex, transform.localScale.y);
			} else {
				anim.SetBool ("walking", false);
			}

            transform.position += new Vector3 (h, 0, 0) * Time.deltaTime * speed;
            //GetComponent<Rigidbody2D>().AddForce(new Vector3(h, 0, 0));

			oldDpadY = DpadY; 
		}
    }

    public void PickUpEurydice()
    {
        
        GameObject eurydice = GameObject.Find("euridice");
        if (!pickedUp)
        {

            if (Vector3.Distance(transform.position, eurydice.transform.position) <= handRange)
            {
                anim.SetBool("hand", true);
                eurydice.GetComponent<EurydiceScript>().GiveHand();
                pickedUp = true;
            }
        }
        else
        {
            anim.SetBool("hand", false);
            eurydice.GetComponent<EurydiceScript>().LeaveHand();
            pickedUp = false;
        }
    }

    public void Jump()
    {
         
        if (grounded)
        {
            grounded = false;
            anim.SetTrigger("jump");
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpforce), ForceMode2D.Impulse);
            palo.GetComponent<Collider2D>().enabled = true;
            if (pickedUp)
            {
                GameObject.Find("euridice").GetComponent<EurydiceScript>().JumpWithMe();
            }
			SoundsScript.PlayOneShot("jump",jumpSounds[Random.Range(0,jumpSounds.Length)],GetComponent<AudioSource>());
         //   GetComponent<AudioSource>().clip = jumpSounds[Random.Range(0,jumpSounds.Length)];
         //   GetComponent<AudioSource>().Play();
        }

    }

    public void Grounded()
    {
        palo.GetComponent<Collider2D>().enabled = false;
        grounded = true;
    }
}
