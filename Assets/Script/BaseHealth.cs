using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseHealth : MonoBehaviour
{
    [SerializeField] protected int maxHealth = 100;
    protected int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public virtual void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }
    }

    public int GetHealth()
    {
        return currentHealth;
    }

    public virtual void Die()
    {

    }

}
