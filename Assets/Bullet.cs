using UnityEngine;

public class Bullet : MonoBehaviour
{
    private PoolingTest poolingTest;

    public void Init(PoolingTest pool)
    {
        this.poolingTest = pool;
    }

    private void OnEnable()
    {
        Invoke(nameof(ReturnToPool), 2f);
    }

    void ReturnToPool()
    {
        poolingTest.ReturToPool(this.gameObject);
    }
}
