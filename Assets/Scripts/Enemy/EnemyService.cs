using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlaneShooter.Bullets;
using PlaneShooter.Enemy;

namespace PlaneShooter.Player
{
    public class EnemyService
    {
        private BulletPool bulletPool;
        private EnemyController enemyController;

        public EnemyService(EnemyView enemyViewPrefab, EnemyScriptableObject enemyScriptableObject, BulletView bulletPrefab, BulletScriptableObject bulletScriptableObject)
        {
            bulletPool = new BulletPool(bulletPrefab, bulletScriptableObject);
            enemyController = new EnemyController(enemyViewPrefab, enemyScriptableObject, bulletPool);
            enemyController.Configure(enemyViewPrefab.transform.position);
        }

        public EnemyController GetEnemyController() => enemyController;

        public void ReturnBulletToPool(BulletController bulletToReturn) => bulletPool.ReturnBullet(bulletToReturn);
    }
}