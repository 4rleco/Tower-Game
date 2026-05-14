using UnityEngine;
using System.Collections.Generic;


public class LvlDataManager : MonoBehaviour
{
    [SerializeField] private LvlData[] lvlData;
    [SerializeField] private TowerPartSpawner towerPartSpawner;

    List<TowerpartLogic> towerParts = new List<TowerpartLogic>();

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
            towerParts[0].Deatach(true);
            towerParts.RemoveAt(0);
            if (towerParts.Count > 0)
            {
                towerPartSpawner.SpawnTowerPart(towerParts[0]); 
            }
        }
    }
}
