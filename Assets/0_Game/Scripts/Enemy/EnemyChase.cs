using UnityEngine;
using UnityEngine.AI;

public class EnemyChase : MonoBehaviour
{
    NavMeshAgent agent;
    Transform player;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        if (!agent.isOnNavMesh) return;
        agent.SetDestination(player.position);
    }
}
