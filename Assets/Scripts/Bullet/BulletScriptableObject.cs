using UnityEngine;

namespace PlaneShooter.Bullets
{
    [CreateAssetMenu(fileName = "BulletScriptableObject", menuName = "ScriptableObjects/BulletSO")]
    public class BulletScriptableObject : ScriptableObject
    {
        public BulletType bulletType;
        public float speed;
        public int damage;
    }
}
[System.Serializable]
public enum BulletType
{
    PlayerBullet,
    EnemyBullet1,
    EnemyBullet2,
    EnemyBullet3,
    EnemyBullet4,
    EnemyBullet5,
}