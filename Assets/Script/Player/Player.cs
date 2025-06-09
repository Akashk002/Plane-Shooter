using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    protected IPlayerMovement movement;
    protected IPlayerShooting shooting;
    protected IPlayerHealth health;
    protected IPlayerCollisionHandler collisionHandler;

    [SerializeField] protected float speed = 5f;
    [SerializeField] protected ObjectName bulletName;
    [SerializeField] protected List<GameObject> flashList;
    [SerializeField] protected List<Transform> spawnPoints;
    [SerializeField] protected float fireRate;
    [SerializeField] protected int maxHealth = 100;

    public virtual void Awake()
    {
        movement = new SimplePlayerMovement(transform, speed);
        shooting = new BasicPlayerShooting(this, bulletName, flashList, spawnPoints, fireRate);
        health = new PlayerHealthManager(maxHealth);
        collisionHandler = new PlayerCollisionHandler();
    }

    public virtual void Update()
    {
        movement.Move();
        shooting.HandleShooting();
    }

    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        collisionHandler.HandleCollision(collision);
    }
}

