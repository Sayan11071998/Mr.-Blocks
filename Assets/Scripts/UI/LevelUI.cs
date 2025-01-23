using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LevelUI : MonoBehaviour
{
    public GameObject levelPanel;
    public GameObject gameOverPanel;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public Button menuButton;
    public LevelManager levelManager;

    public int levelNumber = 1;

    private void Start() => UpdateLevelText();

    private void UpdateLevelText() => levelText.text = "Level: " + levelNumber;

    private void HideLevelPanel() => levelPanel.SetActive(false);

    private void SetGameOverPanel(bool isActive) => gameOverPanel.SetActive(isActive);

    private void AddListerers()
    {
        menuButton.onClick.AddListener(MainMenuButton);
        restartButton.onClick.AddListener(RestartButton);
    }

    private void MainMenuButton() => levelManager.LoadMainMenu();

    private void RestartButton() => levelManager.RestartLevel();

    public void ShowGameWinUI()
    {
        SetGameOverPanel(true);

        gameOverText.text = "Game Completed!!";
        gameOverText.color = Color.green;
        HideLevelPanel();
    }

    public void ShowGameLoseUI()
    {
        SetGameOverPanel(true);

        gameOverText.text = "Game Over!!";
        gameOverText.color = Color.red;
        HideLevelPanel();
    }
}
