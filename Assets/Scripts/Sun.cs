using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Sun : MonoBehaviour
{

    float timer = 0;
    float fadetime = 16;
    float whiteTime = 4;
    public float speed;
    bool active = false;
    GameObject s;
    GameObject t; 
    // Use this for initialization
    void Start()
    {
        s = GameObject.Find("SUN");
        t = GameObject.Find("FINALTEXT"); 
        s.GetComponent<Image>().enabled = true;
        Destroy(GameObject.Find("orfeo"));
        Destroy(GameObject.Find("euridice"));
        GameObject.Find("GamePanel").SetActive(false);       
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= fadetime)
        {
            
            Color c = t.GetComponent<Text>().color;
            c.a += ((speed) * Time.deltaTime);
            t.GetComponent<Text>().color = c;
        }
        if (timer >= whiteTime)
        {
            GameObject.Find("GameState").GetComponent<AudioSource>().volume -= speed * Time.deltaTime;
            Color sun = s.GetComponent<Image>().color;
            sun.a -= ((speed / 1.5f) * Time.deltaTime);
            s.GetComponent<Image>().color = sun;
        }
    }

}


