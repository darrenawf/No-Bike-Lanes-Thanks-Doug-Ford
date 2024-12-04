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
    // Start is called before the first frame update
    void Start()
    {
        spawnTime = Time.time + timeBetween;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= spawnTime)
        {
            Spawn();
            spawnTime = Random.Range(1f, 5f);
            spawnTime = Time.time + spawnTime; //Reset spawn time
        }
    }

    // Spawn object within range
    void Spawn()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        float randNum = Random.Range(0f, 1f);
        if (randNum <= 1f && randNum > 0.6f) // 40% Person 1
        {
            Instantiate(personOne, transform.position + new Vector3(randomX, randomY, 0), transform.rotation);
        }
        else if (randNum <= 0.6f && randNum > 0.2f) // 40% Person 2
        {
            Instantiate(personTwo, transform.position + new Vector3(randomX, randomY, 0), transform.rotation);
        }
        else  // 30% Person 3
        {
            Instantiate(personThree, transform.position + new Vector3(randomX, randomY, 0), transform.rotation);
        }
    }
}


