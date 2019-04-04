using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{


    public List<Cards> myCards = new List<Cards>();
    public int score = 0;

    public virtual void addCard(GameObject newCard)
    {

        myCards.Add(newCard.GetComponent<Cards>());

        if (newCard.GetComponent<Cards>().nameCard == 'A')
        {
            int nextScore = score;
            nextScore += 11;
            if (nextScore > 21)
            {
                score += 1;
            }
            else
                score += 11;


        }
        else
            score += myCards[myCards.Count - 1].value;

        drawScore();

    }

    public virtual void restartGame()
    {

        myCards.Clear();
        score = 0;
        drawScore();

    }

    public bool loss()
    {

        if (score > 21)
        {
            return true;
        }
        return false;

    }

    public virtual void drawScore()
    {
     //   Debug.Log(score);
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
