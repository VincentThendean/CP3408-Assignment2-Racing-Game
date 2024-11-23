using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public GameObject[] powerUpPrefabs;
    //public Transform[] spawnPoints;
    public float spawnStep = 0.5f;
    public float spawnCount = 3;

    public float spawnTime = 5.0f;

    private List<GameObject> currentPowerUps = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(SpawnPowerUp), 0f, spawnTime);
    }

    void SpawnPowerUp()
    {

        foreach (GameObject powerUp in currentPowerUps)
        {
            Destroy(powerUp);
        }

        currentPowerUps.Clear();

        int randomIndex = Random.Range(0, powerUpPrefabs.Length);
        //int randomSpawnPoint = Random.Range(0, spawnPoints.Length);

        Vector3 spaceInterval = spawnStep * transform.forward;
        Vector3 spawnPosition = transform.position + spaceInterval;

        for (int i = 0; i < spawnCount; i++)
        {
            GameObject newPowerUp = Instantiate(powerUpPrefabs[randomIndex],spawnPosition,Quaternion.identity);
            currentPowerUps.Add(newPowerUp);

            spawnPosition += spaceInterval;
        }
    }
}
