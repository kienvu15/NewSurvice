using UnityEngine;
using System.Collections.Generic;

public class MapController : MonoBehaviour
{
    [SerializeField] List<GameObject> terrainChunks;
    [SerializeField] GameObject player;
    public float checkerRadius;
    Vector3 noTerrainPosition;
    public LayerMask terrainLayer;
    PlayerMovement playerMovement;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerMovement = player.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChunkChecker()
    {
        if(playerMovement.moveDir.x > 0 && playerMovement.moveDir.y == 0)
        {
            Collider[] colliders = Physics.OverlapSphere(player.transform.position + new Vector3(20, 0, 0), checkerRadius, terrainLayer);
            if (colliders.Length == 0)
            {
                noTerrainPosition = player.transform.position + new Vector3(20, 0, 0);
            }
        }
    }


}
