using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 1;
    public AudioSource hitNoise;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.Damage(damage);
                hitNoise.Play();
            }
            Destroy(gameObject);
        }
    }
}
