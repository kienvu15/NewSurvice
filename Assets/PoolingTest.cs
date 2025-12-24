using System.Collections.Generic;
using UnityEngine;

public class PoolingTest : MonoBehaviour
{
    public GameObject prefab;
    public int poolSize = 10;

    private Queue<GameObject> pool = new Queue<GameObject>();

    private void Awake()
    {
        for(int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(prefab, transform);
            obj.SetActive(false);
            pool.Enqueue(obj);
        }
    }

    public GameObject GetFromPool()
    {
        GameObject obj;
        if(pool.Count > 0)
        {
            obj = pool.Dequeue();
        }
        else
        {
            obj = Instantiate(prefab, transform);
        }

        obj.SetActive(true);
        return obj;
    }

    public void ReturToPool(GameObject obj)
    {
        obj.SetActive(false);
        pool.Enqueue(obj);
    }
}
