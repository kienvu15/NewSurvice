using UnityEngine;

public class ChunkOptimizer : MonoBehaviour
{
    public GameObject myPrefab; // Gán từ MapController lúc spawn
    Transform player;
    public float maxDistance = 60f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        InvokeRepeating("CheckDistance", 2f, 2f);
    }

    void CheckDistance()
    {
        if (player == null) return;

        if (Vector3.Distance(transform.position, player.position) > maxDistance)
        {
            // Trả về pool thay vì Destroy
            TerrainPool.Instance.ReturnToPool(this.gameObject, myPrefab);
        }
    }
}