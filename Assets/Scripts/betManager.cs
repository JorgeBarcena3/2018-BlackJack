using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class betManager : MonoBehaviour
{

    public int myMoney;
    public Text uiText;
    public int currentBet = 0;
    public List<GameObject> betSprites;
    public Sprite[] spritesPrefabs;
    public GameObject prefb;
    public Button[] placers = new Button[4];
    // Use this for initialization
    void Start()
    {
        if (PlayerPrefs.GetInt("myMoney") == 0)
            myMoney = 1000;
        else
            myMoney = PlayerPrefs.GetInt("myMoney");

        uiText.text = myMoney.ToString() + "$";

    }

    public void disableButtons(bool disable)
    {

        if (disable)
        {

            for (int i = 0; i < 4; i++)
                placers[i].interactable = false;

        }
        else
            for (int i = 0; i < 4; i++)
                placers[i].interactable = true;

    }

    public void showMoney()
    {
        uiText.text = myMoney.ToString() + "$";

    }

    public void placeBet(int bet)
    {

        currentBet += bet;
        myMoney -= bet;
        showMoney();
        putSprite(bet);

    }

    private void putSprite(int bet)
    {

        int image;

        switch (bet)
        {
            case 10:
                image = 0;
                break;
            case 20:
                image = 1;
                break;
            case 50:
                image = 2;
                break;
            case 100:
                image = 3;
                break;
            default:
                image = 0;
                break;


        }

        betSprites.Add(Instantiate(prefb));
        betSprites[betSprites.Count - 1].GetComponent<SpriteRenderer>().sprite = spritesPrefabs[image];
        //  Camera.main.ScreenToWorldPoint(placers[image].transform.position);
        betSprites[betSprites.Count - 1].transform.position = (Camera.main.ScreenToWorldPoint(placers[image].transform.position));
        StartCoroutine(betSprites[betSprites.Count - 1].GetComponent<CorrutineManagerChips>().moveChip(new Vector3(0 + Random.Range(-0.29f, 0.42f), 0 + Random.Range(-0.19f, .34f), (-0.2f * (betSprites.Count - 1)))));


    }



    public void giveMoney(bool win)
    {

        if (win)
        {

            myMoney += currentBet * 2;
            winner = true;

        }
        else
            winner = false;

        showMoney();

    }

    public void giveMoney(bool win, bool win2)
    {


        myMoney += currentBet;
        winner = true;
        showMoney();

    }

    bool winner;

    public void restart()
    {


        PlayerPrefs.SetInt("myMoney", myMoney);

        disableButtons(false);
        currentBet = 0;
        showMoney();
        for (int i = 0; i < betSprites.Count; i++)
        {
            if (winner)
                StartCoroutine(betSprites[i].GetComponent<CorrutineManagerChips>().moveChip(new Vector3(0, -10, (-0.2f * (betSprites.Count - 1))), 20, true));
            else
                StartCoroutine(betSprites[i].GetComponent<CorrutineManagerChips>().moveChip(new Vector3(0, 10, (-0.2f * (betSprites.Count - 1))), 20, false));

        }
        StartCoroutine(clearArray());


        //for (int i = 0; i < betSprites.Count; i++)
        //{
        //    Destroy(betSprites[i].gameObject);

        //}
        //   betSprites.Clear();

    }

    private IEnumerator clearArray()
    {

        while (betSprites.Count > 0)
        {

            int i = 0;
            for (; i < betSprites.Count; i++)
            {

                if (betSprites[i] != null)
                    i = 5000;


            }


            if (i != 5000)
                betSprites.Clear();
            else
                yield return null;

        }




    }

    // Update is called once per frame
    void Update()
    {



    }
}
