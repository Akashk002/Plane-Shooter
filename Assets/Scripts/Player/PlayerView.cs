using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Collections;
using UnityEngine;

namespace PlaneShooter.Player
{
    public class PlayerView : MonoBehaviour, IDamageable
    {
        [SerializeField] public List<Transform> firePoints;
        [SerializeField] public List<GameObject> flashEffect;

        private PlayerController playerController;

        //Player Movement varibles
        [HideInInspector] public float moveX, moveY;
        [HideInInspector] public float minX, maxX, minY, maxY;
         private bool canShoot = true;

        private void Start()
        {
            float halfWidth = GetComponent<SpriteRenderer>().bounds.extents.x;
            float halfHeight = GetComponent<SpriteRenderer>().bounds.extents.y;

            minX = Camera.main.ScreenToWorldPoint(Vector3.zero).x + halfWidth;
            maxX = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x - halfWidth;

            minY = Camera.main.ScreenToWorldPoint(Vector3.zero).y + halfHeight;
            maxY = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y - halfHeight;
        }

        public void SetController(PlayerController playerController) => this.playerController = playerController;

        private void Update()
        {
            PlayerMovenemt();
            HandleShooting();
        }

        void  HandleShooting()
        {
            if(Input.GetKey(KeyCode.Space) && canShoot)
                StartCoroutine(FireWeaponCoroutine());
        } 

        void PlayerMovenemt()
        {
            moveX = Input.GetAxis("Horizontal");
            moveY = Input.GetAxis("Vertical");
            playerController.HandlePlayerMovement(moveX,moveY,minX,minY,maxX,maxY);

        }

        IEnumerator FireWeaponCoroutine()
        {
            canShoot = false;
            foreach (var firePoint in firePoints)
            {
                playerController.FireBulletAtPosition(firePoint);
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
            yield return new WaitForSeconds(playerController.GetPlayerScriptableObject().fireRate); // Wait for the next shot
            canShoot = true;
        }

        public void TakeDamage(int damageToTake) => playerController.TakeDamage(damageToTake);
    }
}