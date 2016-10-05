using UnityEngine;
using System.Collections;

public class NoteSpawner : MonoBehaviour {

    public GameObject note1;
    public GameObject note2;
    public GameObject[] positions;
    public AudioClip[] note1sounds;
    public AudioClip[] note2sounds;
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
            if(audioQueue.Count!=0)
            {
                GetComponent<AudioSource>().PlayOneShot((AudioClip)audioQueue[0]);
                audioQueue.RemoveAt(0);
            }

            yield return new WaitForSeconds(0.001f);
        }
    }

    public void SpawnNote1()
    {
        Instantiate(note1,positions[Random.Range(0,positions.Length)].transform.position,Quaternion.identity);
        audioQueue.Add(note1sounds[Random.Range(0, note1sounds.Length )]);
    }

    public void SpawnNote2()
    {
        Instantiate(note2, positions[Random.Range(0, positions.Length )].transform.position, Quaternion.identity);
        audioQueue.Add( note2sounds[Random.Range(0, note2sounds.Length )]);
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
