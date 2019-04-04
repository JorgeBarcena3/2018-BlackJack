using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    private GameObject deck;
    private GameObject player;
    private GameObject ia;
    private IA iaScr;
    private Deck deckScr;
    private Player playerScr;
    private float z_index = 0;
    private int cardsGiven = 0;
    private bool endGame = true;
    private bool newGameReady;
    public GameObject ready, pass, pedir, whoIsTheWinner;
    public UserInterface UI;
    public betManager bet;
    public float speed;
    public SoundsEffects effects;
    public Animator anim;

    bool IaFinish = false;

    ////////////////////////////////
    ///////////////////////////////////
    ///////////////////////////////////

    public void beReady()
    {

        newGameReady = true;
        pass.GetComponent<Button>().interactable = false;

    }

    void Start()
    {
        //ready.SetActive(false);
        //whoIsTheWinner.SetActive(false);
        whoIsTheWinner.GetComponent<Text>().text = ("Welcome");


        ia = GameObject.Find("IA");
        iaScr = ia.GetComponent<IA>();

        deck = GameObject.Find("Deck");
        deckScr = deck.GetComponent<Deck>();

        player = GameObject.Find("Player");
        playerScr = player.GetComponent<Player>();





    }

    public void passFunction()
    {
        pedir.GetComponent<Button>().interactable = false;

        iaScr.trueScore();

        if (iaScr.takeCard())
        {

            if (IaFinish)
            {

                doAMovement(true);
            }


        }
        else
            checkWinner();



    }

    void Update()
    {
        if (endGame)
        {
            if (iaScr.score != 0)
            {
                UI.iaScore.SetActive(true);
                UI.playerScore.SetActive(true);
            }
            bet.disableButtons(true);
            pass.GetComponent<Button>().interactable = false;
            pedir.GetComponent<Button>().interactable = false;
            iaScr.trueScore();
            UI.changeIAText(iaScr.scoreToSee.ToString());
            

            // ready.GetComponent<Animation>().Play();
            // ready.GetComponent<Animation>()["Appears"].wrapMode = WrapMode.Once;
            // ready.GetComponent<Animation>().Play();
            //whoIsTheWinner.SetActive(true);

            if (newGameReady)
            {

                restartGame();
                newGameReady = false;
                endGame = false;
            }
        }
        else
        {


            if (cardsGiven >= 4)
            {

                UI.iaScore.SetActive(true);
                UI.playerScore.SetActive(true);
            }
            else
            {
                UI.iaScore.SetActive(false);
                UI.playerScore.SetActive(false);

            }

            if (playerScr.score == 21)
            {

                passFunction();

            }

            if (playerScr.score == 21)
                pass.GetComponent<Button>().interactable = false;

            if (bet.currentBet == 0)
            {

                pass.GetComponent<Button>().interactable = false;
                pedir.GetComponent<Button>().interactable = false;
            }
            else
            {
                if (cardsGiven <= 0)
                    pass.GetComponent<Button>().interactable = false;
                // else
                //  pass.GetComponent<Button>().interactable = true;

                //pass.GetComponent<Button>().interactable = true;
                pedir.GetComponent<Button>().interactable = true;

            }
        }


    }

    void checkWinner()
    {
        if (playerScr.loss())
        {
            bet.giveMoney(false);
            whoIsTheWinner.GetComponent<Text>().text = ("The IA is the winner");
            endGame = true;
            ready.SetActive(true);
            anim.SetTrigger("Entry");
           // restartGame();
        }
        else

        if (iaScr.loss())
        {
            bet.giveMoney(true);
            whoIsTheWinner.GetComponent<Text>().text = ("The player is the winner");
            endGame = true;
            ready.SetActive(true);
            anim.SetTrigger("Entry");
            //   restartGame();
        }
        else if (iaScr.score < playerScr.score)
        {
            bet.giveMoney(true);
            whoIsTheWinner.GetComponent<Text>().text = ("The player is the winner");
            ready.SetActive(true);
            anim.SetTrigger("Entry");
            endGame = true;
            //   restartGame();

        }
        else if (iaScr.score > playerScr.score)
        {
            bet.giveMoney(false);
            whoIsTheWinner.GetComponent<Text>().text = ("The IA is the winner");
            endGame = true;
            ready.SetActive(true);
            anim.SetTrigger("Entry");
            //  restartGame();

        }
        else
        {
            bet.giveMoney(false, false);
            whoIsTheWinner.GetComponent<Text>().text = ("Is a tie");
            endGame = true;
            ready.SetActive(true);
            anim.SetTrigger("Entry");
            // restartGame();
        }

    }

    private void restartGame()
    {
        //Deck
        deckScr.drawDeck();
        deckScr.suffleDeck();
        deckScr.drawDeck();

        //Game Manager
        z_index = 0;
        cardsGiven = 0;

        //Entities
        iaScr.restartGame();
        playerScr.restartGame();

        //UI
        pedir.GetComponent<Button>().interactable = true;
      // ready.SetActive(true);
        anim.SetTrigger("Exit");
      //  ready.SetActive(false);
       // whoIsTheWinner.SetActive(false);
        UI.iaScore.SetActive(false);
        UI.playerScore.SetActive(false);
        pass.GetComponent<Button>().interactable = false;
        // pedir.GetComponent<Button>().interactable = false;

        //Bet
        bet.restart();

        //Corutines
        StopAllCoroutines();

    }

    public void doIntectuableStand()
    {

        pass.GetComponent<Button>().interactable = true;


    }

    public void doAMovement()
    {

        if (cardsGiven == 0)
        {
            StartCoroutine(giveACardToIA());
            //   StartCoroutine(giveACardToPlayer());
            //   StartCoroutine(giveACardToIA());            
            //   StartCoroutine(giveACardToPlayer());

        }
        else
        {

            StartCoroutine(giveACardToPlayer());

        }


        //   StartCoroutine(giveACardToIA());
    }

    public void doAMovement(bool b)
    {
        IaFinish = false;
        StartCoroutine(giveACardToIAAutomaticly());
    }

    private IEnumerator giveACardToPlayer()
    {
        pass.GetComponent<Button>().interactable = false;
        effects.cardSound();

        while (IaFinish == false)
        {
            yield return new WaitForSeconds(.2f);
        }




        if (!endGame)
        {
            pedir.GetComponent<Button>().interactable = false;
            Vector3 pos = new Vector3(player.transform.position.x - (1) + (0.5f * playerScr.myCards.Count), player.transform.position.y + 1.5f, z_index);

            while (Vector3.Distance(deckScr.deck[cardsGiven].transform.position, pos) > 0.01f)
            {
                pos = new Vector3(player.transform.position.x - (1) + (0.5f * playerScr.myCards.Count), player.transform.position.y + 1.5f, z_index);
                // Debug.Log(Npos + " == " + deckScr.deck[cardsGiven].transform.position);
                deckScr.deck[cardsGiven].transform.position = Vector3.MoveTowards(deckScr.deck[cardsGiven].transform.position, pos, speed * Time.deltaTime);
                yield return null;

            }
            // StopAllCoroutines();
            // deckScr.deck[cardsGiven].transform.position = new Vector3(player.transform.position.x - (1) + (0.5f * playerScr.myCards.Count), player.transform.position.y + 1.5f, z_index);
            //  deckScr.deck[cardsGiven].   transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.transform.position.x - (1) + (0.5f * playerScr.myCards.Count), player.transform.position.y + 1.5f, z_index), 0.8f);
            deckScr.deck[cardsGiven].GetComponent<Cards>().showCard();
            playerScr.addCard(deckScr.deck[cardsGiven]);
            UI.changePlayerText(playerScr.score.ToString());
            cardsGiven++;
            z_index -= 0.1f;
            if (playerScr.loss())
                checkWinner();
            if (cardsGiven == 2)
                StartCoroutine(giveACardToIA());


        }

        if (cardsGiven >= 4)
        {

            pass.GetComponent<Button>().interactable = true;

        }



    }

    private IEnumerator giveACardToIAAutomaticly()
    {
        effects.cardSound();
        pass.GetComponent<Button>().interactable = false;

        if (!endGame)
        {
            bool firstCard = false;

            if (iaScr.takeCard())
            {
                while (!firstCard)
                {
                    Vector3 pos = new Vector3(ia.transform.position.x - (1.5f) + (0.5f * iaScr.myCards.Count), ia.transform.position.y - .2f, z_index);

                    while (Vector3.Distance(deckScr.deck[cardsGiven].transform.position, pos) > 0.01f)
                    {
                        pos = new Vector3(ia.transform.position.x - (1.5f) + (0.5f * iaScr.myCards.Count), ia.transform.position.y, z_index);
                        // Debug.Log(pos + " == " + deckScr.deck[cardsGiven].transform.position);
                        deckScr.deck[cardsGiven].transform.position = Vector3.MoveTowards(deckScr.deck[cardsGiven].transform.position, pos, speed * Time.deltaTime);
                        yield return null;

                    }

                    //deckScr.deck[cardsGiven].transform.position = new Vector3(ia.transform.position.x - (1.5f) + (0.5f * iaScr.myCards.Count), ia.transform.position.y, z_index);
                    if (cardsGiven >= 1)
                        deckScr.deck[cardsGiven].GetComponent<Cards>().showCard();
                    iaScr.addCard(deckScr.deck[cardsGiven]);
                    UI.changeIAText(iaScr.scoreToSee.ToString());
                    cardsGiven++;
                    z_index -= 0.1f;
                    //firstCard = true;
                    if (cardsGiven == 1)
                        firstCard = false;
                    else
                        firstCard = true;

                    if (iaScr.takeCard())
                    {
                        StartCoroutine(giveACardToIAAutomaticly());
                    }
                    else
                        checkWinner();
                }
            }
            IaFinish = true;
        }


    }

    private IEnumerator giveACardToIA()
    {
        effects.cardSound();
        pass.GetComponent<Button>().interactable = false;

        if (!endGame)
        {
            if (iaScr.takeCard())
            {

                Vector3 pos = new Vector3(ia.transform.position.x - (1.5f) + (0.5f * iaScr.myCards.Count), ia.transform.position.y - .2f, z_index);

                while (Vector3.Distance(deckScr.deck[cardsGiven].transform.position, pos) > 0.01f)
                {
                    pos = new Vector3(ia.transform.position.x - (1.5f) + (0.5f * iaScr.myCards.Count), ia.transform.position.y, z_index);
                    // Debug.Log(pos + " == " + deckScr.deck[cardsGiven].transform.position);
                    deckScr.deck[cardsGiven].transform.position = Vector3.MoveTowards(deckScr.deck[cardsGiven].transform.position, pos, speed * Time.deltaTime);
                    yield return null;

                }

                //deckScr.deck[cardsGiven].transform.position = new Vector3(ia.transform.position.x - (1.5f) + (0.5f * iaScr.myCards.Count), ia.transform.position.y, z_index);
                if (cardsGiven >= 1)
                    deckScr.deck[cardsGiven].GetComponent<Cards>().showCard();
                iaScr.addCard(deckScr.deck[cardsGiven]);
                UI.changeIAText(iaScr.scoreToSee.ToString());
                cardsGiven++;
                z_index -= 0.1f;
                IaFinish = true;
                if (cardsGiven == 1)
                    StartCoroutine(giveACardToPlayer());
                else if (cardsGiven == 3)
                    StartCoroutine(giveACardToPlayer());

            }

        }
        //    pass.GetComponent<Button>().interactable = true;

    }
}
