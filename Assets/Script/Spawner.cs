using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public void SpawnEnemyAtRandomPos(ObjectName objectname , bool lastEnemy)
    {
        int randomVal = Random.Range(-2, 3);
        Vector2 spawnPos = new Vector2(transform.position.x + randomVal, transform.position.y);
        
       GameObject enemy =  ObjectPoolManager.This.GetPooledObject(objectname, spawnPos);

        if(lastEnemy) enemy.GetComponent<EnemyHealth>().SetLastEnemy();
    }
}
