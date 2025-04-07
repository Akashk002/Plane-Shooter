using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int bonusHealth = 50;
    private int currentHealth;
    public Slider healthSlider;

    private void Start()
    {
        currentHealth = maxHealth;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
    }

    // pri
    public void UpdateHealth(int value)
    {
        if (currentHealth > 0)
        {
            currentHealth += value;
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
            healthSlider.value = currentHealth;
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        ObjectPoolManager.This.GetPooledObject(ObjectName.PlaneDestroyEffect, transform.position);
        gameObject.SetActive(false);
    }
}
