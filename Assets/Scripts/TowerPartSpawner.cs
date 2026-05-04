using UnityEngine;
using System.Collections.Generic;

public class TowerPartSpawner : MonoBehaviour
{
    [SerializeField] private TowerpartLogic towerPartPrefab;
    [SerializeField] private GameObject floor;

    [SerializeField] private float speed;

    private List<TowerpartLogic> towerParts;

    private float maxPosX;
    private float minPosX;

    private bool reachedMax = false;

    private void Start()
    {
        TowerpartLogic towerPart = Instantiate(towerPartPrefab, transform.position, Quaternion.identity, transform);
        towerParts.Add(towerPart);
    }

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        maxPosX = floor.transform.localScale.x / 2 - towerPartPrefab.transform.localScale.x;
        minPosX = -1 * (maxPosX = floor.transform.localScale.x / 2 - towerPartPrefab.transform.localScale.x);

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
