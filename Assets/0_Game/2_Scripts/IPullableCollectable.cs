using UnityEngine;

public interface IPullableCollectable
{
    bool IsPulling { get; }
    void StartPull();
    Transform GetTransform();
}
