using UnityEngine;
using DG.Tweening;

public class PlayerCollector : MonoBehaviour
{
    [SerializeField] private PlayerStats playerStats;
    [SerializeField] private CapsuleCollider playerCollector;

    [Header("Push Pull")]
    [SerializeField] private float pushDistance = 0.4f;
    [SerializeField] private float pushDuration = 0.08f;
    [SerializeField] private float pullDuration = 0.3f;

    private void Update()
    {
        playerCollector.radius = playerStats.currentMagnet;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent(out IPullableCollectable pullable))
            return;

        if (pullable.IsPulling)
            return;

        pullable.StartPull();

        Transform item = pullable.GetTransform();
        item.DOKill();

        Vector3 dir = (item.position - transform.position).normalized;
        Vector3 pushPos = item.position + dir * pushDistance;

        Sequence seq = DOTween.Sequence();
        seq.Append(item.DOMove(pushPos, pushDuration).SetEase(Ease.OutQuad));
        seq.Append(item.DOMove(transform.position, pullDuration).SetEase(Ease.InQuad));
        seq.SetLink(item.gameObject, LinkBehaviour.KillOnDestroy);
    }

}
