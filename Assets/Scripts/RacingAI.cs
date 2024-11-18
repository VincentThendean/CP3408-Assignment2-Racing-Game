using UnityEngine;
using UnityEngine.AI;

public class AICarController : MonoBehaviour
{
    public NavMeshAgent agent;  
    public Transform[] waypoints;  

    private int currentWaypointIndex = 0;
    public float passByDistance = 2f;

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

        if (!agent.pathPending && agent.remainingDistance <= passByDistance)
        {
            MoveToNextWaypoint();
        }
    }

    void MoveToNextWaypoint()
    {
        if (waypoints.Length == 0)
            return;

    
        agent.SetDestination(waypoints[currentWaypointIndex].position);

        currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
    }

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
