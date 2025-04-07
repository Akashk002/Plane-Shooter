using UnityEngine;

[RequireComponent(typeof(PlayerHealth))]
public class PlayerCollisionHandler : MonoBehaviour
{
    private PlayerHealth playerHealth;

    void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // in place if tag we should use delegeate or other method  
        switch (collision.gameObject.tag)
        {
            case "EnemyBullet":
                playerHealth.UpdateHealth(-collision.gameObject.GetComponent<Bullet>().damageRate);
                break;

            case "Coin":
                GameManager.This.AddCoin();
                break;

            case "Health":
                playerHealth.UpdateHealth(50);
                break;
        }
    }
}
