using Unity.AI.Navigation;
using UnityEngine;

public class ChunkNavMesh : MonoBehaviour
{
    NavMeshSurface surface;

    void Awake()
    {
        surface = GetComponent<NavMeshSurface>();
    }

    void OnEnable()
    {
        surface.BuildNavMesh();
    }

    void OnDisable()
    {
        surface.RemoveData();
    }
}
