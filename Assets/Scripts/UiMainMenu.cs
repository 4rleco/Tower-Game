using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiMainMenu : MonoBehaviour
{
    [SerializeField] private Button buttonPlay;
    [SerializeField] private Button buttonSettings;
    [SerializeField] private Button buttonExit;
    [SerializeField] private Button returnButton;

    [SerializeField] private GameObject panelMain;
    [SerializeField] private GameObject panelSettings;
    [SerializeField] private GameObject panelExit;

    private void Awake()
    {
        buttonPlay.onClick.AddListener(OnButtonPlayClicked);
        buttonSettings.onClick.AddListener(OnButtonSettingsClicked);
        buttonExit.onClick.AddListener(OnButtonExitClicked);
        returnButton.onClick.AddListener(OnRetunrButtonClicked);
    }

    private void OnDestroy()
    {
        buttonPlay.onClick.RemoveAllListeners();
        buttonSettings.onClick.RemoveAllListeners();
        buttonExit.onClick.RemoveAllListeners();
    }
    private void OnButtonPlayClicked()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        SceneManager.LoadScene("GamePlay");
    }


    private void OnButtonSettingsClicked()
    {
        panelMain.SetActive(false);
        panelSettings.SetActive(true);
    }

    private void OnButtonExitClicked()
    {
        panelExit.SetActive(false);
        panelSettings.SetActive(true);
    }
    
    private void OnRetunrButtonClicked()
    {
        panelMain.SetActive(true);
        panelSettings.SetActive(false);
    }
}
