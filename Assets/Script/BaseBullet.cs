using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBullet : BaseMovement
{
    [SerializeField] int damageRate;
    [SerializeField] GameObject damageEffect;
  
    public  virtual void OnTriggerEnter2D(Collider2D collision)
    {
       
    }

    public int GetDamageRate()
    {
        return damageRate;
    }
}
