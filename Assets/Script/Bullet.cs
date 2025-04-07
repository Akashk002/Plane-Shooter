using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed;
    public int damageRate;
    public GameObject damageEffect;
    public Vector3 direction = Vector3.right; // Move to the right by default

    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision);

        if (collision.gameObject.tag == "Collider")
        {
            gameObject.SetActive(false);
        }
        else
        if (tag == "PlayerBullet" && collision.GetComponent<EnemyMovement>())
        {
            ObjectPoolManager.This.GetPooledObject(ObjectName.BulletDestroyEffect, transform.position);
            gameObject.SetActive(false);
        }
        else
        if (tag == "EnemyBullet" && collision.GetComponent<PlayerMovement>())
        {
            ObjectPoolManager.This.GetPooledObject(ObjectName.BulletDestroyEffect, transform.position);
            gameObject.SetActive(false);
        }
    }
}
