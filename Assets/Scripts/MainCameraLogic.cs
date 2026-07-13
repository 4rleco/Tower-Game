using UnityEngine;

public class MainCameraLogic : MonoBehaviour
{
    [SerializeField] private TowerPartSpawner spawner;

    private void Update()
    {
        if (spawner.GetIsReleased())
        {                                  
            transform.position += new Vector3(0.0f, spawner.GetTowerpart().Height(), 0.0f) * Time.deltaTime;
        }
    }
}
