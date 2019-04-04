using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cards : MonoBehaviour {

    public char nameCard;
    public int value;
    private GameObject upCard, downCard;
    private SpriteRenderer sr;
    public bool animationEnded = true;

	// Use this for initialization
	void Start () {




    }

    public void setCards() {

        upCard = transform.Find("Up").gameObject;
        downCard = transform.Find("Down").gameObject;
        upCard.SetActive(false);
        downCard.SetActive(true);
        upCard.transform.localPosition = Vector3.zero;

    }


    public void turnDownCard() {

        upCard.SetActive(false);
        downCard.SetActive(true);

    }

    public void turnUpCard()
    {

        upCard.SetActive(true);
        downCard.SetActive(false);

    }

    public void showCard() {

        upCard.SetActive(!upCard.activeSelf);
        downCard.SetActive(!downCard.activeSelf);

    }

    public void animCard(Vector3 positionToGo, float speed) {

        while (transform.position != positionToGo)
        {
           // Debug.Log("Executin card corrutine...");
          //  transform.position = Vector3.MoveTowards(transform.position, positionToGo, speed * Time.deltaTime);
          
        }

    }

    // Update is called once per frame
    void Update () {

    }
}
