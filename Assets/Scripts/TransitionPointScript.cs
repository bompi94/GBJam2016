using UnityEngine;
using System.Collections;

public class TransitionPointScript : MonoBehaviour
{

    public int goToScene;
    public bool goingBack;

    public bool playerExited = true;
    bool inside;

    LevelScript level;
    GameObject orfeo; 

    void Start()
    {
        level = GetComponentInParent<LevelScript>();
    }

    void Update()
    {
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
