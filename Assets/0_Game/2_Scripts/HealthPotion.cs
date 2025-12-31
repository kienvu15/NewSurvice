using UnityEngine;

public class HealthPotion : MonoBehaviour, ICollectable
{
    public int healthToRestore;

    public void Collect()
    {
        PlayerStats playerStats = FindFirstObjectByType<PlayerStats>();
        playerStats.RestoreHealth(healthToRestore);
        Destroy(gameObject);
    }
}
