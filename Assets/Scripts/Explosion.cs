using UnityEngine;

public class Explosion : MonoBehaviour
{

    [SerializeField] private float damage = 50f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        Player player = collision.GetComponent<Player>();
        if (enemy != null)
        {
            enemy.takeDamage(damage); // Deal 50 damage to the enemy
        }
        if (player != null)
        {
            player.takeDamage(damage); // Deal 50 damage to the player
        }
    }

    public void DestroyExplode()
    {
        Destroy(gameObject); // Destroy the explosion effect after 0.5 seconds
    }
}
