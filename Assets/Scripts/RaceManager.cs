using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceManager : MonoBehaviour
{
    public int numberOfCars = 4; 

    private List<GameObject> cars = new List<GameObject>();
    private List<CarController> finishOrder = new List<CarController>();

    // Start is called before the first frame update
    void Start()
    {
        InitializeRace();
    }

    void InitializeRace()
    {
        GameObject[] existingCars = GameObject.FindGameObjectsWithTag("Racer");
        foreach (GameObject car in existingCars)
        {
            cars.Add(car);
        }

        for (int i = cars.Count; i < numberOfCars; i++)
        {
        }
    }
        public void RecordFinish(CarController car)
    {
        if (!finishOrder.Contains(car))
        {
            car.finishTime = Time.time; // Record the time of crossing the finish line
            finishOrder.Add(car);

            Debug.Log($"Car {car.carName} finished in position {finishOrder.Count} at time {car.finishTime}");
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
