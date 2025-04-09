using UnityEngine;

public class EnemyCollisionHandler : BaseCollisionHandler
{
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Collider")
        { 
            gameObject.SetActive(false);
        }
        else if (collision.GetComponent<PlayerBullet>())
        { 
            int damage = collision.gameObject.GetComponent<PlayerBullet>().GetDamageRate();
            GameAction.OnEnemyDamage?.Invoke(damage);
        }
    } 
} 


