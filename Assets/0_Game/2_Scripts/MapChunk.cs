using UnityEngine;

public class MapChunk : MonoBehaviour
{
    [SerializeField] PropRandomizer propRandomizer;

    public void OnSpawn()
    {
        propRandomizer?.SpawnProps();
    }

    public void OnDespawn()
    {
        propRandomizer?.ClearProps();
    }
}
