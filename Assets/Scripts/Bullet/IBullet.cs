using UnityEngine;

namespace PlaneShooter.Bullets
{
    public interface IBullet
    {
        public void UpdateBulletMotion();

        public void OnBulletEnteredTrigger(GameObject collidedObject);
    }
}