using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Objectname objectname;
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
        if (objectname == Objectname.PlayerBullet && Input.GetKey(KeyCode.RightShift) && shoot)
        {
            StartCoroutine(ShootContinuously());
        }
    }

    void OnEnable()
    {
        if (objectname != Objectname.PlayerBullet)
        {
            StartCoroutine(ShootContinuously());
        }
    }


    IEnumerator ShootContinuously()
    {
        if (shoot)
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

        }

        yield return new WaitForSeconds(fireRate); // Wait for the next shot
        shoot = true;
        StartCoroutine(ShootContinuously());
    }

    private void Fire()
    {
        foreach (var spawnpoint in spawnList)
        {
            ObjectPoolManager.This.GetPooledObject(objectname.ToString(), spawnpoint.transform.position);
        }
    }
}
