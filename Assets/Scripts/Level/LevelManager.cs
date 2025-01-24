using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public LevelUI levelUI;

    private int currentSceneIndex;
    private const int mainMenuIndex = 0;

    private void Start() => currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

    public void OnLevelComplete() => LoadNextLevel();

    private void LoadNextLevel()
    {
        int nextSceneIndex = currentSceneIndex + 1;
        int totalNumberOfScenes = SceneManager.sceneCountInBuildSettings;

        if (nextSceneIndex < totalNumberOfScenes)
            SceneManager.LoadScene(nextSceneIndex);
        else
            levelUI.ShowGameWinUI();
    }

    public void onPlayerDeath()
    {
        GameManager.isPlayerDead = true;
        levelUI.ShowGameLoseUI();
    }

    public void RestartLevel()
    {
        GameManager.ResetGameState();
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void LoadMainMenu() => SceneManager.LoadScene(mainMenuIndex);
}