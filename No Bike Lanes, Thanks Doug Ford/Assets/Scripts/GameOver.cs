using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    //Variables
    public GameObject gameOverPanel;
    public AudioSource backgroundMusic;
    public AudioSource oofSFX;
    private bool isGameOver = false;
    private CanvasMod timer;
    public float totalTime;

    void Start()
    {
        // Find the Timer component in the scene
        timer = FindObjectOfType<CanvasMod>();
    }

    void Update()
    {
        // Game Over Function
        if (!isGameOver && GameObject.FindGameObjectWithTag("Player") == null)
        {
            isGameOver = true;

            // Stop the timer and save the total time
            if (timer != null)
            {
                timer.StopTimer();
                totalTime = timer.ElapsedTime;
            }

            // Activate Game Over panel
            gameOverPanel.SetActive(true);

            // Stop background music
            if (backgroundMusic != null)
            {
                backgroundMusic.Stop();
            }

            // Play crash sfx
            if (oofSFX != null && oofSFX.clip != null)
            {
                oofSFX.PlayOneShot(oofSFX.clip);
            }
        }
    }

    // Restart Scene
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}