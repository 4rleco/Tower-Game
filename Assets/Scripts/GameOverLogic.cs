using UnityEngine;

public class GameOverLogic : MonoBehaviour
{
    [SerializeField] private LvlDataManager lvlDataManager;
    [SerializeField] private GameObject canvas;

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
        canvas.SetActive(lost);
    }
}
