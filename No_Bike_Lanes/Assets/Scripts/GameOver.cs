/*
Attached: Game Manager, Buttons
*/
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Variables
    public GameObject gameOverPanel;
    public AudioSource backgroundMusic;
    public AudioSource oofSFX;
    private bool isGameOver = false;
    private CanvasMod timer;
    private CameraShake cameraShake;
    public float totalTime = 0;
    //Camera Shake
    public float shakeDuration;
    public float shakeMagnitude;

    void Start()
    {
        // Find the Timer component in the scene
        timer = FindObjectOfType<CanvasMod>();

        // Find the CameraShake component in the scene
        cameraShake = FindObjectOfType<CameraShake>();

        // Ensure the Game Over panel is initially inactive
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
    }

    void Update()
    {
        // Check if the player is gone and game over hasn't already been triggered
        if (!isGameOver && GameObject.FindGameObjectWithTag("Player") == null)
        {
            TriggerGameOver();
        }
    }

    private void TriggerGameOver()
    {
        isGameOver = true;

        // Trigger the camera shake
        if (cameraShake != null)
        {
            cameraShake.ShakeCamera(shakeDuration, shakeMagnitude, true, true);
        }

        // Stop the timer and save the total time
        if (timer != null)
        {
            timer.StopTimer();
            totalTime = timer.ElapsedTime;
        }

        // Activate the Game Over panel
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }

        // Stop the background music
        if (backgroundMusic != null)
        {
            backgroundMusic.Stop();
        }

        // Play the crash sound effect
        if (oofSFX != null && oofSFX.clip != null)
        {
            oofSFX.PlayOneShot(oofSFX.clip);
        }
    }

    // Restart the current scene
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}