using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverPanel;
    public AudioSource backgroundMusic;
    public AudioSource oofSFX;

    private bool isGameOver = false;

    // Reference to the Timer script
    private CanvasMod timer;

    // Variable to store the total elapsed time
    public float totalElapsedTime;

    void Start()
    {
        // Find the Timer component in the scene
        timer = FindObjectOfType<CanvasMod>();
    }

    void Update()
    {
        if (!isGameOver && GameObject.FindGameObjectWithTag("Player") == null)
        {
            isGameOver = true;

            // Stop the timer and save the total elapsed time
            if (timer != null)
            {
                timer.StopTimer();
                totalElapsedTime = timer.ElapsedTime;
            }

            // Activate the Game Over panel
            gameOverPanel.SetActive(true);

            // Stop the background music
            if (backgroundMusic != null)
            {
                backgroundMusic.Stop();
            }

            // Play the oof sound effect once
            if (oofSFX != null && oofSFX.clip != null)
            {
                oofSFX.PlayOneShot(oofSFX.clip);
            }
        }
    }

    // Method to restart the current scene
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}