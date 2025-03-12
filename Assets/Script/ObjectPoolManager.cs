using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
    public static ObjectPoolManager This;
    [SerializeField] List<Pool> pools;
    private Dictionary<string, Queue<GameObject>> poolDictionary;
    private Dictionary<string, Transform> poolParents; // Parent holders for organization

    void Start()
    {
        This = this;
        poolDictionary = new Dictionary<string, Queue<GameObject>>();
        poolParents = new Dictionary<string, Transform>();

        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            // Create a parent GameObject for organization
            GameObject parentObject = new GameObject(pool.objectname + " Pool");
            parentObject.transform.SetParent(transform);
            poolParents[pool.objectname.ToString()] = parentObject.transform;

            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                obj.transform.SetParent(parentObject.transform); // Assign to the folder
                objectPool.Enqueue(obj);
            }

            Debug.Log("key1 - " + pool.objectname);
            poolDictionary.Add(pool.objectname.ToString(), objectPool);
        }
    }

    // Function to get an object from the pool
    public GameObject GetPooledObject(ObjectName objectname, Vector3 position)
    {
        Debug.Log("key2 - " + objectname);
        if (!poolDictionary.ContainsKey(objectname.ToString()))
        {
            Debug.LogWarning("Pool with tag " + objectname + " doesn't exist.");
            return null;
        }

        GameObject obj = poolDictionary[objectname.ToString()].Dequeue();

        if (obj.activeInHierarchy)
        {
            // If all objects are in use, create a new one (optional)
            obj = Instantiate(poolDictionary[objectname.ToString()].Peek());
        }

        obj.SetActive(true);
        obj.transform.position = position;

        poolDictionary[objectname.ToString()].Enqueue(obj);
        return obj;
    }
}
[System.Serializable]
public class Pool
{
    public ObjectName objectname;
    public GameObject prefab;
    public int size;
}

[System.Serializable]
public enum ObjectName
{
    PlayerBullet,
    Coin,
    Health,
    EnemyBullet1,
    EnemyBullet2,
    EnemyBullet3,
    EnemyBullet4,
    EnemyBullet5,
    Aircraft1,
    Aircraft2,
    Aircraft3,
    Aircraft4,
    Chopper,
    Chopper2,
    PlaneDestroyEffect,
    BulletDestroyEffect,

}