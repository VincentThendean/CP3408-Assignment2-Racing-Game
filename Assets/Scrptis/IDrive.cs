using UnityEngine;
using UnityEngine.AI;

public class IDrive : MonoBehaviour
{
    public NavMeshAgent agent;  // NavMesh代理
    public Transform[] waypoints;  // 路径点数组

    private int currentWaypointIndex = 0;  // 当前路径点索引

    void Start()
    {
        if (waypoints.Length == 0)
        {
            Debug.LogError("Waypoints array is empty.");
            return;
        }

        agent = GetComponent<NavMeshAgent>();
        if (agent == null)
        {
            Debug.LogError("NavMeshAgent component not found.");
            return;
        }

        MoveToNextWaypoint();
    }

    void Update()
    {
        // 检查是否到达路径点
        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance && !agent.hasPath && agent.velocity.sqrMagnitude == 0f)
        {
            MoveToNextWaypoint();
        }
    }

    void MoveToNextWaypoint()
    {
        if (waypoints.Length == 0)
            return;

        // 设置下一个路径点为目的地
        agent.SetDestination(waypoints[currentWaypointIndex].position);

        // 更新路径点索引
        currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
    }

    // 在编辑器中显示路径点的连线，方便调试
    void OnDrawGizmos()
    {
        if (waypoints == null || waypoints.Length < 2)
            return;

        Gizmos.color = Color.red;
        for (int i = 0; i < waypoints.Length; i++)
        {
            Transform current = waypoints[i];
            Transform next = waypoints[(i + 1) % waypoints.Length];
            Gizmos.DrawLine(current.position, next.position);
        }
    }
}
