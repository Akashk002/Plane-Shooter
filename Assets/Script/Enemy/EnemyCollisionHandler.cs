using UnityEngine;

[RequireComponent(typeof(EnemyHealth))]
public class EnemyCollisionHandler : MonoBehaviour
{
    private EnemyHealth enemyHealth;

    private void Start()
    {
        enemyHealth = GetComponent<EnemyHealth>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Collider":
                gameObject.SetActive(false);
                break;

            case "PlayerBullet":
                int damage = collision.gameObject.GetComponent<Bullet>().damageRate;
                enemyHealth.TakeDamage(damage);
                break;
        }
    }
}
