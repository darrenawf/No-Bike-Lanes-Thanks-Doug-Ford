using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadGameScene()
    {
        SceneManager.LoadScene(1);
    }

    // Method to exit to Scene 0 (first scene in Build Settings)
    public void LoadStartScene()
    {
        // Log the action for debugging
        Debug.Log("Exiting to Scene 0 (Main Menu)");

        // Load Scene 0
        SceneManager.LoadScene(0);
    }
}