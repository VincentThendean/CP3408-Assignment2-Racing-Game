using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PowerUps/Shooting")]
public class Shooting : PowerupEffect
{
    public float bulletCount;
    public float bulletSpeed = 100.0f;
    public float bulletLifetime = 5.0f;

    public override void Activate(GameObject target)
    {
        Player_Drive racer = target.GetComponent<Player_Drive>();
        if (racer != null)
        {
            //racer.StartCoroutine(racer.Shooting(duration, bulletCount, bulletSpeed, bulletLifetime));
            racer.StartCoroutine(racer.AllowShooting(duration));
        }
    }
}
