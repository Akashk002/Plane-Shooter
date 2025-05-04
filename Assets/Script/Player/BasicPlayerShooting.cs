using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPlayerShooting : IPlayerShooting
{
    private ObjectName bulletName;
    private List<GameObject> flashList;
    private List<Transform> spawnPoints;
    private float fireRate;
    private MonoBehaviour mono;
    private Coroutine shootingCoroutine;

    public BasicPlayerShooting(MonoBehaviour mono, ObjectName bulletName, List<GameObject> flashList, List<Transform> spawnPoints, float fireRate)
    {
        this.mono = mono;
        this.bulletName = bulletName;
        this.flashList = flashList;
        this.spawnPoints = spawnPoints;
        this.fireRate = fireRate;
    }

    public void HandleShooting()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            shootingCoroutine = mono.StartCoroutine(ShootContinuously());
        }
        else if (Input.GetButtonUp("Fire1"))
        {
            if (shootingCoroutine != null)
                mono.StopCoroutine(shootingCoroutine);
        }
    }

    private IEnumerator ShootContinuously()
    {
        while (true)
        {
            Fire();

            foreach (var flash in flashList) flash.SetActive(true);
            yield return new WaitForSeconds(0.04f);
            foreach (var flash in flashList) flash.SetActive(false);

            yield return new WaitForSeconds(fireRate);
        }
    }

    private void Fire()
    {
        foreach (var spawn in spawnPoints)
        {
            ObjectPoolManager.This.GetPooledObject(bulletName, spawn.position);
        }
    }
}
