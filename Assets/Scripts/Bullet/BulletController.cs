using UnityEngine;
using PlaneShooter.Bullets;
using PlaneShooter.Enemy;
using PlaneShooter.Player;

namespace PlaneShooter.Bullets
{
    public class BulletController : IBullet
    {
        private BulletView bulletView;
        private BulletScriptableObject bulletScriptableObject;

        public BulletController(BulletView bulletViewPrefab, BulletScriptableObject bulletScriptableObject)
        {
            bulletView = Object.Instantiate(bulletViewPrefab);
            bulletView.SetController(this);
            this.bulletScriptableObject = bulletScriptableObject;
        }

        public void ConfigureBullet(Transform spawnTransform)
        {
            bulletView.gameObject.SetActive(true);
            bulletView.transform.position = spawnTransform.position;
            bulletView.transform.rotation = spawnTransform.rotation;
        }

        public void UpdateBulletMotion()
        {
            Vector2 direction = (bulletScriptableObject.bulletType == BulletType.PlayerBullet) ? Vector2.up : Vector2.down;
            bulletView.transform.Translate(direction * Time.deltaTime * bulletScriptableObject.speed);
        }

        public void OnBulletEnteredTrigger(GameObject collidedGameObject)
        {
            if (bulletScriptableObject.bulletType == BulletType.PlayerBullet && collidedGameObject.GetComponent<EnemyView>() != null)
            {
                collidedGameObject.GetComponent<IDamageable>().TakeDamage(bulletScriptableObject.damage);
                bulletView.gameObject.SetActive(false);
                GameService.Instance.GetPlayerService().ReturnBulletToPool(this);
            }else 
            if (bulletScriptableObject.bulletType != BulletType.PlayerBullet && collidedGameObject.GetComponent<PlayerView>() != null)
            {
                collidedGameObject.GetComponent<IDamageable>().TakeDamage(bulletScriptableObject.damage);
                bulletView.gameObject.SetActive(false);
                GameService.Instance.GetEnemyService().ReturnBulletToPool(this);
            }
        }
    }
}