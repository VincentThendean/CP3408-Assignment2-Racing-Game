using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Put this on Checkpoints
public class Checkpoint : MonoBehaviour
{
    public int index;


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.GetComponent<CarController>())
        {
            CarController agent = collision.gameObject.GetComponent<CarController>();
            if(agent.checkpointIndex == index-1)
            {
                agent.checkpointIndex = index;
            }
        }
    }
}
