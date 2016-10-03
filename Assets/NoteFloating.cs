using UnityEngine;
using System.Collections;

public class NoteFloating : MonoBehaviour {

    public float amplitude;
    public float frequency;
    public float speed;
    float timer;
    public float ttl; 


	// Use this for initialization
	void Start () {
	
	}

    void Update()
    {
        timer += Time.deltaTime; 
        transform.position += amplitude * (Mathf.Sin(2 * Mathf.PI * frequency * Time.time) 
            - Mathf.Sin(2 * Mathf.PI * frequency * (Time.time - Time.deltaTime))) * transform.right;

        transform.position += new Vector3(0,Time.deltaTime*speed,0);

        if (timer >= ttl)
        {
            Destroy(gameObject); 
        }
    }
}
