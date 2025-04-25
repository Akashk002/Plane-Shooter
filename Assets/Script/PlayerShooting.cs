using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Collections;
using UnityEditor;
using UnityEngine;

public class PlayerShooting : BaseShooting
{
    protected bool shoot = true;
    // Start is called before the first frame update
    private void Update()
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

    protected override IEnumerator ShootContinuously()
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
    }
}
