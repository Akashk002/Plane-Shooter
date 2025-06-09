using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialPlayer : Player
{
    public override void Awake()
    {
        base.Awake();
        shooting = new AdvancePlayerShooting(this, bulletName, flashList, spawnPoints, fireRate);
    }
}

