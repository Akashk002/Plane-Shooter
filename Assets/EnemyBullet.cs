using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : BaseBullet
{
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Collider")
        {
            gameObject.SetActive(false);
        }
        else
        if (collision.GetComponent<BasePlayerMovement>())
        {
            ObjectPoolManager.This.GetPooledObject(ObjectName.BulletDestroyEffect, transform.position);
            gameObject.SetActive(false);
        }
    }
}
