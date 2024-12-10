/*
Attached: Money Prefab
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyCollect : MonoBehaviour
{
    private CanvasMod canvasMod;

    private void Start()
    {
        canvasMod = FindObjectOfType<CanvasMod>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && canvasMod != null)
        {
            // Update Money Display
            canvasMod.UpdateMoneyDisplay();

            // Destroy Money Object
            Destroy(this.gameObject);
        }
    }
}