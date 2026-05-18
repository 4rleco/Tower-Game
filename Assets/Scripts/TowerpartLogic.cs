using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class TowerpartLogic : MonoBehaviour
{
    [SerializeField] private Collider collider;
    private Rigidbody rigidbody;

    private bool isSpawned = false;
    private bool isColliding = false;

   private bool onFail = false;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.useGravity = false;
    }

    private void Start()
    {
        isSpawned = true;
    }

    public bool GetIsSpawned()
    {
        return isSpawned;
    }

    public bool GetIsColliding()
    {
        return isColliding;
    }

    public bool GetOnFail()
    {
        return onFail;
    }

    public void Deatach(bool deatach)
    {
        collider.enabled = true;
        rigidbody.useGravity = deatach;
        transform.parent = null;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Tower Top")
        {
            gameObject.tag = collision.gameObject.tag;
            collision.gameObject.tag = "Untagged";
        }
        else
        {
            onFail = true;
        }
        isColliding = true;
    }
}
