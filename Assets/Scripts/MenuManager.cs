using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour {

    public AudioSource music, effects;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void pause() {

        Time.timeScale = 0;

    }


    public void unPause()
    {

        Time.timeScale = 1;

    }

    public void twitter() {
        Application.OpenURL("https://twitter.com/Jorge_barcena3");

    }

}
