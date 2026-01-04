using System.Collections.Generic;
using UnityEngine;

public class PropPool : MonoBehaviour
{
    public static PropPool Instance;

    [SerializeField] List<GameObject> propPrefabs;
    [SerializeField] int initialSizePerPrefab = 5;

    Dictionary<GameObject, Queue<GameObject>> pool = new();

    void Awake()
    {
        Instance = this;

        foreach (var prefab in propPrefabs)
        {
            Queue<GameObject> q = new();

            for (int i = 0; i < initialSizePerPrefab; i++)
            {
                GameObject obj = Instantiate(prefab, transform);
                obj.SetActive(false);
                q.Enqueue(obj);
            }

            pool.Add(prefab, q);
        }
    }

    public GameObject Get(GameObject prefab, Transform parent, Vector3 pos)
    {
        if (!pool.ContainsKey(prefab))
            return null;

        GameObject obj = pool[prefab].Count > 0
            ? pool[prefab].Dequeue()
            : Instantiate(prefab, transform);

        obj.transform.SetParent(parent);
        obj.transform.position = pos;
        obj.transform.rotation = Quaternion.identity;
        obj.SetActive(true);

        return obj;
    }

    public void Return(GameObject prefab, GameObject obj)
    {
        obj.SetActive(false);
        obj.transform.SetParent(transform);
        pool[prefab].Enqueue(obj);
    }
}
