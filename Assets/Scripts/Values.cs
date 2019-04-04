using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Values : MonoBehaviour {
    
    public char nameCard;
    public  int[] value = new int [2];
    public Sprite[] simbol = new Sprite[4];

    public int getValues() {
        return value[0];
    }
}
