using System.Collections.Generic;
using UnityEngine;

public class MapChunkPool : MonoBehaviour
{
    public static MapChunkPool Instance;

    [SerializeField] private List<GameObject> prefabs;
    [SerializeField] private int initialPoolSize = 10;

    private Dictionary<string, Queue<GameObject>> poolDictionary =
        new Dictionary<string, Queue<GameObject>>();

    private void Awake()
    {
        Instance = this;

        foreach (GameObject prefab in prefabs)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < initialPoolSize; i++)
            {
                GameObject obj = Instantiate(prefab, transform);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            poolDictionary.Add(prefab.name, objectPool);
        }
    }

    public GameObject GetFromPool(GameObject prefab, Vector3 position)
    {
        string key = prefab.name;

        if (!poolDictionary.ContainsKey(key))
            return null;

        GameObject obj = poolDictionary[key].Count > 0
            ? poolDictionary[key].Dequeue()
            : Instantiate(prefab, transform);

        obj.transform.position = position;
        obj.SetActive(true);
        obj.GetComponent<MapChunk>()?.OnSpawn();

        return obj;
    }

    public void ReturnToPool(GameObject obj)
    {
        obj.GetComponent<MapChunk>()?.OnDespawn();
        obj.SetActive(false);

        string key = obj.name.Replace("(Clone)", "").Trim();

        if (poolDictionary.ContainsKey(key))
        {
            poolDictionary[key].Enqueue(obj);
        }
    }
}
