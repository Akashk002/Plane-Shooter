using UnityEngine;

public class EnemyCollisionHandler : IEnemyCollisionHandler
{
    private IEnemyHealth health;
    private GameObject enemyGameObject;

    public EnemyCollisionHandler(GameObject gameObject, IEnemyHealth health)
    {
        this.enemyGameObject = gameObject;
        this.health = health;
    }

    public void HandleCollision(Collider2D collision)
    {
        if (collision.CompareTag("Collider"))
        {
            enemyGameObject.SetActive(false);
        }
        else if (collision.CompareTag("PlayerBullet"))
        {
            int damage = collision.GetComponent<Bullet>().damageRate;
            health.TakeDamage(damage);
        }
    }
}
