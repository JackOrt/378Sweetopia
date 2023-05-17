using UnityEngine;

public class EnemyTurret : MonoBehaviour
{
    public Transform player;
    public float detectionRadius = 5f;
    public float projectileSpeed = 10f;
    public float fireRate = 1f; // The time delay between each projectile
    public GameObject projectilePrefab;
    public AudioSource hitNoise;
    public float projectileLifetime = 3f; // The duration before the projectile disappears

    private float nextFireTime;

    private void Update()
    {
        // Check if player is within detection radius
        if (Vector2.Distance(transform.position, player.position) <= detectionRadius)
        {
            // Calculate direction towards the player
            Vector2 direction = (player.position - transform.position).normalized;

            // Rotate enemy to face the player
            transform.up = direction;

            // Check if enough time has passed to fire another projectile
            if (Time.time >= nextFireTime)
            {
                // Launch projectile towards the player
                LaunchProjectile(direction);

                // Set the next fire time
                nextFireTime = Time.time + 1f / fireRate;
            }
        }
    }

    private void LaunchProjectile(Vector2 direction)
    {
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

        // Set projectile's velocity
        rb.velocity = direction * projectileSpeed;

        // Destroy the projectile after the specified lifetime if it doesn't hit the player
        Destroy(projectile, projectileLifetime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if collided with player
        if (collision.CompareTag("Player"))
        {
            // Damage the player
            collision.GetComponent<PlayerHealth>().Damage(1);
            hitNoise.Play();

            // Destroy the projectile
            Destroy(gameObject);
        }
    }
}
