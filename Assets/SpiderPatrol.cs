using UnityEngine;
using UnityEngine.AI;

public class SpiderPatrol : MonoBehaviour
{
    public Transform[] waypoints;         // Array of patrol points
    private NavMeshAgent agent;           // Reference to the NavMeshAgent
    private int currentWaypoint = 2;      // Index of the current waypoint

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();  // Get the agent component

        if (waypoints.Length > 0)
        {
            // Start moving toward the first waypoint
            agent.SetDestination(waypoints[currentWaypoint].position);
        }
    }

    void Update()
    {
        // Move to next waypoint if current one is reached
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
            agent.SetDestination(waypoints[currentWaypoint].position);
        }
    }
}
