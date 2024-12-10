/*
Attached: Game Manager
*/
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadGameScene()
    {
        // Load Scene 1
        SceneManager.LoadScene(1);
    }
    public void LoadStartScene()
    {
        // Load Scene 0
        SceneManager.LoadScene(0);
    }
}