using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpCollectible : MonoBehaviour
{
    public PowerupEffect powerUp;
    playerManager playerStatus;
    
    void Start(){
        playerStatus = FindObjectOfType<playerManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Player_Drive>())
        {
            powerUp.Activate(other.gameObject);
            playerStatus.isBoosted = true;

            Destroy(gameObject);
        }
    }
}
