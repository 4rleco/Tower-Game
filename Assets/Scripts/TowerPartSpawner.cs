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

    private void Start()
    {
        lvlDataManager.OnReleased += OnReleased;
    }

    private void Update()
    {
        if (towerPart != null)
        {
            Movement();
        }
    }

    private void OnDestroy()
    {
        lvlDataManager.OnReleased -= OnReleased;
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

    private void OnReleased(bool released)
    {
        isReleased = released;

        if (isReleased)
            transform.position += new Vector3(0, towerPart.Height(), 0);
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
