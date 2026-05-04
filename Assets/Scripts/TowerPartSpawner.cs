using UnityEngine;
using System.Collections.Generic;

public class TowerPartSpawner : MonoBehaviour
{
    [SerializeField] private GameObject floor;

    [SerializeField] private float speed;

    private TowerpartLogic towerPart;

    private float maxPosX;
    private float minPosX;

    private bool reachedMax = false;

    private void Update()
    {
        if (towerPart != null)
        {
            Movement(); 
        }
    }

    public void SpawnTowerPart(TowerpartLogic instantiatedTowerPart)
    {
        towerPart = instantiatedTowerPart;
        towerPart.gameObject.SetActive(true);
    }
    
    private void Movement()
    {
        maxPosX = floor.transform.localScale.x / 2 - towerPart.transform.localScale.x;
        minPosX = -1 * (maxPosX = floor.transform.localScale.x / 2 - towerPart.transform.localScale.x);

        if (transform.position.x <= maxPosX && !reachedMax)
            transform.position += Vector3.right * speed * Time.deltaTime;


        if (transform.position.x >= minPosX && reachedMax)
            transform.position += Vector3.left * speed * Time.deltaTime;


        if (transform.position.x >= maxPosX)
            reachedMax = true;


        if (transform.position.x <= minPosX)
            reachedMax = false;
    }
}
