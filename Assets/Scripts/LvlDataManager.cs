using System;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class LvlDataManager : MonoBehaviour
{
    [SerializeField] private LvlData[] lvlData;
    [SerializeField] private TowerPartSpawner towerPartSpawner;
    [SerializeField] private TextMeshProUGUI LifesText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI towerHeightText;
    [SerializeField] private TextMeshProUGUI perfectStreakText;

    private TowerpartLogic heldPart;
    private TowerpartLogic fallingPart;

    private float lifes;
    private float score;
    private int towerHeight;
    private int perfectStreak;

    public event Action<bool> OnGameOver;
    public event Action<bool> OnReleased;

    private bool waitingForLanding;

    private void Start()
    {
        lifes = lvlData[0].lifes;
    }

    private void Update()
    {
        LifesText.text = "Lives: " + lifes;
        scoreText.text = "Score: " + score;
        towerHeightText.text = "Tower Height: " + towerHeight;
        perfectStreakText.text = "Perfect Streak: " + perfectStreak;

        if (heldPart == null && !waitingForLanding && lifes > 0)
        {
            heldPart = Instantiate(lvlData[0].towerpartPrefab, towerPartSpawner.transform);

            towerPartSpawner.SpawnTowerPart(heldPart);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (heldPart != null && heldPart.GetIsSpawned())
            {
                fallingPart = heldPart;
                heldPart.Deatach(true);
                heldPart = null;

                waitingForLanding = true;

                OnReleased?.Invoke(true);
            }
        }

        if (fallingPart != null && fallingPart.GetOnFail())
        {
            lifes--;
        }

        if (fallingPart != null && waitingForLanding && fallingPart.GetIsColliding())
        {
            if (!fallingPart.GetOnFail())
            {
                if (fallingPart.GetOnPerfect())
                {
                    score += lvlData[0].perfectScore;
                    perfectStreak++;
                }
                else
                {
                    score += lvlData[0].score;
                    perfectStreak = 0;
                }
                towerHeight++;
            }

            fallingPart = null;

            waitingForLanding = false;


            OnReleased?.Invoke(false);
        }


        if (lifes <= 0)
        {
            OnGameOver?.Invoke(true);
        }
    }
}
