using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class TowerpartLogic : MonoBehaviour
{
    [SerializeField] private Collider collider;
    [SerializeField] private AudioSource floorCollision;
    [SerializeField] private AudioSource partCollision;

    private Rigidbody rigidbody;

    private bool isSpawned = false;
    private bool isColliding = false;
    private bool onPerfect = false;
    private bool onFail = false;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.useGravity = false;

        floorCollision.Stop();
        partCollision.Stop();
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

    public bool GetOnPerfect()
    {
        return onPerfect;
    }

    public void Deatach(bool deatach)
    {
        collider.enabled = true;
        rigidbody.useGravity = deatach;
        transform.parent = null;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Vector3 newPos = new Vector3(collision.transform.position.x, transform.position.y, 0.0f);

        if (collision.gameObject.tag == "Floor")
        {
            tag = "Tower Top";
            floorCollision.Play();
        }
        else if (collision.gameObject.tag == "Tower Top")
        {
            tag = collision.gameObject.tag;
            collision.gameObject.tag = "Untagged";

            partCollision.Play();

            if (transform.position.x <= collision.transform.localScale.x / 2)
            {
                transform.position = newPos;
                onPerfect = true;
            }
        }
        else
        {
            onFail = true;
        }

        isColliding = true;
    }
}
