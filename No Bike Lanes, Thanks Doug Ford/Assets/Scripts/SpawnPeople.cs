using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpawnPeople : MonoBehaviour
{
    //Variables
    public GameObject personOne;
    public GameObject personTwo;
    public GameObject personThree;
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
        if (Time.time >= spawnTime)
        {
            Spawn();
            // Change spawn time to random value between 0.1 to 4 seconds
            spawnTime = Random.Range(1f, 5f);
            //Reset spawn time
            spawnTime = Time.time + spawnTime;
        }
    }

    // Randomly Spawn Objects
    void Spawn()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        float randNum = Random.Range(0f, 1f);
        // 40% Person 1
        if (randNum <= 1f && randNum > 0.6f)
        {
            Instantiate(personOne, transform.position + new Vector3(randomX, randomY, 0), transform.rotation);
        }
        // 40% Person 2
        else if (randNum <= 0.6f && randNum > 0.2f)
        {
            Instantiate(personTwo, transform.position + new Vector3(randomX, randomY, 0), transform.rotation);
        }
        // 30% Person 3
        else
        {
            Instantiate(personThree, transform.position + new Vector3(randomX, randomY, 0), transform.rotation);
        }
    }
}


