using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private LvlDataManager lvlDataManager;
    [SerializeField] private GameObject gameOverPanel;

    private void Start()
    {
        lvlDataManager.OnGameOver += OnGameOver;
    }

    private void OnDestroy()
    {
        lvlDataManager.OnGameOver -= OnGameOver;
    }

    private void OnGameOver(bool lost)
    {
        Time.timeScale = 0;
        gameOverPanel.SetActive(lost);
    }
}
