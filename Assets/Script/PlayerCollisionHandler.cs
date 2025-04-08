using UnityEngine;

public class PlayerCollisionHandler : BaseCollisionHandler
{
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        // in place if tag we should use delegeate or other method  
        if (collision.GetComponent<EnemyBullet>())
        {
            int damage = collision.gameObject.GetComponent<EnemyBullet>().GetDamageRate();
            UIAction.OnPlayerDamage?.Invoke(damage);
        }
        else
        if (collision.GetComponent<CoinMovement>())
        {
            UIAction.OnCollisionWithCoin?.Invoke();
        }
        else
        if (collision.GetComponent<HealthBoosterMovement>())
        {
            UIAction.OnCollisionWithHealthBonus?.Invoke();
        }

    }
}
