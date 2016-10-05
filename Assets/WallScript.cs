using UnityEngine;
using System.Collections;

public class WallScript : MonoBehaviour {

	public bool fromLeft;
	public bool fromRight;

	public DoorScript eventualDoor;
	// Use this for initialization
	void Start () {
		eventualDoor = GetComponentInParent<DoorScript> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.tag == "Player") {
			//if (eventualDoor != null && eventualDoor.enabled) {
				if (fromLeft) {
					coll.GetComponent<Movement> ().canGoRight = false;
				}
				if (fromRight) {
					coll.GetComponent<Movement> ().canGoLeft = false;
				}
			//}
		}
	}

	void OnTriggerExit2D(Collider2D coll){
		if (coll.tag == "Player") {
			coll.GetComponent<Movement> ().canGoLeft = true;
			coll.GetComponent<Movement> ().canGoRight = true;
		}
	}
}
