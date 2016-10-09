using UnityEngine;
using System.Collections;

public class FadeOutAudio : MonoBehaviour {

	AudioSource[] soundTracks;

	// Use this for initialization
	void Start () {
		soundTracks = GameObject.Find("GameState").GetComponents<AudioSource>();
		StartCoroutine (FadeSoundtrack ());
	}

	public IEnumerator FadeSoundtrack()
	{
		while (soundTracks[1].volume > 0.1f)
		{
			soundTracks[1].volume = Mathf.Lerp(soundTracks[1].volume, 0, Time.fixedDeltaTime * 2f);
			yield return new WaitForEndOfFrame ();
		}
		soundTracks[1].volume = 0f;
		soundTracks[1].Stop();
	}
}
