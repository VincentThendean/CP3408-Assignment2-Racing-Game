using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PowerUps/SpeedBoost")]
public class SpeedBoost : PowerupEffect
{
    public float speedEffect = 2.0f;

    public override void Activate(GameObject target)
    {
        Player_Drive racer = target.GetComponent<Player_Drive>();
        if (racer != null )
        {
            racer.StartCoroutine(racer.SpeedBoost(duration, speedEffect));
        }
    }
}
