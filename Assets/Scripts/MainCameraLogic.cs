using UnityEngine;

public class MainCameraLogic : MonoBehaviour
{
    [SerializeField] private TowerPartSpawner spawner;

    private void Update()
    {
        if (spawner.GetIsReleased())
        {                                  // la altura de los cubos
            transform.position += new Vector3(0.0f, 2.0f, 0.0f) * Time.deltaTime;
        }
    }
}
