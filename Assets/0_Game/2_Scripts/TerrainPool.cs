using UnityEngine;
using System.Collections.Generic;

public class TerrainPool : MonoBehaviour
{
    public static TerrainPool Instance;

    [SerializeField] List<GameObject> terrainPrefabs;
    [SerializeField] int initialPoolSize = 10;

    Dictionary<int, Queue<GameObject>> pools = new Dictionary<int, Queue<GameObject>>();

    void Awake()
    {
        Instance = this;
        InitializePool();
    }

    void InitializePool()
    {
        foreach (var prefab in terrainPrefabs)
        {
            int key = prefab.GetInstanceID();
            pools[key] = new Queue<GameObject>();

            for (int i = 0; i < initialPoolSize; i++)
            {
                GameObject obj = Instantiate(prefab, transform);
                obj.SetActive(false);
                pools[key].Enqueue(obj);
            }
        }
    }

    public GameObject GetFromPool(GameObject prefab, Vector3 position)
    {
        int key = prefab.GetInstanceID();
        GameObject obj;

        if (pools[key].Count > 0)
        {
            obj = pools[key].Dequeue();
        }
        else
        {
            // Nếu hết pool thì tạo mới (hiếm khi xảy ra nếu pool đủ lớn)
            obj = Instantiate(prefab, transform);
        }

        obj.transform.position = position;
        obj.SetActive(true);
        return obj;
    }

    public void ReturnToPool(GameObject obj, GameObject prefab)
    {
        obj.SetActive(false);
        pools[prefab.GetInstanceID()].Enqueue(obj);
    }
}