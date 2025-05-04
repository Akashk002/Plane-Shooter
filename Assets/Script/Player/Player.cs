using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private IPlayerMovement movement;
    private IPlayerShooting shooting;
    private IPlayerHealth health;
    private IPlayerCollisionHandler collisionHandler;

    [SerializeField] private float speed = 5f;
    [SerializeField] private ObjectName bulletName;
    [SerializeField] private List<GameObject> flashList;
    [SerializeField] private List<Transform> spawnPoints;
    [SerializeField] private float fireRate;
    [SerializeField] private int maxHealth = 100;

    void Awake()
    {
        movement = new SimplePlayerMovement(transform, speed);
        shooting = new BasicPlayerShooting(this, bulletName, flashList, spawnPoints, fireRate);
        health = new PlayerHealthManager(maxHealth);
        collisionHandler = new PlayerCollisionHandler();
    }

    void Update()
    {
        movement.Move();
        shooting.HandleShooting();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        collisionHandler.HandleCollision(collision);
    }
}

