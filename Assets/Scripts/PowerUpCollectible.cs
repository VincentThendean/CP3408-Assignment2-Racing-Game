using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpCollectible : MonoBehaviour
{
    public PowerupEffect powerUp;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Player_Drive>())
        {
            powerUp.Activate(other.gameObject);

            Destroy(gameObject);
        }
    }
}
