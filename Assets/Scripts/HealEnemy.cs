using UnityEngine;

public class HealEnemy : Enemy
{
    [SerializeField] private float healAmount = 50f;
    protected override void die()
    {
        Player player = FindAnyObjectByType<Player>();
        if (player != null)
        {
            player.heal(healAmount);
        }
        base.die();
    }
}
