using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CanvasMod : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText; // Timer text field
    [SerializeField] private TextMeshProUGUI moneyText; // Money text field

    private float elapsedTime;
    private bool isRunning = true;
    public int moneyValue;

    private int moneyCollected = 0; // Tracks how much money has been collected
    private int coinsCollected = 0; // Tracks how much money has been collected
    private const int startingMoney = 48000000; // Starting money amount

    // Public property to get the elapsed time
    public float ElapsedTime => elapsedTime;

    void Update()
    {
        // Update timer
        if (isRunning)
        {
            elapsedTime += Time.deltaTime;

            int minutes = Mathf.FloorToInt(elapsedTime / 60);
            int seconds = Mathf.FloorToInt(elapsedTime % 60);

            timerText.text = $"{minutes}m {seconds:00}s";
        }
    }

    // Method to stop the timer
    public void StopTimer()
    {
        isRunning = false;
    }

    // Method to update the money display
    public void UpdateMoneyDisplay()
    {
        moneyCollected += moneyValue; // Increment the money counter by 1

        // Calculate the current total money
        int currentMoney = startingMoney - moneyCollected;

        // Update the moneyText field with the formatted value
        moneyText.text = $"-${currentMoney:N0}";
    }
    public void UpdateCoin()
    {
        coinsCollected += 1; // Increment the money counter by 1
        Debug.Log("Coins: "+coinsCollected+"/4");
        if (coinsCollected == 4)
        {
            // Calculate the current total money
            int currentMoney = startingMoney - moneyCollected;

            // Update the moneyText field with the formatted value
            moneyText.text = $"-${currentMoney:N0}";

            // Reset Bar
            coinsCollected = 0;
        }
    }
}