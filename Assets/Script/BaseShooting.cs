using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseShooting : MonoBehaviour
{
    [SerializeField] protected ObjectName objectname;
    [SerializeField] protected List<GameObject> flashList = new List<GameObject>();
    [SerializeField] List<Transform> spawnList = new List<Transform>();
    [SerializeField] protected float fireRate; // Delay between shots

    public virtual void Update()
    {
        
    }

    public virtual void  OnEnable()
    {

    }

    protected virtual IEnumerator ShootContinuously()
    {
        Fire();

        foreach (var flash in flashList)
        {
            flash.SetActive(true);
        }
        yield return new WaitForSeconds(0.04f);
        foreach (var flash in flashList)
        {
            flash.SetActive(false);
        }

        yield return new WaitForSeconds(fireRate); // Wait for the next shot

        StartCoroutine(ShootContinuously());
    }

    protected void Fire()
    {
        foreach (var spawnpoint in spawnList)
        {
            ObjectPoolManager.This.GetPooledObject(objectname, spawnpoint.transform.position);
        }
    }
}
