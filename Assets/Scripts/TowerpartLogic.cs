using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class TowerpartLogic : MonoBehaviour
{
    [SerializeField] private Collider collider;
    private Rigidbody rigidbody;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.useGravity = false;
    }

    public void Deatach(bool deatach)
    {
        collider.enabled = true;
        rigidbody.useGravity = deatach;
        transform.parent = null;
    }
}
