/*
Attached: Coin Prefab
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    //Display Class
    private CanvasMod canvasMod;

    private void Start()
    {
        canvasMod = FindObjectOfType<CanvasMod>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && canvasMod != null)
        {
            // Update Coin Display
            canvasMod.UpdateCoin();

            // Destory Coin Object
            Destroy(this.gameObject);
        }
    }
}