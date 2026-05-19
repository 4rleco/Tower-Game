using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiMainMenu : MonoBehaviour
{
    [SerializeField] private Button buttonPlay;
    [SerializeField] private Button buttonSettings;
    [SerializeField] private Button returnSettingsButton;
    [SerializeField] private Button creditsButton;
    [SerializeField] private Button returnCreditssButton;
    [SerializeField] private Button buttonExit;

    [SerializeField] private GameObject mainPanel;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject creditsPanel;

    private void Awake()
    {
        buttonPlay.onClick.AddListener(OnButtonPlayClicked);
        buttonSettings.onClick.AddListener(OnButtonSettingsClicked);
        creditsButton.onClick.AddListener(OnCreditsButtonClicked);
        returnCreditssButton.onClick.AddListener(OnReturnCreditsButtonClicked);
        buttonExit.onClick.AddListener(OnButtonExitClicked);
        returnSettingsButton.onClick.AddListener(OnRetunrButtonClicked);
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
        mainPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    private void OnCreditsButtonClicked()
    {
        mainPanel.SetActive(false);
        creditsPanel.SetActive(true);
    }

    private void OnReturnCreditsButtonClicked()
    {
        mainPanel.SetActive(true);
        creditsPanel.SetActive(false);
    }

    private void OnButtonExitClicked()
    {
        settingsPanel.SetActive(false);
        Application.Quit();
    }
    
    private void OnRetunrButtonClicked()
    {
        mainPanel.SetActive(true);
        settingsPanel.SetActive(false);
    }
}
