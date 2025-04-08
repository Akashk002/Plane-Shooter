using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasePlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private float moveX, moveY;
    private float minX, maxX, minY, maxY;

    void Start()
    {
        float halfWidth = GetComponent<SpriteRenderer>().bounds.extents.x;
        float halfHeight = GetComponent<SpriteRenderer>().bounds.extents.y;

        minX = Camera.main.ScreenToWorldPoint(Vector3.zero).x + halfWidth;
        maxX = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x - halfWidth;

        minY = Camera.main.ScreenToWorldPoint(Vector3.zero).y + halfHeight;
        maxY = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y - halfHeight;

        //pause movement after player died 
    }

    public virtual void Update()
    {
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");

        transform.position += new Vector3(moveX * speed * Time.deltaTime, moveY * speed * Time.deltaTime, 0);

        float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
        float clampedY = Mathf.Clamp(transform.position.y, minY, maxY - (maxY - minY) * 2 / 3);
        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }
}
