using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    float elapsedTime;

    // Public property to get the elapsed time
    public float ElapsedTime => elapsedTime;

    // Boolean to control whether the timer is running
    private bool isRunning = true;

    void Update()
    {
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
}