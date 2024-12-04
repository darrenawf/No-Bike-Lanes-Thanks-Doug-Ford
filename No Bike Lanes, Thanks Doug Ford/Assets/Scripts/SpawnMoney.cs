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
            spawnTime = Random.Range(0.1f, 4f);
            spawnTime = Time.time + spawnTime; //Reset spawn time
        }
    }

    // Spawn object within range
    void Spawn()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        float randNum = Random.Range(0f, 1f);
        if (randNum <= 1f && randNum > 0.7f) // 30% Money
        {
            Instantiate(moneyObj, transform.position + new Vector3(randomX, randomY, 0), transform.rotation);
        }
        else // 70% Coin
        {
            Instantiate(coinObj, transform.position + new Vector3(randomX, randomY, 0), transform.rotation);
        }
        
    }
}


