using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class effectsFollower : MonoBehaviour
{

    public float distance = 10;
    public ParticleSystem ps;

    // Update is called once per frame
    void Update()
    {


        if (Input.GetMouseButton(0))
        {
            distance = 10;
            if (!ps.isPlaying)
                ps.Play();
            Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 pos = r.GetPoint(distance);
            transform.position = pos;
        }
        else
            distance = 0;


    }


}
