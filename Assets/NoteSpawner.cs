using UnityEngine;
using System.Collections;

public class NoteSpawner : MonoBehaviour {

    public GameObject note1;
    public GameObject note2; 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
    }

    public void SpawnNote1()
    {
        Instantiate(note1,transform.position,Quaternion.identity); 
    }

    public void SpawnNote2()
    {
        Instantiate(note2, transform.position, Quaternion.identity);
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
