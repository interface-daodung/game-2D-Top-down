using UnityEngine;

public class BossEnemy : Enemy
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float CooldownDelay = 0.2f;
    [SerializeField] private float fireBulletRoundAmount = 36f;
    [SerializeField] private GameObject MiniEnemyPrefab;
    [SerializeField] private GameObject UsbPrefab;
    private float nextSkillTime;
    protected override void Update()
    {
        base.Update();
        if (Time.time >= nextSkillTime)
        {
            useSkill();
            nextSkillTime = Time.time + CooldownDelay;
        }

    }
    protected override void die()
    {
        Instantiate(UsbPrefab, transform.position, Quaternion.identity);
        base.die();
    }
    void fireBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        EnemyBullet enemyBullet = bullet.GetComponent<EnemyBullet>();
        enemyBullet.SetDirection(player.transform.position - firePoint.position);
    }
    void fireBulletRound()
    {
        float fireBulletAngle = 360f / fireBulletRoundAmount;
        for (int i = 0; i < fireBulletRoundAmount; i++)
        {
            float angle = fireBulletAngle * i;
            Quaternion rotation = Quaternion.Euler(0, 0, angle);
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, rotation);
            EnemyBullet enemyBullet = bullet.GetComponent<EnemyBullet>();
            enemyBullet.SetDirection(rotation * Vector3.right);
        }

    }

    void spawnMiniEnemy()
    {
        Instantiate(MiniEnemyPrefab, transform.position, Quaternion.identity);
    }

    void useSkill()
    {
        int skillIndex = Random.Range(0, 3);

        switch (0)
        {
            case 0:
                fireBullet();
                break;
            case 1:
                fireBulletRound();
                break;
            case 2:
                spawnMiniEnemy();
                break;
        }
    }
}
