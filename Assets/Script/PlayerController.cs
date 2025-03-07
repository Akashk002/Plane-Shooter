using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    private float moveX, moveY;
    private float minX, maxX, minY, maxY; // Screen bounds

    void Start()
    {
        // Calculate screen boundaries dynamically
        float halfWidth = GetComponent<SpriteRenderer>().bounds.extents.x;  // Player width
        float halfHeight = GetComponent<SpriteRenderer>().bounds.extents.y; // Player height

        minX = Camera.main.ScreenToWorldPoint(Vector3.zero).x + halfWidth;
        maxX = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x - halfWidth;

        minY = Camera.main.ScreenToWorldPoint(Vector3.zero).y + halfHeight;
        maxY = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y - halfHeight;
    }

    void Update()
    {
        // Get input for movement
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");

        // Move the player
        transform.position += new Vector3(moveX * speed * Time.deltaTime, moveY * speed * Time.deltaTime, 0);

        // Clamp position within screen bounds
        float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
        float clampedY = Mathf.Clamp(transform.position.y, minY, maxY - (maxY - minY) * 2 / 3);
        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }
}
