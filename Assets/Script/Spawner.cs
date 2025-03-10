using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public void SpawnEnemyAtRandomPos(ObjectName objectname)
    {
        int randomVal = Random.Range(-2, 3);
        Vector2 spawnPos = new Vector2(transform.position.x + randomVal, transform.position.y);
        ObjectPoolManager.This.GetPooledObject(objectname, spawnPos);
    }
}
