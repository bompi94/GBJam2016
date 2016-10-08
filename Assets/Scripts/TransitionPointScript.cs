using UnityEngine;
using System.Collections;

public class TransitionPointScript : MonoBehaviour
{

    public int goToScene;
    public bool goingBack;
    GameObject freccia;
    bool playerExited = true;
    bool inside;
    public bool shouldShowFrecccia = true; 

    LevelScript level;
    GameObject orfeo; 

    void Start()
    {
        level = GetComponentInParent<LevelScript>();
    }

    void Update()
    {
        if (shouldShowFrecccia)
        {
            if (GetComponent<Collider2D>().enabled && freccia == null)
            {
                freccia = Instantiate(Resources.Load("freccia"), transform.position, Quaternion.identity) as GameObject;
                if (transform.localPosition.x > 0)
                    freccia.transform.localScale = new Vector3(-.5f, .5f, transform.localScale.z);
                freccia.transform.parent = transform;
            }

            if (GetComponent<Collider2D>() == null && freccia != null)
                Destroy(freccia);
        }

        if (orfeo != null && inside)
        {
            if (orfeo.GetComponent<Movement>().pickedUp && playerExited)
            {
                //scnManager.SceneChange (goToScene,goingBack);
                SceneManager.ChangeScene(goToScene, goingBack);
            }
            if (!orfeo.GetComponent<Movement>().pickedUp && playerExited)
            {
                Debug.Log("Prendi Euridice coglione!");
            }
        }
    }


    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.name == "orfeo")
        {
            orfeo = coll.gameObject; 
            inside = true;
           
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.name == "orfeo")

            inside = false;
        if (!playerExited)
        {
            playerExited = true;
            Debug.Log("Trigger Reactived");
        }
    }

    public void DeactivateUntilExit()
    {
        //disattivo il trigger finchè il player non si sposta
        playerExited = false;
    }
}
