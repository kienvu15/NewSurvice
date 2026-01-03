using UnityEngine;
using System.Collections.Generic;

public class PropPool : MonoBehaviour
{
    public static PropPool Instance;

    [System.Serializable]
    public class PoolItem
    {
        public GameObject prefab;
        public int initialSize = 5;
    }

    [SerializeField] List<PoolItem> poolItems;

    Dictionary<string, Queue<GameObject>> poolDict = new();

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        foreach (var item in poolItems)
        {
            Queue<GameObject> queue = new();

            for (int i = 0; i < item.initialSize; i++)
            {
                GameObject obj = Instantiate(item.prefab, transform);
                obj.SetActive(false);
                queue.Enqueue(obj);
            }

            poolDict.Add(item.prefab.name, queue);
        }
    }

    public GameObject Get(GameObject prefab, Vector3 pos, Transform parent)
    {
        string key = prefab.name;

        if (!poolDict.ContainsKey(key))
        {
            poolDict[key] = new Queue<GameObject>();
        }

        GameObject obj = poolDict[key].Count > 0
            ? poolDict[key].Dequeue()
            : Instantiate(prefab, transform);

        obj.transform.SetParent(parent);
        obj.transform.position = pos;
        obj.transform.rotation = Quaternion.identity;
        obj.SetActive(true);

        return obj;
    }

    public void Return(GameObject obj)
    {
        obj.SetActive(false);
        obj.transform.SetParent(transform);

        string key = obj.name.Replace("(Clone)", "").Trim();

        if (!poolDict.ContainsKey(key))
            poolDict[key] = new Queue<GameObject>();

        poolDict[key].Enqueue(obj);
    }
}
