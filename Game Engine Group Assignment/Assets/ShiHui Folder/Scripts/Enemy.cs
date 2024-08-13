using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform[] waypoints;
    [SerializeField] private float minDistance = 2.0f;
    private int currentWaypoint = 0;
    private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(waypoints[currentWaypoint].position);
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, waypoints[currentWaypoint].position) < minDistance)
        {
            currentWaypoint++;
            if (currentWaypoint == waypoints.Length)
            {
                currentWaypoint = waypoints.Length;
            }
            agent.SetDestination(waypoints[currentWaypoint].position);
        }
    }
}
