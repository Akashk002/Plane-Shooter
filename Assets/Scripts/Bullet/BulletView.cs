using UnityEngine;

namespace PlaneShooter.Bullets
{
    public class BulletView : MonoBehaviour
    {
        private BulletController bulletController;

        public void SetController(BulletController bulletController) => this.bulletController = bulletController;

        private void Update() => bulletController?.UpdateBulletMotion();

        private void OnTriggerEnter2D(Collider2D collision) => bulletController?.OnBulletEnteredTrigger(collision.gameObject);
    }
}