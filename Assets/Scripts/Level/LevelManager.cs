using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

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

    public void onPlayerDeath() => levelUI.ShowGameLoseUI();

    public void RestartLevel() => SceneManager.LoadScene(currentSceneIndex);

    public void LoadMainMenu() => SceneManager.LoadScene(mainMenuIndex);
}
