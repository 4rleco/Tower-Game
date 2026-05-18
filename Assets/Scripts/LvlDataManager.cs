using UnityEngine;
using System.Collections.Generic;


public class LvlDataManager : MonoBehaviour
{
    [SerializeField] private LvlData[] lvlData;
    [SerializeField] private TowerPartSpawner towerPartSpawner;

    List<TowerpartLogic> towerParts = new List<TowerpartLogic>();

    private TowerpartLogic currentpart = null;

    private bool towerPartReleased;

    private void Start()
    {
        for (int i = 0; i < lvlData[0].amountOfParts; i++)
        {
            TowerpartLogic towerPart = Instantiate(lvlData[0].towerpartPrefab, towerPartSpawner.transform);
            towerPart.gameObject.SetActive(false);

            towerParts.Add(towerPart);
        }

        towerPartSpawner.SpawnTowerPart(towerParts[0]);
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
                towerPartReleased = true; 
            }
        }

        if (towerParts.Count > 0 && currentpart.GetIsColliding())
        {
            towerPartSpawner.SpawnTowerPart(towerParts[0]);
            towerPartReleased = false;
        }
    }
}
