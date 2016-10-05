using UnityEngine;
using System.Collections;

public class NoteSpawner : MonoBehaviour {

    public GameObject note1;
    public GameObject note2;
    public GameObject[] positions;
    public AudioClip[] note1sounds;
    public AudioClip[] note2sounds;
    public AudioSource audioSourcenote1;
    public AudioSource audioSourcenote2;
    ArrayList audioQueue = new ArrayList();

    // Use this for initialization
    void Start () {
        StartCoroutine(AudioCoroutine()); 
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Keypad1))
            SpawnNote1();
        if (Input.GetKeyDown(KeyCode.Keypad2))
            SpawnNote2();
        if (Input.GetKeyDown(KeyCode.Keypad3))
            SpawnRandomNote();
    }

    IEnumerator AudioCoroutine()
    {
        while (true)
        {
            if(audioQueue.Count!=0 && !audioSourcenote1.isPlaying)
            {
                audioSourcenote1.clip = (AudioClip) audioQueue[0];
                audioQueue.RemoveAt(0);

                AudioSource.PlayClipAtPoint(audioSourcenote1.clip, Camera.main.transform.position); 
            }

            yield return new WaitForSeconds(0.01f);
        }
    }

    public void SpawnNote1()
    {
        Instantiate(note1,positions[Random.Range(0,positions.Length-1)].transform.position,Quaternion.identity);
        audioQueue.Add(note1sounds[Random.Range(0, note1sounds.Length - 1)]);
    }

    public void SpawnNote2()
    {
        Instantiate(note2, positions[Random.Range(0, positions.Length - 1)].transform.position, Quaternion.identity);
        audioQueue.Add( note2sounds[Random.Range(0, note2sounds.Length - 1)]);
    }

    public void SpawnRandomNote()
    {
        int r = Random.Range(0, 2);
        if (r == 0)
            SpawnNote1();
        else
            SpawnNote2(); 
    }
}
