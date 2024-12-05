using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CanvasMod : MonoBehaviour
{
    //Variables
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI moneyText;
    private float elapsedTime;
    private bool isRunning = true;
    private int moneyCollected = 0;
    private int coinsCollected = 0;
    private const int startingMoney = 48000000;
    // Coin Bar Variables
    private SpriteRenderer spriteRenderer;
    // Get Object
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

    // Stop Timer
    public void StopTimer()
    {
        isRunning = false;
    }

    // Update Money Display
    public void UpdateMoneyDisplay()
    {
        moneyCollected ++;

        int currentMoney = startingMoney - moneyCollected;

        moneyText.text = $"-${currentMoney:N0}"; // Update Text Field
    }
    //Update Coin
    public void UpdateCoin()
    {
        coinsCollected ++;
        Debug.Log("Coins: "+coinsCollected+"/4");

        if (coinsCollected == 4)
        {
            int currentMoney = startingMoney - moneyCollected;

            moneyText.text = $"-${currentMoney:N0}"; // Update Text Field

            coinsCollected = 0;// Reset Bar
        }
    }
}