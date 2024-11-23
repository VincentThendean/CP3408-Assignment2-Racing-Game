using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpCollectible : MonoBehaviour
{
    public PowerupEffect powerUp;
    public playerManager playerManager;

    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Player_Drive>())
        {
            playerManager = playerManager.GetComponent<playerManager>();

            powerUp.Activate(other.gameObject);
            playerManager.isBoosted = true;

            Destroy(gameObject);
        }
    }
}
