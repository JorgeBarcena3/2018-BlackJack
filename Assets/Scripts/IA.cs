using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA : Entity
{

    public int scoreToSee;

    public override void drawScore()
    {
        //  Debug.Log("IA: " + scoreToSee);
    }

    public bool takeCard()
    {

        if (score < 17)
        {
            return true;
        }
        return false;

    }

    public override void addCard(GameObject newCard)
    {

        myCards.Add(newCard.GetComponent<Cards>());

        if (newCard.GetComponent<Cards>().nameCard == 'A' && myCards.Count > 1)
        {
            int nextScore = score;
            nextScore += 11;
            if (nextScore > 21)
            {
                score += 1;
                scoreToSee++;
            }
            else
            {
                score += 11;
                scoreToSee += 11;
            }

        }
        else if (myCards.Count > 1)
        {
            scoreToSee += myCards[myCards.Count - 1].value;
            score += myCards[myCards.Count - 1].value;
        }
        else
        {
            score += myCards[myCards.Count - 1].value;
        }

        drawScore();
    }

    public void trueScore()
    {

        if (myCards.Count != 0)
            myCards[0].turnUpCard();
        scoreToSee = score;
    }

    public override void restartGame()
    {
        scoreToSee = 0;
        myCards.Clear();
        score = 0;
        drawScore();

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
