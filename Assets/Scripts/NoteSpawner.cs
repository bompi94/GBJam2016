using UnityEngine;
using System.Collections;

public class NoteSpawner : MonoBehaviour {

    public GameObject note1;
    public GameObject note2;
    public GameObject[] positions;
    public AudioClip[] note1sounds;
    public AudioClip[] note2sounds;

    // Use this for initialization
    void Start () {
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

   

    public void SpawnNote1()
    {
        Instantiate(note1,positions[Random.Range(0,positions.Length)].transform.position,Quaternion.identity);
        GetComponent<AudioSource>().PlayOneShot(note1sounds[Random.Range(0, note1sounds.Length )]);
    }

    public void SpawnNote2()
    {
        Instantiate(note2, positions[Random.Range(0, positions.Length )].transform.position, Quaternion.identity);
        GetComponent<AudioSource>().PlayOneShot( note2sounds[Random.Range(0, note2sounds.Length )]);
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
