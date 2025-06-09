using UnityEngine;
using System.Collections.Generic;

public class Enemy : MonoBehaviour
{
    public IEnemyMovement Movement { get; private set; }
    public IEnemyShooting Shooting { get; private set; }
    public IEnemyHealth Health { get; private set; }
    public IEnemyCollisionHandler CollisionHandler { get; private set; }
    public EnemyStateMachine StateMachine { get; private set; }

    [SerializeField] private float speed = 2f;
    [SerializeField] private ObjectName bulletName;
    [SerializeField] private List<GameObject> flashList;
    [SerializeField] private List<Transform> spawnPoints;
    [SerializeField] private float fireRate = 1f;
    [SerializeField] private int maxHealth = 100;

    void Awake()
    {
        Movement = new SimpleEnemyMovement(transform, speed);
        Shooting = new BasicEnemyShooting(this, bulletName, flashList, spawnPoints, fireRate);
        Health = new EnemyHealthManager(gameObject, maxHealth);
        CollisionHandler = new EnemyCollisionHandler(gameObject, Health);

        StateMachine = new EnemyStateMachine();
    }

    void OnEnable()
    {
        StateMachine.ChangeState(new EnemyMoveState(this));
    }

    void Update()
    {
        StateMachine.Update();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        CollisionHandler.HandleCollision(collision);
    }

    public void Die()
    {
        // Your death effect, item spawn, deactivate, etc.
        ObjectPoolManager.This.GetPooledObject(ObjectName.PlaneDestroyEffect, transform.position);
        ObjectPoolManager.This.GetPooledObject(ObjectName.Coin, transform.position);
        gameObject.SetActive(false);
    }
}
