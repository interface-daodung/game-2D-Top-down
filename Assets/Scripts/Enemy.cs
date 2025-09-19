using UnityEngine;
using UnityEngine.UI;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected float speed = 2f;
    [SerializeField] protected float maxHp = 100f;
    [SerializeField] private Image HpBar;
    [SerializeField] protected float enterDamage = 10f;
    [SerializeField] protected float stayDamage = 1f;
    protected float currentHp;
    protected Player player;

    protected virtual void Start()
    {
        player = FindAnyObjectByType<Player>();
        currentHp = maxHp;
        updateHpBar();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        moveTowardsPlayer();
    }

    protected void moveTowardsPlayer()
    {
        if (player == null) return;
        transform.position = Vector3.MoveTowards(
            transform.position,
            player.transform.position,
            speed * Time.deltaTime
        );
        flipEnemy();
    }

    protected void flipEnemy()
    {
        if (player != null)
        {
            transform.localScale =
            new Vector3(player.transform.position.x < transform.position.x ? -1 : 1, 1, 1);
        }

    }
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();
            if (player != null)
            {
                player.takeDamage(enterDamage);
            }

        }
    }
    protected virtual void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();
            if (player != null)
            {
                player.takeDamage(stayDamage);
            }
        }
    }
    public virtual void takeDamage(float damage)
    {
        currentHp -= damage;
        currentHp = Mathf.Clamp(currentHp, 0, maxHp);
        updateHpBar();
        if (currentHp <= 0)
        {
            die();
        }
    }

    protected virtual void die()
    {
        Destroy(gameObject);
    }
    private void updateHpBar()
    {
        if (HpBar != null)
        {
            HpBar.fillAmount = currentHp / maxHp;
        }
    }
}
