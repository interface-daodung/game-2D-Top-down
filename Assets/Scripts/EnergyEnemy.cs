using UnityEngine;

public class EnergyEnemy : Enemy
{
    [SerializeField] private GameObject energyOrbPrefab;
    protected override void die()
    {
        if (energyOrbPrefab != null)
        {
            GameObject energy = Instantiate(energyOrbPrefab, transform.position, Quaternion.identity);
            Destroy(energy, 8f); // Destroy the energy orb after 8 seconds
        }
        base.die();
    }
}
