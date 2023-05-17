using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    public string gameSceneName = "GameScene";

    private void Update()
    {
        // Check for any input to start the game
        if (Input.anyKeyDown)
        {
            StartGame();
        }
    }

    public void StartGame()
    {
        // Load the game scene
        SceneManager.LoadScene(gameSceneName);
    }
}
