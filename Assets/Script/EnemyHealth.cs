using UnityEngine;

public class EnemyHealth : BaseHealth
{
    private void OnEnable()
    {
        UIAction.OnEnemyDamage += TakeDamage;
    }

    private void OnDisable()
    {
        UIAction.OnEnemyDamage -= TakeDamage;
    }


    public override void Die()
    {
        ObjectPoolManager.This.GetPooledObject(ObjectName.PlaneDestroyEffect, transform.position);
        ObjectName objectName = (Random.Range(0, 4) < 3) ? ObjectName.Coin : ObjectName.Health;
        ObjectPoolManager.This.GetPooledObject(objectName, transform.position);

        gameObject.SetActive(false);
        ResetHealth();
    }

    private void ResetHealth()
    {
        currentHealth = maxHealth;
    }
}
