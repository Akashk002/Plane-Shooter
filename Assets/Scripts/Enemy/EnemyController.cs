using UnityEngine;
using PlaneShooter.Player;
using PlaneShooter.Bullets;

namespace PlaneShooter.Enemy
{
    public class EnemyController
    {
        // Dependencies:
        private EnemyView enemyView;
        private EnemyScriptableObject enemyScriptableObject;
        private BulletPool bulletPool;

        // Variables:
        private int currentHealth;
        private float speed;
        private float movementTimer;
        private Quaternion targetRotation;

        public EnemyController(EnemyView enemyPrefab, EnemyScriptableObject enemyScriptableObject , BulletPool bulletPool)
        {
            enemyView = Object.Instantiate(enemyPrefab);
            enemyView.SetController(this);
            this.enemyScriptableObject = enemyScriptableObject;
            this.bulletPool = bulletPool;
        }

        public void Configure(Vector3 positionToSet)
        {
            enemyView.transform.position = positionToSet;
            currentHealth = enemyScriptableObject.maxHealth;
            speed = enemyScriptableObject.movementSpeed;
            enemyView.gameObject.SetActive(true);
        }

        public void TakeDamage(int damageToTake)
        {
            Debug.Log(currentHealth);
            currentHealth -= damageToTake;
            if (currentHealth <= 0)
                EnemyDestroyed();
        }

        public void UpdateMotion()
        {
            enemyView.transform.position += Vector3.down * enemyScriptableObject.movementSpeed * Time.deltaTime;
        }

        public void FireBulletAtPosition(Transform fireLocation)
        {
            BulletController bulletToFire = bulletPool.GetBullet();
            bulletToFire.ConfigureBullet(fireLocation);
        }

        public void OnEnemyCollided(GameObject collidedGameObject)
        {
            if (collidedGameObject.GetComponent<PlayerView>() != null)
            {
                GameService.Instance.GetPlayerService().GetPlayerController().TakeDamage(enemyScriptableObject.damageToInflict);
                EnemyDestroyed();
            }
        }

        public EnemyScriptableObject GetEnemyScriptableObject() => enemyScriptableObject;


        private void EnemyDestroyed()
        {
          enemyView.gameObject.SetActive(false);
        }
    }
}