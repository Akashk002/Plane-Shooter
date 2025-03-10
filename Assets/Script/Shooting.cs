using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public ObjectName objectname;
    public List<GameObject> flashList = new List<GameObject>();
    public List<Transform> spawnList = new List<Transform>();
    public float fireRate; // Delay between shots
    private bool shoot = true;

    // Start is called before the first frame update
    void Start()
    {
        // StartCoroutine(ShootContinuously());
    }

    private void Update()
    {
        if (objectname == ObjectName.PlayerBullet)
        {
            if (Input.GetButton("Fire1") && shoot)
            {
                StartCoroutine(ShootContinuously());
            }
            else
            {
                StopCoroutine(ShootContinuously());
            }
        }
    }

    void OnEnable()
    {
        if (objectname != ObjectName.PlayerBullet)
        {
            StartCoroutine(ShootContinuously());
        }
    }


    IEnumerator ShootContinuously()
    {
        shoot = false;
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
        shoot = true;

        if (objectname != ObjectName.PlayerBullet)
        {
            StartCoroutine(ShootContinuously());
        }
    }

    private void Fire()
    {
        foreach (var spawnpoint in spawnList)
        {
            ObjectPoolManager.This.GetPooledObject(objectname, spawnpoint.transform.position);
        }
    }
}
