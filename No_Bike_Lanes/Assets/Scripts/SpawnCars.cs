/*
Attached: SpawnTraffic, SpawnTrafficOpp
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpawnCars : MonoBehaviour
{
    //Variables
    public GameObject carBlue;
    public GameObject carGray;
    public GameObject carWhite;
    public GameObject carGreen;
    public GameObject carYellow;
    public GameObject bus;
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
            //Reset spawn time
            spawnTime = Time.time + timeBetween;
        }
    }
    // Randomly Spawn Objects
    void Spawn()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        float randNum = Random.Range(0f, 1f);
        // 90% Cars
        if (randNum <= 0.9f)
        {
            if (randNum <= 0.9f && randNum > 0.65f)
            { //BLUE CAR
                Instantiate(carBlue, transform.position + new Vector3(randomX, randomY, 0), transform.rotation);
            }
            else if (randNum <= 0.65f && randNum > 0.4f)
            { //GRAY CAR
                Instantiate(carGray, transform.position + new Vector3(randomX, randomY, 0), transform.rotation);
            }
            else if (randNum <= 0.4f && randNum > 0.15f)
            { //GRAY CAR
                Instantiate(carWhite, transform.position + new Vector3(randomX, randomY, 0), transform.rotation);
            }
            else if (randNum <= 0.15f && randNum > 0.05f)
            { //GREEN CAR
                Instantiate(carGreen, transform.position + new Vector3(randomX, randomY, 0), transform.rotation);
            }
            else
            { //YELLOW CAR
                Instantiate(carYellow, transform.position + new Vector3(randomX, randomY, 0), transform.rotation);
            }
        }
        // 10% Busses
        else
        {
            //Adjust for bus width in lane
            if (randomY > 0.55f)
            {
                randomY -= 0.265f;
            }
            else if (randomY <= 0.55f && randomY > 0f)
            {
                randomY += 0.265f;
            }
            else if (randomY <= 0f && randomY > -2f)
            {
                randomY -= 0.265f;
            }
            else if (randomY < -2.3f)
            {
                randomY += 0.265f;
            }
            Instantiate(bus, transform.position + new Vector3(randomX, randomY, 0), transform.rotation);
        }
    }
}


