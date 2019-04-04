using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrutineManagerChips : MonoBehaviour
{

    private Vector3 pos;

    public IEnumerator moveChip(Vector3 Npos)
    {

        pos = Npos;

        while (Vector3.Distance(transform.position, pos) > 0.01f)
        {
            // pos = new Vector3(0 + Random.Range(-1, 1), 0 + Random.Range(-1, 1), (0.2f * (betSprites.Count - 1)));
            // Debug.Log(Npos + " == " + deckScr.deck[cardsGiven].transform.position);
            transform.position = Vector3.MoveTowards(transform.position, pos, 55 * Time.deltaTime);
            yield return null;

        }


    }

    private SoundsEffects au;

    void Start() {

        au = GameObject.Find("Audio Source").GetComponent<SoundsEffects>(); 

    }

    public IEnumerator moveChip(Vector3 Npos, float speed, bool t)
    {

        au.chipSound();
        pos = Npos;

        while (Vector3.Distance(transform.position, pos) > 0.01f)
        {
            // pos = new Vector3(0 + Random.Range(-1, 1), 0 + Random.Range(-1, 1), (0.2f * (betSprites.Count - 1)));
            // Debug.Log(Npos + " == " + deckScr.deck[cardsGiven].transform.position);
            transform.position = Vector3.MoveTowards(transform.position, pos, speed * Time.deltaTime);
            yield return null;

        }

        Destroy(this.gameObject);


    }

}
