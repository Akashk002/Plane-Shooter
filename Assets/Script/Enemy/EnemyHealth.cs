using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    private int currentHealth;

    private void Start()
    {
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
