using UnityEngine;
using UnityEngine.AI;

public class EnemyChase : MonoBehaviour
{
    EnemyStats enemyStats;
    NavMeshAgent agent;
    Transform player;

    void Awake()
    {
        enemyStats = GetComponent<EnemyStats>();
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player").transform;
    }

    private void Start()
    {
        agent.speed = enemyStats.currentMoveSpeed;
    }

    void Update()
    {
        if (!agent.isOnNavMesh) return;
        agent.SetDestination(player.position);
    }
}
