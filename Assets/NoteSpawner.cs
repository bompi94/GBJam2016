using UnityEngine;
using System.Collections;

public class NoteSpawner : MonoBehaviour {

    public GameObject note1;
    public GameObject note2;
    public GameObject[] positions; 

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
        Instantiate(note1,positions[Random.Range(0,positions.Length-1)].transform.position,Quaternion.identity); 
    }

    public void SpawnNote2()
    {
        Instantiate(note2, positions[Random.Range(0, positions.Length - 1)].transform.position, Quaternion.identity);
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
