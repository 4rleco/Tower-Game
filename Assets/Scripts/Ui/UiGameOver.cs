using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiGameOver : MonoBehaviour
{
    [SerializeField] private GameObject settingsPanel;

    [SerializeField] private Button retryButton;
    [SerializeField] private Button returnToMenuButton;

    private void Awake()
    {
        retryButton.onClick.AddListener(OnRetryButtonClicked);
        returnToMenuButton.onClick.AddListener(OnReturnToMenuButton);
    }

    private void OnDestroy()
    {
        retryButton.onClick.RemoveAllListeners();
        returnToMenuButton.onClick.RemoveAllListeners();
    }

    private void OnRetryButtonClicked()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        settingsPanel.SetActive(false);
    }
    
    private void OnReturnToMenuButton()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        settingsPanel.SetActive(false);
        SceneManager.LoadScene("MainMenu");
    }
}
