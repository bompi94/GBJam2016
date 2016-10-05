using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameState : MonoBehaviour {

	public Dictionary<int,bool[]> levelState = new Dictionary<int,bool[]> ();

	public List<string> keysOwned = new List<string> ();

	public List<string> keysTaken = new List<string>();

	public Dictionary<int,bool> doorsState = new Dictionary<int, bool> ();
}
