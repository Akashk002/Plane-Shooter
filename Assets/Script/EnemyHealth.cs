using UnityEngine;

public class EnemyHealth : BaseHealth
{
    bool lastEnemy = false;

    private void OnEnable()
    {
        GameAction.OnEnemyDamage += TakeDamage;
    }

    private void OnDisable()
    {
        GameAction.OnEnemyDamage -= TakeDamage;
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
    }

    public override void Die()
    {
        ObjectPoolManager.This.GetPooledObject(ObjectName.PlaneDestroyEffect, transform.position);
        ObjectName objectName = (Random.Range(0, 4) < 3) ? ObjectName.Coin : ObjectName.Health;
        ObjectPoolManager.This.GetPooledObject(objectName, transform.position);

        gameObject.SetActive(false);
        ResetHealth();

        if (lastEnemy)
        {
            GameAction.OnGameComplete?.Invoke();
        }
    }

    private void ResetHealth()
    {
        currentHealth = maxHealth;
    }

    public void SetLastEnemy()
    {
        lastEnemy = true;
    }
}
