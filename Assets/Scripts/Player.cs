using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    public bool isSelected;


    public void PlayerSelected() {
        isSelected = true;
        GetComponent<Renderer>().material.color = Color.red;
    }

}
