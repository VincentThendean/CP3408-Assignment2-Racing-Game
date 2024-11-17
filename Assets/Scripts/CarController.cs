using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public int carID; // Unique ID for each car
    public string carName; // Optional: A unique name for the car
    public float finishTime; // Time when the car crosses the finish line
    public int lapNumber;
    public int checkpointIndex;

    // Start is called before the first frame update
    void Start()
    {
        lapNumber = 1;
        checkpointIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
