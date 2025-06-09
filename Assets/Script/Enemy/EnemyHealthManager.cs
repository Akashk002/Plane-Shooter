using UnityEngine;

public class EnemyHealthManager : IEnemyHealth
{
    private int maxHealth;
    private int currentHealth;
    private GameObject enemyGameObject;
    private Transform enemyTransform;

    public EnemyHealthManager(GameObject gameObject, int maxHealth)
    {
        this.enemyGameObject = gameObject;
        this.enemyTransform = gameObject.transform;
        this.maxHealth = maxHealth;
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        ObjectPoolManager.This.GetPooledObject(ObjectName.PlaneDestroyEffect, enemyTransform.position);

        ObjectName drop = (Random.Range(0, 4) < 3) ? ObjectName.Coin : ObjectName.Health;
        ObjectPoolManager.This.GetPooledObject(drop, enemyTransform.position);

        enemyGameObject.SetActive(false);
        currentHealth = maxHealth;
    }
}
