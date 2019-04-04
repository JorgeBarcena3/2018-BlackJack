using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Deck : MonoBehaviour
{
    private const int DECKLENGHT = 52;
    private const int SIMBOLCARDS = 13;

    public List<GameObject> deck = new List<GameObject>();
    public GameObject[] cardsPrefab;
    public GameObject card;
    public int numberOfDecks;



    // Use this for initialization
    void Start()
    {

        createDeck();
        suffleDeck();
        drawDeck();
        this.gameObject.transform.position = new Vector2(4f, 0);




    }

    public void createDeck()
    {

        for (int j = 0; j < numberOfDecks; j++)
        {
            int simbol = 0;
            int cardValue = 0;

            for (int i = 0; i < DECKLENGHT; i++)
            {
                if (i % SIMBOLCARDS == 0 && i != 0)
                {
                    simbol++;
                    cardValue = 0;
                }

                deck.Add(Instantiate(card));
                GameObject aux = Instantiate(cardsPrefab[cardValue]) as GameObject;
                aux.name = "Up";
                aux.transform.parent = deck[deck.Count - 1].transform;

                deck[deck.Count - 1].GetComponent<Cards>().value = aux.GetComponent<Values>().getValues();
                deck[deck.Count - 1].GetComponent<Cards>().nameCard = aux.GetComponent<Values>().nameCard;
                aux.GetComponent<SpriteRenderer>().sprite = aux.GetComponent<Values>().simbol[simbol];
                deck[deck.Count - 1].GetComponent<Cards>().setCards();
                deck[deck.Count - 1].transform.parent = this.gameObject.transform;
                cardValue++;


            }

        }


    }

    public void drawDeck()
    {

        float z_index = 0;

        for (int i = 0; i < deck.Count; i++)
        {

            deck[i].transform.position = new Vector3(transform.position.x, transform.position.y, z_index);
            deck[i].GetComponent<Cards>().turnDownCard();
            z_index += 0.1f;


        }


    }

    public void suffleDeck()
    {


        for (int i = 0; i < deck.Count; i++)
        {
            GameObject temp = deck[i];
            int randomIndex = Random.Range(i, deck.Count);
            deck[i] = deck[randomIndex];
            deck[randomIndex] = temp;
        }


    }

    // Update is called once per frame
    void Update()
    {

    }
}
