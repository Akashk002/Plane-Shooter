using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableItself : MonoBehaviour
{
    public float DisableTime;
    private void OnEnable()
    {
        Invoke("Disable", DisableTime);
    }

    void Disable()
    {
        gameObject.SetActive(false);
    }
}
