using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private LvlDataManager lvlDataManager;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject winPanel;

    private void Start()
    {
        lvlDataManager.OnGameOver += OnGameOver;
        lvlDataManager.OnWinGame += OnWinGame;
    }

    private void OnDestroy()
    {
        lvlDataManager.OnGameOver -= OnGameOver;
        lvlDataManager.OnWinGame -= OnWinGame;
    }

    private void OnGameOver(bool lost)
    {
        Time.timeScale = 0;
        gameOverPanel.SetActive(lost);
    }

    private void OnWinGame(bool win)
    {
        Time.timeScale = 0;
        winPanel.SetActive(win);
    }
}
