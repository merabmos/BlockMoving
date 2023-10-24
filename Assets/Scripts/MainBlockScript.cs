using Assets.Scripts.Models;
using Assets.Scripts.Services;
using Assets.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class MainBlockScript : MonoBehaviour
{
    [SerializeField] private Rigidbody2D blockRigidBody;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private BoxCollider2D boxCollider2D;
    [SerializeField] private float flapStrength;
    [SerializeField] private float speed;

    private SavingSpawnedObjectsService _savingSpawnedObjects;
    private bool _grounded = false;
    private bool _fixedBlock = false;
    // Start is called before the fwdirst frame update
    void Start()
    {
        _savingSpawnedObjects = new SavingSpawnedObjectsService();
    }


    // Update is called once per frame
    void Update()
    {
        if (!_fixedBlock)
        {
            if (Input.GetKey(KeyCode.D))
                transform.position += (Vector3.right * speed) * Time.deltaTime;

            if (Input.GetKey(KeyCode.A))
                transform.position += (Vector3.left * speed) * Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.W) && _grounded)
                blockRigidBody.velocity = Vector2.up * flapStrength;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                SetFixed(true);
                ChangeRigidBodyConstraints(RigidbodyConstraints2D.FreezePosition | RigidbodyConstraints2D.FreezeRotation);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.ObjectHasTag("Wall")/* && !collision.gameObject.ObjectHasTag("Player")*/)
            SetGrounded(true);
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        if (!collision.gameObject.ObjectHasTag("Wall") /*&& !collision.gameObject.ObjectHasTag("Player")*/)
            SetGrounded(false);
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (!collision.gameObject.ObjectHasTag("Wall") && !_grounded /*&& !collision.gameObject.ObjectHasTag("Player")*/)
            SetGrounded(true);
    }

    private void OnMouseDown()
    {
        _savingSpawnedObjects.RemoveAliveBlock(this);
    }

    public MainBlockScript SetFixed(bool isFixed)
    {
        _fixedBlock = isFixed;
        return this;

    }

    public MainBlockScript SetGrounded(bool isGrounded)
    {
        _grounded = isGrounded;
        return this;
    }

    public BlockSize GetBlockSize()
    {
        return new BlockSize(boxCollider2D);
    }

    public MainBlockScript ChangeRigidBodyConstraints(RigidbodyConstraints2D constraints2D)
    {
        blockRigidBody.constraints = constraints2D;
        return this;
    }

}
