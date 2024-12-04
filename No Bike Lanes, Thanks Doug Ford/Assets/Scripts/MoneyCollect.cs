using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyCollect : MonoBehaviour
{
    private Timer timerAndMoneyDisplay; // Reference to the main UI logic

    private void Start()
    {
        // Find the TimerAndMoneyDisplay script in the scene
        timerAndMoneyDisplay = FindObjectOfType<Timer>();
        if (timerAndMoneyDisplay == null)
        {
            Debug.LogError("TimerAndMoneyDisplay script not found in the scene!");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && timerAndMoneyDisplay != null)
        {
            // Call the method to update the money display
            timerAndMoneyDisplay.UpdateMoneyDisplay();

            // Destroy the money prefab after being collected
            Destroy(this.gameObject);
        }
    }
}