using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Put this on the finish line
public class LapManager : MonoBehaviour
{
    public RaceManager raceManager;

    public List<Checkpoint> checkpoints;
    public int totalLaps;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.GetComponent<CarController>())
        {
            CarController agent = collision.gameObject.GetComponent<CarController>();
            if (agent.checkpointIndex == checkpoints.Count)
            {
                //Increase the agent's current lap
                agent.checkpointIndex = 0;
                agent.lapNumber++;


                //Check if agent finishes race
                if (agent.lapNumber > totalLaps)
                {
                    Debug.Log("Car finishes the race");
                    raceManager.RecordFinish(agent);
                }
                else
                {
                    Debug.Log($"Car enters lap {agent.lapNumber} out of {totalLaps}");
                }
            }
        }
    }
}
