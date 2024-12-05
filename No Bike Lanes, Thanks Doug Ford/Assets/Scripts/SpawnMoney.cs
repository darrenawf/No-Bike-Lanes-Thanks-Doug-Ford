using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpawnMoney : MonoBehaviour
{
    //Variables
    public GameObject moneyObj;
    public GameObject coinObj;
    public float maxX;
    public float maxY;
    public float minX;
    public float minY;
    public float timeBetween;
    private float spawnTime;

    void Start()
    {
        // Initial spawn time
        spawnTime = Time.time + timeBetween;
    }

    void Update()
    {
        // Spawn every interval of spawnTime
        if (Time.time >= spawnTime)
        {
            Spawn();
            // Change spawn time to random value between 0.1 to 4 seconds
            spawnTime = Random.Range(0.1f, 4f);
            // Reset spawn time
            spawnTime = Time.time + spawnTime; 
        }
    }

    // Randomly Spawn Objects
    void Spawn()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        float randNum = Random.Range(0f, 1f);
        // 30% Money
        if (randNum <= 1f && randNum > 0.7f)
        {
            Instantiate(moneyObj, transform.position + new Vector3(randomX, randomY, 0), transform.rotation);
        }
        // 70% Coin
        else
        {
            Instantiate(coinObj, transform.position + new Vector3(randomX, randomY, 0), transform.rotation);
        }
        
    }
}


