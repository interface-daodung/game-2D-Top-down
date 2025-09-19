using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private Vector3 direction;
    [SerializeField] private float speed = 20f;
    [SerializeField] public float Damage = 5f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (direction == Vector3.zero) return;
        transform.position += direction * speed * Time.deltaTime;
    }

    public void SetDirection(Vector3 dir)
    {
        direction = dir.normalized;
    }
}
