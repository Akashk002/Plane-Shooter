using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] int health, MaxHealth;
    public GameObject destroyEffect;
    private float moveX, moveY;
    private float minX, maxX, minY, maxY;
    public Slider slider;
    [SerializeField] int bonusHealth = 50;

    void Start()
    {
        MaxHealth = health;
        float halfWidth = GetComponent<SpriteRenderer>().bounds.extents.x;  // Player width
        float halfHeight = GetComponent<SpriteRenderer>().bounds.extents.y; // Player height

        minX = Camera.main.ScreenToWorldPoint(Vector3.zero).x + halfWidth;
        maxX = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x - halfWidth;

        minY = Camera.main.ScreenToWorldPoint(Vector3.zero).y + halfHeight;
        maxY = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y - halfHeight;
    }

    void Update()
    {
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");

        transform.position += new Vector3(moveX * speed * Time.deltaTime, moveY * speed * Time.deltaTime, 0);
        float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
        float clampedY = Mathf.Clamp(transform.position.y, minY, maxY - (maxY - minY) * 2 / 3);
        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyBullet")
        {
            damage(collision.gameObject.GetComponent<Bullet>().damageRate);
        }
        else
        if (collision.gameObject.tag == "Coin")
        {
            GameManager.This.AddCoin();
        }
        else
        if (collision.gameObject.tag == "Health")
        {
            UpdateHealth(bonusHealth);
        }
    }

    void damage(int val)
    {
        UpdateHealth(-val);

        if (health <= 0)
        {
            ObjectPoolManager.This.GetPooledObject(ObjectName.PlaneDestroyEffect, transform.position);
            gameObject.SetActive(false);
        }
    }

    public void UpdateHealth(int val)
    {
        if (health > 0)
        {
            health += val;

            if (health > MaxHealth)
            {
                health = MaxHealth;
            }

            if (health < 0)
            {
                health = 0;
            }

            slider.value = health;
        }
    }
}
