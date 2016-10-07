using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    GameObject orfeo;
    public int[] specialRooms;
    bool follow;
    ArrayList sr; 

    void Start()
    {
        sr = new ArrayList(specialRooms);
    }

	// Update is called once per frame
	void Update () {
        if (follow)
        {
            orfeo = GameObject.Find("orfeo");
            transform.position = new Vector3(orfeo.transform.position.x, orfeo.transform.position.y, transform.position.z);
        }
	}

    public void LoadedLevel(int level)
    {
        if (sr.Contains(level))
            follow = true;
        else
            follow = false; 

    }
}
