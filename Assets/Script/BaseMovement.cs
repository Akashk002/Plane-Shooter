using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMovement : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] Vector3 direction = Vector3.down; // Move to the right by default

    private void Update()
    {
        Move();
    }

    public virtual void Move()
    {
        transform.position += direction * speed * Time.deltaTime;
    }
}
