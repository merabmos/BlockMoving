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

    private SavingSpawnedObjects savingSpawnedObjects;
    private bool grounded = false;
    private bool fixedBlock = false;
    // Start is called before the fwdirst frame update
    void Start()
    {
        savingSpawnedObjects = new SavingSpawnedObjects();
    }

    // Update is called once per frame
    void Update()
    {
        if (!fixedBlock)
        {
            if (Input.GetKey(KeyCode.D))
                transform.position += (Vector3.right * speed) * Time.deltaTime;

            if (Input.GetKey(KeyCode.A))
                transform.position += (Vector3.left * speed) * Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.W) && grounded)
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

    private void OnMouseDown()
    {
        savingSpawnedObjects.RemoveAliveBlock(this);
    }

    public MainBlockScript SetFixed(bool isFixed)
    {
        fixedBlock = isFixed;
        return this;

    }

    public MainBlockScript SetGrounded(bool isGrounded)
    {
        grounded = isGrounded;
        return this;
    }

    public Tuple<float,float> GetSizeXandY()
    {
        return Tuple.Create<float,float>(boxCollider2D.size.x,boxCollider2D.size.y);
    }

    public MainBlockScript ChangeRigidBodyConstraints(RigidbodyConstraints2D constraints2D)
    {
        blockRigidBody.constraints = constraints2D;
        return this;
    }

}