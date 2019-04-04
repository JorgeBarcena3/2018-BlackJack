using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsEffects : MonoBehaviour {

    public List<AudioClip> audioCards;
    public List<AudioClip> audioChips;
    public List<AudioClip> cardShove;

    public AudioSource aud;

    // Use this for initialization
    void Start () {

       // aud = GetComponent<AudioSource>();
		
	}

    public void cardShoves()
    {

        aud.PlayOneShot(cardShove[Random.Range(0, audioCards.Count - 1)]);
    }

    public void cardSound() {

        aud.PlayOneShot(audioCards[Random.Range(0, audioCards.Count - 1)]);
    }

    public void chipSound()
    {

        aud.PlayOneShot(audioChips[Random.Range(0, audioChips.Count - 1)]);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
