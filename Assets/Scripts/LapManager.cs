using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Put this on the finish line
public class LapManager : MonoBehaviour
{
    public List<Checkpoint> checkpoints;
    public int totalLaps;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.GetComponent<LapChecker>())
        {
            LapChecker agent = collision.gameObject.GetComponent<LapChecker>();
            if (agent.checkpointIndex == checkpoints.Count)
            {
                //Increase the agent's current lap
                agent.checkpointIndex = 0;
                agent.lapNumber++;


                //Check if agent finishes race
                if (agent.lapNumber > totalLaps)
                {
                    Debug.Log("Car finishes the race");
                }
                else
                {
                    Debug.Log($"Car enters lap {agent.lapNumber} out of {totalLaps}");
                }
            }
        }
    }
}
