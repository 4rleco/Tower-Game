using UnityEngine;

public class UiGamePlay : MonoBehaviour
{
    [SerializeField] private GameObject panelSettings;
    [SerializeField] private GameObject gameOverPanel;

    private bool isPaused = false;

    private void Update()
    {
        if (Input.GetKey(KeyCode.P) ||
            Input.GetKey(KeyCode.Escape) && !gameOverPanel.activeSelf)
        {
            TogglePause();
        }
    }

    private void TogglePause()
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0 : 1;
        panelSettings.SetActive(isPaused);
        Cursor.lockState = isPaused ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = isPaused;
    }
}
