using UnityEngine;
using UnityEngine.AI;

public class EnemyChase : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] EnemyScriptableObject enemyData;

    NavMeshAgent agent;
    Transform player;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player").transform;

        agent.speed = enemyData.MoveSpeed;
    }

    void Update()
    {
        if (!agent.isOnNavMesh) return;
        agent.SetDestination(player.position);
    }
}
