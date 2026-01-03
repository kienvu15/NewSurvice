using DG.Tweening;
using UnityEngine;

public class HealthPotion : MonoBehaviour, ICollectable, IPullableCollectable
{
    public int healthToRestore;

    private bool isPulling;
    private bool collected;

    public bool IsPulling => isPulling;

    public void StartPull()
    {
        if (isPulling) return;
        isPulling = true;
    }

    public Transform GetTransform() => transform;

    public void Collect()
    {
        PlayerStats player = FindFirstObjectByType<PlayerStats>();
        player.RestoreHealth(healthToRestore);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (collected || !isPulling)
            return;

        if (other.CompareTag("Player"))
        {
            collected = true;
            transform.DOKill();
            Collect();
            Destroy(gameObject);
        }
    }
}
