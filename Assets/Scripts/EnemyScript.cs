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

    public int damages; 

	void Start () {
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
        if (!good)
        {
            int[] numbers = { sequence[cont], sequence[cont + 1] };
            buttonShower.GetComponent<ButtonShowEnemy>().ShowButtons(numbers);
        }
    }

    public void HideSequence()
    {
        buttonShower.GetComponent<ButtonShowEnemy>().HideButtons();
    }

    public void MatchSequence(int match)
    {
        if (match == sequence[tempcont])
        {
            tempcont += 1;
            if (tempcont > cont+1)
            {
                cont += 2;
                if(cont<sequence.Length)
                    ShowSequence();
                else
                {
                    GetGood();
                }
            }
        }
    }

    public void GetGood()
    {
        HideSequence();
        heart.SetActive(true);
        good = true;
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
