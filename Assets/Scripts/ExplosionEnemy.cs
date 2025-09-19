using UnityEngine;

public class ExplosionEnemy : Enemy
{
    [SerializeField] private GameObject explodePrefab;

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();
            if (player != null)
            {
                die();
            }

        }
    }
    protected override void die()
    {
        if (explodePrefab != null)
        {
            Instantiate(explodePrefab, transform.position, Quaternion.identity);
        }
        base.die();
    }
}
