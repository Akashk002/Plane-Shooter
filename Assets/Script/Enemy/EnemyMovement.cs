using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float speed = 2f;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;
    }
}
