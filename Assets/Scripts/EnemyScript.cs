using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

    public int numberOfButtons;
    int[] sequence;
    public int cont = 0;
    public int tempcont = 0;
    public GameObject buttonShower;
    public GameObject heart;
    public bool good = false;
	public bool aimable = true;
    public int damages; 

	public LevelScript currentLevel;

	void Start () {
		currentLevel = gameObject.GetComponentInParent<LevelScript> ();
        sequence = new int[numberOfButtons];
        for(int i = 0; i<sequence.Length; i++)
        {
            sequence[i] = Random.Range(0, 2); 
        }
	}

	void Update () {
	}

    public void ShowSequence()
    {
		if (!good && aimable)
        {
            int[] numbers = { sequence[cont], sequence[cont + 1] };
            DeHighlightButton(0);
            DeHighlightButton(1);
            buttonShower.GetComponent<ButtonShowEnemy>().ShowButtons(numbers);
        }
    }

    public void HideSequence()
    {
        buttonShower.GetComponent<ButtonShowEnemy>().HideButtons();
    }

    void HighlightButton(int index)
    {
        buttonShower.GetComponent<ButtonShowEnemy>().showSlaves[index % 2].GetComponent<ShowSlave>().Highlight(); 
    }

    void DeHighlightButton(int index)
    {
        buttonShower.GetComponent<ButtonShowEnemy>().showSlaves[index % 2].GetComponent<ShowSlave>().DeHighLight();
    }

    public void MatchSequence(int match)
    {
		if (!good) {			
			if (match == sequence [tempcont]) {
                HighlightButton(tempcont);
                tempcont += 1; 
				if (tempcont > cont + 1) {
                    StartCoroutine(DelayStuff()); 
				}
			}

            else
            {
                tempcont = cont;
                DeHighlightButton(tempcont);
            }
		}
    }

    IEnumerator DelayStuff()
    {
        yield return new WaitForSeconds(.1f); 
        cont += 2;
        if (cont < sequence.Length)
            ShowSequence();
        else
        {
            GetGood();
        }
    }

    public void GetGood()
    {
        HideSequence();
        heart.SetActive(true);
        good = true;
        if(currentLevel!=null)
		    currentLevel.EnemyDied (gameObject);
        StartCoroutine(GoAway());
    }

    public IEnumerator GoAway()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }

    public void DealDamage(int multiplier,string characterHit)
    {
        GameObject.Find("Health").GetComponent<Health>().TakeDamage(damages*multiplier,characterHit);
        
    }
}
