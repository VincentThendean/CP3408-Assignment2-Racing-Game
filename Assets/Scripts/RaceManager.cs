using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

        // Check if all cars have finished
        if (finishOrder.Count == cars.Count)
        {
            Debug.Log("Race finished");
            SaveResults(); // Save race results to share with the next scene
            SceneManager.LoadScene("FinishScene"); // Transition to FinishScene
        }
    }

    void SaveResults()
    {
        RaceResults.results = new List<string>(); // Initialize the results list

        foreach (var car in finishOrder)
        {
            string result = $"{car.carName} - Position {finishOrder.IndexOf(car) + 1} - Time: {car.finishTime:F2} seconds";
            RaceResults.results.Add(result); // Add formatted results
        }
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
