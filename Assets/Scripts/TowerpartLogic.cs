using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class TowerpartLogic : MonoBehaviour
{
    private Rigidbody rigidbody;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.useGravity = false;
    }

    public void Deatach(bool deatach)
    {
        rigidbody.useGravity = deatach;
        transform.parent = null;
    }
}
