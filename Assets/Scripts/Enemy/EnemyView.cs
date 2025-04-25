using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlaneShooter.Enemy
{
    public class EnemyView : MonoBehaviour, IDamageable
    {
        [SerializeField] public List<Transform> firePoints;
        [SerializeField] public List<GameObject> flashEffect;
        private EnemyController enemyController;

        public void SetController(EnemyController enemyController) => this.enemyController = enemyController;

        private void Start()
        {
            StartCoroutine(FireWeaponCoroutine());
        }
        private void Update() => enemyController.UpdateMotion();

        private void OnTriggerEnter2D(Collider2D collision) => enemyController?.OnEnemyCollided(collision.gameObject);

        public void TakeDamage(int damageToTake) => enemyController.TakeDamage(damageToTake);

        IEnumerator FireWeaponCoroutine()
        {
            foreach (var firePoint in firePoints)
            {
                Debug.Log("Fire");
                enemyController.FireBulletAtPosition(firePoint);
            }

            foreach (var flash in flashEffect)
            {
                flash.SetActive(true);
            }
            yield return new WaitForSeconds(0.04f);
            foreach (var flash in flashEffect)
            {
                flash.SetActive(false);
            }
            yield return new WaitForSeconds(enemyController.GetEnemyScriptableObject().fireRate); // Wait for the next shot

            StartCoroutine(FireWeaponCoroutine());
        }
    }
}