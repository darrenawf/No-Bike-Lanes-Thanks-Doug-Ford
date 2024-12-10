/*
Attached: Canvas
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CanvasMod : MonoBehaviour
{
    // Text Field and UI References
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI totalMoneyText;
    [SerializeField] private TextMeshProUGUI moneyText;
    // Variables
    private float elapsedTime;
    private bool isRunning = true;
    private int moneyCollected = 0;
    private int coinsCollected = 0;
    private int currentMoney;
    private const int startingMoney = 48000000;
    // Get Object
    public float ElapsedTime => elapsedTime;
    // Add a SpriteRenderer reference
    [SerializeField] private SpriteRenderer coinBarRenderer;

    // Add references to the sprites
    [SerializeField] private Sprite[] coinBarSprites;
    //Sounds
    public AudioSource coinCollect;
    public AudioSource moneyCollect;
    public AudioSource moneyExchange;
    public AudioSource noMoney;

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
        totalMoneyText.text = "You collected: $" + moneyCollected + "\n out of $48,000,000 in government debt it will cost to remove the bike lanes!!!";
    }

    // Update Money Display
    public void UpdateMoneyDisplay()
    {
        PlayMoneyCollect();

        moneyCollected++;

        currentMoney = startingMoney - moneyCollected;

        moneyText.text = $"-${currentMoney:N0}"; // Update Text Field
    }
    void PlayMoneyCollect()
    {
        moneyCollect.Play();
    }

    // Update Coin
    public void UpdateCoin()
    {
        PlayCoinCollect();
        if (coinsCollected == 4)
        {
            return;
        }
        // Update Coins Collected
        coinsCollected++;
        Debug.Log("Coins: " + coinsCollected + "/4");

        coinBarRenderer.sprite = coinBarSprites[coinsCollected];
    }
    public void UseCoins()
    {
        if (coinsCollected == 4)
        {
            PlayMoneyExchange();
            moneyCollected++;
            currentMoney = startingMoney - moneyCollected;
            // Update Text Field
            moneyText.text = $"-${currentMoney:N0}";
            // Change sprite to first frame
            coinBarRenderer.sprite = coinBarSprites[0];
            // Reset Bar
            coinsCollected = 0;
        }
        else
        {
            PlayNoMoney();
        }
    }
    void PlayCoinCollect()
    {
        coinCollect.Play();
    }
    void PlayMoneyExchange()
    {
        moneyExchange.Play();
    }
    void PlayNoMoney()
    {
        // Prevent Overlapping Sound
        if (!noMoney.isPlaying)
        {
            // Play sound
            noMoney.Play();
        }
    }
}