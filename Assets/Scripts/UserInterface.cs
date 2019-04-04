using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInterface : MonoBehaviour {

    public GameObject iaScore, playerScore;

    public void changePlayerText(string a) {

        playerScore.GetComponentInChildren<Text>().text = a;

    }

    public void changeIAText(string a)
    {

        iaScore.GetComponentInChildren<Text>().text = a;

    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		


	}
}
