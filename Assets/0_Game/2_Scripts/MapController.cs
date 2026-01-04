using UnityEngine;
using System.Collections.Generic;

public class MapController : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private List<GameObject> terrainChunks;
    [SerializeField] private float checkerRadius = 6f;
    [SerializeField] private LayerMask terrainLayer;
    [SerializeField] private float maxDistance = 100f; // Khoảng cách để thu hồi chunk

    [Header("Player Reference")]
    [SerializeField] private Transform player;

    public GameObject currentChunk;

    private List<GameObject> activeChunks = new List<GameObject>();

    private readonly string[] directionNames =
    {
        "Right",
        "Left",
        "Up",
        "Down",
        "Right Up",
        "Right Down",
        "Left Up",
        "Left Down"
    };

    private void Update()
    {
        CheckAndReturnChunks();
    }

    public void OnPlayerEnterNewChunk(GameObject newChunk)
    {
        currentChunk = newChunk;
        CheckAndSpawnAdjacentChunks();
    }

    private void CheckAndSpawnAdjacentChunks()
    {
        if (currentChunk == null) return;

        foreach (string dirName in directionNames)
        {
            Transform anchor = currentChunk.transform.Find(dirName);
            if (anchor == null) continue;

            bool hasChunk = Physics.CheckSphere(
                anchor.position,
                checkerRadius,
                terrainLayer
            );

            if (!hasChunk)
            {
                SpawnChunk(anchor.position);
            }
        }
    }

    private void SpawnChunk(Vector3 spawnPosition)
    {
        int rand = Random.Range(0, terrainChunks.Count);

        // Sử dụng Pool thay vì Instantiate
        GameObject newChunk = MapChunkPool.Instance.GetFromPool(
            terrainChunks[rand],
            spawnPosition
        );

        if (newChunk != null)
        {
            activeChunks.Add(newChunk);
        }
    }

    private void CheckAndReturnChunks()
    {
        if (player == null) return;

        for (int i = activeChunks.Count - 1; i >= 0; i--)
        {
            GameObject chunk = activeChunks[i];
            float distance = Vector3.Distance(
                player.position,
                chunk.transform.position
            );

            // Nếu đi quá xa và không phải chunk hiện tại
            if (distance > maxDistance && chunk != currentChunk)
            {
                MapChunkPool.Instance.ReturnToPool(chunk);
                activeChunks.RemoveAt(i);
            }
        }
    }
}
