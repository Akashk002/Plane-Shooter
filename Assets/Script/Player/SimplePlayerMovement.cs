using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlayerMovement : IPlayerMovement
{
    private Transform playerTransform;
    private float speed;
    private float minX, maxX, minY, maxY;

    public SimplePlayerMovement(Transform transform, float speed)
    {
        playerTransform = transform;
        this.speed = speed;
        CalculateBounds();
    }

    private void CalculateBounds()
    {
        SpriteRenderer sr = playerTransform.GetComponent<SpriteRenderer>();
        float halfWidth = sr.bounds.extents.x;
        float halfHeight = sr.bounds.extents.y;

        minX = Camera.main.ScreenToWorldPoint(Vector3.zero).x + halfWidth;
        maxX = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x - halfWidth;
        minY = Camera.main.ScreenToWorldPoint(Vector3.zero).y + halfHeight;
        maxY = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y - halfHeight;
    }

    public void Move()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Vector3 newPos = playerTransform.position + new Vector3(moveX, moveY, 0) * speed * Time.deltaTime;
        float clampedX = Mathf.Clamp(newPos.x, minX, maxX);
        float clampedY = Mathf.Clamp(newPos.y, minY, maxY - (maxY - minY) * 2 / 3);
        playerTransform.position = new Vector3(clampedX, clampedY, newPos.z);
    }
}

