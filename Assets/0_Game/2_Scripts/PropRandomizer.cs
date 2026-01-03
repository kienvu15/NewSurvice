using UnityEngine;
using System.Collections.Generic;

public class PropRandomizer : MonoBehaviour
{
    [Header("Spawn Points")]
    public List<Transform> propSpawnPoints;

    [Header("Prop Prefabs")]
    public List<GameObject> propPrefabs;

    List<GameObject> activeProps = new();

    public void SpawnProps()
    {
        ClearProps();

        foreach (Transform sp in propSpawnPoints)
        {
            if (propPrefabs.Count == 0) return;

            int rand = Random.Range(0, propPrefabs.Count);

            GameObject prop = PropPool.Instance.Get(
                propPrefabs[rand],
                sp.position,
                sp
            );

            activeProps.Add(prop);
        }
    }

    public void ClearProps()
    {
        foreach (var prop in activeProps)
        {
            if (prop != null)
                PropPool.Instance.Return(prop);
        }

        activeProps.Clear();
    }
}
