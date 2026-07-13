using UnityEngine;

public class TowerPartSpawner : MonoBehaviour
{
    [SerializeField] private GameObject floor;
    [SerializeField] private LvlDataManager lvlDataManager;

    [SerializeField] private float speed;
    [SerializeField] private float upSpeed = 2;

    private TowerpartLogic towerPart;

    private float maxPosX;
    private float minPosX;

    private bool reachedMax = false;
    private bool isReleased = false;

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
        towerPart.gameObject.GetComponent<Collider>().enabled = false;
        towerPart.gameObject.SetActive(true);
    }

    private void Movement()
    {
        maxPosX = floor.transform.localScale.x / 2 - towerPart.transform.localScale.x;
        minPosX = -maxPosX;

        if (transform.position.x <= maxPosX && !reachedMax)
            transform.position += Vector3.right * speed * Time.deltaTime;


        if (transform.position.x >= minPosX && reachedMax)
            transform.position += Vector3.left * speed * Time.deltaTime;


        if (transform.position.x >= maxPosX)
            reachedMax = true;


        if (transform.position.x <= minPosX)
            reachedMax = false;
    }

    public void OnReleased(TowerpartLogic topPart, bool released)
    {
        if (!released)        
            return;        

        isReleased = true;

        Vector3 pos = transform.position;

        if (topPart != null)
        {
            float topHeight = topPart.GetComponent<Collider>().bounds.max.y;
            pos.y = topHeight + towerPart.GetComponent<Collider>().bounds.size.y / 2f;
        }
        else
        {
            float floorHeight = floor.GetComponent<Collider>().bounds.max.y;
            pos.y = floorHeight + towerPart.GetComponent<Collider>().bounds.size.y / 2f;
        }

        transform.position = pos;
    }

    public TowerpartLogic GetTowerpart()
    {
        if (towerPart.gameObject.active)
            return towerPart;
        else
            return null;
    }

    public bool GetIsReleased()
    {
        return isReleased;
    }
}
