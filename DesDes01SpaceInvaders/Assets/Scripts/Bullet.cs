using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public float lifeTime = 2f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, lifeTime);
    }

    // Updated SetDirection to accept a speed boost
    public void SetDirection(Vector2 direction, float speedBoost = 0f)
    {
        if (rb == null)
            rb = GetComponent<Rigidbody2D>();

        // Apply the speed boost to the bullet speed
        rb.velocity = direction.normalized * (speed + speedBoost);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pellet"))
            return;

        Destroy(collision.gameObject);
        Destroy(gameObject);
    }

    // Bullet Speed Buff (called from power-up trigger)
    public void ApplySpeedBuff(float amount, float duration)
    {
        StartCoroutine(SpeedBuffCoroutine(amount, duration));
    }

    private IEnumerator SpeedBuffCoroutine(float amount, float duration)
    {
        speed += amount;
        yield return new WaitForSeconds(duration);
        speed -= amount;
    }
}
