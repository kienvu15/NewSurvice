using UnityEngine;
using System.Collections.Generic;

public class MapController : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] List<GameObject> terrainChunks;
    [SerializeField] float checkerRadius = 1f;
    [SerializeField] LayerMask terrainLayer;

    [Header("Current State")]
    public GameObject currentChunk;

    // Danh sách tên các điểm neo (Anchor points) trong Prefab
    readonly string[] directionNames = {
        "Right", "Left", "Up", "Down",
        "Right Up", "Right Down", "Left Up", "Left Down"
    };

    // Hàm này sẽ được gọi từ TrunkTrigger khi Player bước vào chunk mới
    public void OnPlayerEnterNewChunk(GameObject newChunk)
    {
        currentChunk = newChunk;
        CheckAndSpawnAdjacentChunks();
    }

    void CheckAndSpawnAdjacentChunks()
    {
        if (currentChunk == null) return;

        foreach (string dirName in directionNames)
        {
            Transform anchor = currentChunk.transform.Find(dirName);

            if (anchor != null)
            {
                // Kiểm tra xem tại vị trí anchor này đã có mảnh đất nào chưa
                // Sử dụng OverlapSphere để check Layer "Terrain"
                if (!Physics.CheckSphere(anchor.position, checkerRadius, terrainLayer))
                {
                    SpawnChunk(anchor.position);
                }
            }
            else
            {
                Debug.LogWarning($"Thiếu điểm neo '{dirName}' trong Prefab: {currentChunk.name}");
            }
        }
    }

    void SpawnChunk(Vector3 spawnPosition)
    {
        int rand = Random.Range(0, terrainChunks.Count);
        Instantiate(terrainChunks[rand], spawnPosition, Quaternion.identity);
    }
}