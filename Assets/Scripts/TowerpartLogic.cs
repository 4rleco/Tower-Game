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

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            transform.parent = null;

            rigidbody.useGravity = true;

            enabled = false;
        }
    }
}
