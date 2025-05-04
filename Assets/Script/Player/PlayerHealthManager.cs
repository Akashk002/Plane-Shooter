using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : IPlayerHealth
{
    private int maxHealth;
    private int currentHealth;

    public PlayerHealthManager(int maxHealth)
    {
        this.maxHealth = maxHealth;
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Max(currentHealth, 0);
        GameAction.OnUpdatePlayerHealthSlider?.Invoke(currentHealth);

        if (currentHealth <= 0)
            Die();
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        GameAction.OnUpdatePlayerHealthSlider?.Invoke(currentHealth);
    }

    private void Die()
    {
        GameAction.OnPlayerDie?.Invoke();
    }
}

