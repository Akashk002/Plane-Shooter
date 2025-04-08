using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : BaseHealth
{
    [SerializeField] private int bonusHealth = 50;

    private void OnEnable()
    {
        UIAction.OnPlayerDamage += TakeDamage;
        UIAction.OnCollisionWithHealthBonus += BonusHealth;
    }

    private void OnDisable()
    {
        UIAction.OnPlayerDamage -= TakeDamage;
        UIAction.OnCollisionWithHealthBonus -= BonusHealth;
    }

    public override void Die()
    {
        ObjectPoolManager.This.GetPooledObject(ObjectName.PlaneDestroyEffect, transform.position);
        gameObject.SetActive(false);
    }

    void BonusHealth()
    {
        currentHealth += bonusHealth;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
    }
}
