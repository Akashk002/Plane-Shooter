using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : BaseHealth
{
    [SerializeField] private int bonusHealth = 50;

    private void OnEnable()
    {
        GameAction.OnPlayerDamage += TakeDamage;
        GameAction.OnCollisionWithHealthBonus += BonusHealth;
    }

    private void OnDisable()
    {
        GameAction.OnPlayerDamage -= TakeDamage;
        GameAction.OnCollisionWithHealthBonus -= BonusHealth;
    }
    public override void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }

        GameAction.OnUpdatePlayerHealthSlider?.Invoke(currentHealth);
    }

    public override void Die()
    {
        ObjectPoolManager.This.GetPooledObject(ObjectName.PlaneDestroyEffect, transform.position);
        gameObject.SetActive(false);
        GameAction.OnPlayerDie?.Invoke();
    }

    void BonusHealth()
    {
        currentHealth += bonusHealth;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        GameAction.OnUpdatePlayerHealthSlider(currentHealth);
    }
}
