using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private int currentSceneIndex;

    private void Start() => currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

    public void OnLevelComplete() => LoadNextLevel();

    private void LoadNextLevel()
    {
        int nextSceneIndex = currentSceneIndex + 1;
        int totalNumberOfScenes = SceneManager.sceneCountInBuildSettings;

        if (nextSceneIndex < totalNumberOfScenes)
            SceneManager.LoadScene(nextSceneIndex);
        else
            Debug.Log("You have completed all levels!!");
    }

    public void onPlayerDeath() => RestartLevel();

    public void RestartLevel() => SceneManager.LoadScene(currentSceneIndex);
}
