using UnityEngine;
using System.Collections;

public class SoundsScript : MonoBehaviour {



	private static SoundsScript instance;

	public float jumpPitchMin=1;
	public float jumpPitchMax=1;


	// Use this for initialization
	void Start () {
		instance = GetComponent<SoundsScript> ();
	}


	public static void PlayOneShot(string name,AudioClip clip, AudioSource source){
		float min = 1;
		float max = 1;
		if(typeof(SoundsScript).GetField (name + "PitchMin")!=null)
			min=(float)typeof(SoundsScript).GetField (name + "PitchMin").GetValue (instance);
		if(typeof(SoundsScript).GetField (name + "PitchMax")!=null)
			max=(float)typeof(SoundsScript).GetField (name + "PitchMax").GetValue (instance);
		
		Debug.Log ("playing sound " + name + " with pitch range " + min + "-" + max);
		source.clip = clip;
		source.pitch = Random.Range (min, max);
		Debug.Log ("pitch:"+source.pitch);
		source.Play ();
	}
}
