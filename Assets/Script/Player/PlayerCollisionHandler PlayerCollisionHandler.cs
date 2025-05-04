using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionHandler : IPlayerCollisionHandler
{
    public void HandleCollision(Collider2D collision)
    {
        if (collision.TryGetComponent(out EnemyBullet enemyBullet))
        {
            GameAction.OnPlayerDamage?.Invoke(enemyBullet.GetDamageRate());
        }
        else if (collision.TryGetComponent(out CoinMovement _))
        {
            GameAction.OnCollisionWithCoin?.Invoke();
            collision.gameObject.SetActive(false);
        }
        else if (collision.TryGetComponent(out HealthBoosterMovement _))
        {
            GameAction.OnCollisionWithHealthBonus?.Invoke();
            collision.gameObject.SetActive(false);
        }
    }
}

