using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    public Button playButton;
    public Button quitButton;

    private SoundManager soundManager;

    private const int firstLevel = 1;

    private void Awake()
    {
        AddListerers();
        soundManager = FindObjectOfType<SoundManager>();
    }

    private void AddListerers()
    {
        playButton.onClick.AddListener(Play);
        quitButton.onClick.AddListener(Quit);
    }

    public void Play()
    {
        soundManager.PlayButtonClickAudio();
        SceneManager.LoadScene(firstLevel);
    }

    public void Quit()
    {
        soundManager.PlayButtonClickAudio();
        
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}