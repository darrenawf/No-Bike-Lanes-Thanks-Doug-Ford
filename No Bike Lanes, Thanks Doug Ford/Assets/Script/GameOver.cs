using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Assign this in the Inspector to show the Game Over screen
    public GameObject gameOverPanel;

    // Reference to the Background Music Audio Source
    public AudioSource backgroundMusic;

    // Reference to the oofSFX Audio Source
    public AudioSource oofSFX;

    // Boolean to track if Game Over logic has been triggered
    private bool isGameOver = false;

    void Update()
    {
        // Check if the Player GameObject is missing and Game Over hasn't been triggered
        if (!isGameOver && GameObject.FindGameObjectWithTag("Player") == null)
        {
            isGameOver = true; // Mark as Game Over to prevent multiple triggers

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
            else
            {
                Debug.LogWarning("oofSFX AudioSource or its AudioClip is missing!");
            }
        }
    }

    // Method to restart the current scene
    public void Restart()
    {
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}