using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class TowerpartLogic : MonoBehaviour
{
    [SerializeField] private Collider collider;
    [SerializeField] private AudioSource floorCollision;
    [SerializeField] private AudioSource partCollision;

    private LvlDataManager lvlDataManager;

    private Rigidbody rigidbody;
    private MeshRenderer meshRenderer;

    private float height;

    private bool isSpawned = false;
    private bool isColliding = false;
    private bool onPerfect = false;
    private bool onFail = false;

    private void Awake()
    {
        lvlDataManager = FindFirstObjectByType<LvlDataManager>();

        rigidbody = GetComponent<Rigidbody>();
        rigidbody.useGravity = false;

        meshRenderer = GetComponentInChildren<MeshRenderer>();

        floorCollision.Stop();
        partCollision.Stop();

        height = 1;
    }

    private void Start()
    {
        isSpawned = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isColliding)
            return;

        isColliding = true;

        Vector3 newPos = new Vector3(collision.transform.position.x, transform.position.y, 0f);

        if (lvlDataManager.TopPart == null)
        {
            if (!collision.gameObject.CompareTag("Floor"))
            {
                onFail = true;
                return;
            }

            floorCollision.Play();
            return;
        }

        if (collision.gameObject == lvlDataManager.TopPart.gameObject)
        {
            partCollision.Play();

            if (Mathf.Abs(transform.position.x - collision.transform.position.x) <= collision.transform.localScale.x / 2f)
            {
                transform.position = newPos;
                onPerfect = true;
            }

            return;
        }

        onFail = true;
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

    public float Height()
    {
        return height;
    }
}
