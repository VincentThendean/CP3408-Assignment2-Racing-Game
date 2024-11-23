using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerupEffect : ScriptableObject
{
    public string powerUpName;
    public float duration;

    public abstract void Activate(GameObject target);

}
