using UnityEngine;

public class PlayerCollisionHandler : BaseCollisionHandler
{
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        // in place if tag we should use delegeate or other method  
        if (collision.GetComponent<EnemyBullet>())
        {
            int damage = collision.gameObject.GetComponent<EnemyBullet>().GetDamageRate();
            GameAction.OnPlayerDamage?.Invoke(damage);
        }
        else
        if (collision.GetComponent<CoinMovement>())
        {
            GameAction.OnCollisionWithCoin?.Invoke();
            collision.gameObject.SetActive(false);
        }
        else
        if (collision.GetComponent<HealthBoosterMovement>())
        {
            GameAction.OnCollisionWithHealthBonus?.Invoke();
            collision.gameObject.SetActive(false);
        }
    }
}
