using UnityEngine;

public class SimpleEnemyMovement : IEnemyMovement
{
    private Transform transform;
    private float speed;

    public SimpleEnemyMovement(Transform transform, float speed)
    {
        this.transform = transform;
        this.speed = speed;
    }

    public void Move()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;
    }
}
