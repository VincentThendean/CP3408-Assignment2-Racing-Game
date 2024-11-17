using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Put this on Checkpoints
public class Checkpoint : MonoBehaviour
{
    public int index;


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.GetComponent<LapChecker>())
        {
            LapChecker agent = collision.gameObject.GetComponent<LapChecker>();
            if(agent.checkpointIndex == index-1)
            {
                agent.checkpointIndex = index;
            }
        }
    }
}
