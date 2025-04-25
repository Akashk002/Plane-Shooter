using PlaneShooter.Bullets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerScriptableObject", menuName = "ScriptableObjects/EnemySO")]
public class EnemyScriptableObject : ScriptableObject
{
    public BulletType bulletType;
    public int maxHealth;
    public float movementSpeed;
    public float fireRate;
    public int damageToInflict;
}
