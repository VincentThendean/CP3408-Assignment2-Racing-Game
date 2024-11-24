using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerManager : MonoBehaviour
{
    public bool isBoosted;
    public bool hasBullets;
    public bool gameStateEnd;

    void Start(){
        isBoosted = false;
        hasBullets = false;
        gameStateEnd = false;
    }
}
