using System.Threading.Tasks;
using UnityEngine;
using PlaneShooter.Bullets;
using Unity.VisualScripting.Antlr3.Runtime.Collections;
using UnityEditor;
using static Unity.IO.LowLevel.Unsafe.AsyncReadManagerMetrics;
using System.Collections;

namespace PlaneShooter.Player
{
    public class PlayerController
    {
        // Dependencies
        private PlayerView playerView;
        private PlayerScriptableObject playerScriptableObject;
        private BulletPool bulletPool;


        // Variables
        private int currentHealth;
        private float currentRateOfFire;
        private ShootingState currentShootingState;

        public PlayerController(PlayerView playerViewPrefab, PlayerScriptableObject playerScriptableObject, BulletPool bulletPool)
        {
            playerView = Object.Instantiate(playerViewPrefab);
            playerView.SetController(this);
            this.playerScriptableObject = playerScriptableObject;
            this.bulletPool = bulletPool;
            InitializeVariables();
        }

        private void InitializeVariables()
        {
            currentHealth = playerScriptableObject.maxHealth;
        }

        public  void HandlePlayerMovement(float moveX,float moveY,float minX, float minY, float maxX, float maxY)
        {
            playerView.transform.position += new Vector3(moveX * playerScriptableObject.movementSpeed * Time.deltaTime, moveY * playerScriptableObject.movementSpeed * Time.deltaTime, 0);

            float clampedX = Mathf.Clamp(playerView.transform.position.x, minX, maxX);
            float clampedY = Mathf.Clamp(playerView.transform.position.y, minY, maxY - (maxY - minY) * 2 / 3);
            playerView.transform.position = new Vector3(clampedX, clampedY, playerView.transform.position.z);
        }
        public void FireBulletAtPosition(Transform fireLocation)
        {
            BulletController bulletToFire = bulletPool.GetBullet();
            bulletToFire.ConfigureBullet(fireLocation);
        }

        public void TakeDamage(int damageToTake)
        {
            currentHealth -= damageToTake;
            if (currentHealth <= 0)
                PlayerDeath();
        }

        private void PlayerDeath()
        {
            Object.Destroy(playerView.gameObject);
        }

        public PlayerScriptableObject GetPlayerScriptableObject() => playerScriptableObject;

        public Vector3 GetPlayerPosition() => playerView != null ? playerView.transform.position : default;

        public enum ShootingState
        {
            Firing,
            NotFiring
        }
    }
}