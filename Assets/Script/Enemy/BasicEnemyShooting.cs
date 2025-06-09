using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyShooting : IEnemyShooting
{
    private MonoBehaviour monoBehaviour;
    private ObjectName bulletName;
    private List<GameObject> flashList;
    private List<Transform> spawnList;
    private float fireRate;
    private Coroutine shootRoutine;

    public BasicEnemyShooting(MonoBehaviour monoBehaviour, ObjectName objectName, List<GameObject> flashList, List<Transform> spawnList, float fireRate)
    {
        this.monoBehaviour = monoBehaviour;
        this.bulletName = objectName;
        this.flashList = flashList;
        this.spawnList = spawnList;
        this.fireRate = fireRate;

        Debug.Log("BasicEnemyShooting initialized with monoBehaviour: " + monoBehaviour + ", objectName: " + objectName + ", flashList: " + flashList.Count + ", spawnList: " + spawnList.Count + ", fireRate: " + fireRate);

        
    }

    public void HandleShooting()
    {
        // Automatic shooting; nothing to do in Update
        monoBehaviour.StartCoroutine(ShootContinuously());
    }

    private IEnumerator ShootContinuously()
    {
        Debug.Log("Starting shooting coroutine for ");

        while (true)
        {
            Debug.Log("Firing bullets0");

            Fire();

            Debug.Log("Firing bullets");

            foreach (var flash in flashList)
                flash.SetActive(true);

            yield return new WaitForSeconds(0.04f);

            foreach (var flash in flashList)
                flash.SetActive(false);

            yield return new WaitForSeconds(fireRate);
        }
    }

    private void Fire()
    {
        foreach (var spawnPoint in spawnList)
        {
            Debug.Log("spawnPoint - " + spawnPoint +","+ bulletName);
            ObjectPoolManager.This.GetPooledObject(bulletName, spawnPoint.position);
        }
    }
}
