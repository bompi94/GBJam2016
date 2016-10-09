using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Sun : MonoBehaviour
{

    float timer = 0;
    float fadetime = 2;
    public float speed;
    bool active = false;
    GameObject s;
    // Use this for initialization
    void Start()
    {
        s = GameObject.Find("SUN");
        s.GetComponent<Image>().enabled = true;
        Destroy(GameObject.Find("orfeo"));
        Destroy(GameObject.Find("euridice"));
        GameObject.Find("GamePanel").SetActive(false); 
    }

    // Update is called once per frame
    void Update()
    {
        Color sun = s.GetComponent<Image>().color;
        sun.a -= (speed * Time.deltaTime);
        s.GetComponent<Image>().color = sun;
        
    }

}


