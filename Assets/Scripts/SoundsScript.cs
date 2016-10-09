using UnityEngine;
using System.Collections;

public class SoundsScript : MonoBehaviour {



	private static SoundsScript instance;

	public float jumpPitchMin=1;
	public float jumpPitchMax=1;
	public float eyeShotPitchMax = 1;
	public float eysShotPitchMin = 1;
	public float pickUpPitchMax = 1;
	public float pickUpPitchMin = 1;
	public float lifeLostPitchMax = 1;
	public float lifeLostPitchMin = 1;
	public float hitHurtPitchMax = 1;
	public float hitHurtPitchMin = 1;
	public float enterInDoorPitchMax = 1;
	public float enterInDoorPitchMin = 1;
	public float gameoverPitchMax = 1;
	public float gameoverPitchMin = 1;


	public AudioClip[] getGoodSounds;
	public AudioClip eyeshotSounds;
	public AudioClip[] ragnoneAppearSounds;
	public AudioClip[] wurmAppearSounds;
	public AudioClip pickUpSound;
	public AudioClip enterInDoorSound;


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
