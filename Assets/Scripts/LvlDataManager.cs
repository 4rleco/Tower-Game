using System;
using System.Collections.Generic;
using UnityEngine;

public class LvlDataManager : MonoBehaviour
{
    [SerializeField] private LvlData[] lvlData;
    [SerializeField] private TowerPartSpawner towerPartSpawner;

    List<TowerpartLogic> towerParts = new List<TowerpartLogic>();

    private TowerpartLogic currentpart = null;

    public event Action<bool> OnGameOver;
    public event Action<bool> OnWinGame;

    private void Start()
    {
        for (int i = 0; i < lvlData[0].amountOfParts; i++)
        {
            TowerpartLogic towerPart = Instantiate(lvlData[0].towerpartPrefab, towerPartSpawner.transform);
            towerPart.gameObject.SetActive(false);

            towerParts.Add(towerPart);
        }

        towerPartSpawner.SpawnTowerPart(towerParts[0]);
        currentpart = towerParts[0];
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (towerParts[0].GetIsSpawned())
            {
                towerParts[0].Deatach(true);
                currentpart = towerParts[0];
                towerParts.RemoveAt(0);
            }
        }

        if (towerParts.Count > 0 && currentpart.GetIsColliding())
        {
            towerPartSpawner.SpawnTowerPart(towerParts[0]);
        }

        if(currentpart.GetOnFail())        
            OnGameOver?.Invoke(true);
        

        if (towerParts.Count <= 0 && currentpart.GetIsColliding() && !currentpart.GetOnFail())
            OnWinGame?.Invoke(true);
    }
}
