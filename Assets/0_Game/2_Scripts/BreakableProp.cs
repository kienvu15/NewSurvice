using UnityEngine;

public class BreakableProp : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] float maxHealth = 5f;
    float health;

    [Header("Drop")]
    [SerializeField] DropRateManager dropRateManager;

    [HideInInspector] public GameObject prefabSource;

    void OnEnable()
    {
        health = maxHealth;
    }

    public void TakeDamage(float dmg)
    {
        health -= dmg;
        if (health <= 0)
        {
            Kill();
        }
    }

    void Kill()
    {
        dropRateManager?.OnKill();
        PropPool.Instance.Return(prefabSource, gameObject);
    }
}
