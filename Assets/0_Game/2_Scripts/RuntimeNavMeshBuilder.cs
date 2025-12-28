using Unity.AI.Navigation;
using UnityEngine;

public class RuntimeNavMeshBuilder : MonoBehaviour
{
    NavMeshSurface surface;

    void Awake()
    {
        surface = GetComponent<NavMeshSurface>();
    }

    public void Rebuild()
    {
        surface.BuildNavMesh();
    }
}
