using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : BaseShooting
{
    public override void OnEnable()
    {
        StartCoroutine(ShootContinuously());
    }
}
