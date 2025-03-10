using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;
    public int health;
    public GameObject destroyEffect;

    void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Collider")
        {
            gameObject.SetActive(false);
        }
        else
        if (collision.gameObject.tag == "PlayerBullet")
        {
            damage(collision.gameObject.GetComponent<Bullet>().damageRate);
        }
    }

    void damage(int val)
    {
        if (health > 0)
        {
            health -= val;
        }
        else
        {
            ObjectPoolManager.This.GetPooledObject(ObjectName.PlaneDestroyEffect, transform.position);
            ObjectName objectName = (Random.Range(0, 4) < 3) ? ObjectName.Coin : ObjectName.Health;
            ObjectPoolManager.This.GetPooledObject(objectName, transform.position);
            gameObject.SetActive(false);
        }
    }
}
