using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    private const int firstLevel = 1;

    public void Play() => SceneManager.LoadScene(firstLevel);

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Game Quit");
    }
}
