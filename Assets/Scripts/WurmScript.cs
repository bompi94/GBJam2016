using UnityEngine;
using System.Collections;

public class WurmScript : MonoBehaviour {

	public Animator animator;
	public SpriteRenderer spriterend;

	// Use this for initialization
	void Start () {
		spriterend = GetComponent<SpriteRenderer> ();
		animator = GetComponent<Animator> ();
		//spriterend.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Appear(){
		animator.SetBool ("Appeared",true);
		animator.SetBool ("Disappeared",false);
		//spriterend.enabled = true;
	}

	public void Disappear(){
		//spriterend.enabled = false;
		animator.SetBool ("Appeared",false);
		animator.SetBool ("Disappeared",true);
	}
}
