using UnityEngine;
using System.Collections.Generic;

public class PropRandomizer : MonoBehaviour
{
    public List<Transform> propSpawnPoints;
    public List<GameObject> propPrefabs;

    List<(GameObject prefab, GameObject instance)> spawnedProps = new();

    public void SpawnProps()
    {
        ClearProps();

        foreach (Transform sp in propSpawnPoints)
        {
            int rand = Random.Range(0, propPrefabs.Count);
            GameObject prefab = propPrefabs[rand];

            GameObject prop = PropPool.Instance.Get(
                        prefab,
                        sp,
                        sp.position
                    );

            var breakable = prop.GetComponent<BreakableProp>();
            if (breakable != null)
            {
                breakable.prefabSource = prefab;
            }

            spawnedProps.Add((prefab, prop));

        }
    }

    public void ClearProps()
    {
        foreach (var data in spawnedProps)
        {
            if (data.instance != null)
            {
                PropPool.Instance.Return(data.prefab, data.instance);
            }
        }

        spawnedProps.Clear();
    }
}
