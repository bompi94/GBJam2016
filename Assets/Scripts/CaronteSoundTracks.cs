using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CaronteSoundTracks : MonoBehaviour {

    public AudioSource[] soundTracks;

        // Use this for initialization
    void Start () {
       soundTracks = GameObject.Find("GameState").GetComponents<AudioSource>();
		StartCoroutine (SwapSoundtracks ());
    }

    public IEnumerator SwapSoundtracks()
    {
        soundTracks[1].Play();
        while (soundTracks[1].volume <= 0.9f)
        {
		   Debug.Log ("volume 0 : " + soundTracks [0].volume);
		   Debug.Log ("volume 1: " + soundTracks [1].volume);
           soundTracks[0].volume = Mathf.Lerp(soundTracks[0].volume, 0, Time.fixedDeltaTime * 1.5f);
			soundTracks[1].volume = Mathf.Lerp(soundTracks[1].volume, 1, Time.fixedDeltaTime * 1.5f);
			yield return new WaitForEndOfFrame ();
        }
        soundTracks[1].volume = 1f;
        soundTracks[0].Stop();
    }
}
