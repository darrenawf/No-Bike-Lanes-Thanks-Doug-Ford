using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    private CanvasMod canvasMod; // Reference to the main UI logic

    private void Start()
    {
        // Find the canvasMod script in the scene
        canvasMod = FindObjectOfType<CanvasMod>();
        if (canvasMod == null)
        {
            Debug.LogError("canvasMod script not found in the scene!");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && canvasMod != null)
        {
            // Call the method to update the money display
            canvasMod.UpdateCoin();

            // Destroy the money prefab after being collected
            Destroy(this.gameObject);
        }
    }
}