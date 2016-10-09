using UnityEngine;
using System.Collections;

public class FinalNotes : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(PlayMusicLove());
	}

    IEnumerator PlayMusicLove()
    {
        while (true)
        {
            GetComponent<NoteSpawner>().SpawnRandomNote();
            yield return new WaitForSeconds(Random.Range(1f, 2f));
        }
    }
}
