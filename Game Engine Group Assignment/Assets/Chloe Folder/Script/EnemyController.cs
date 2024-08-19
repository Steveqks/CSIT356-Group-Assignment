using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
	public float speed = 10.0f;
	private Transform target;

	private int wpIndex = 0;
	[SerializeField] private float distanceToWP = 0.4f;
	private bool wpSet = false;

	NavMeshAgent agent;

	void Start()
	{
		// set target as first wp
		target = WayPoints.waypoints[0];
		agent = GetComponent<NavMeshAgent>();
	}

	void Update()
	{
		if (wpSet)
		{
			if (!agent.pathPending && agent.remainingDistance <= distanceToWP)
			{
				GetNextWP();
				agent.SetDestination(target.position);
			}
		}
	}

	void GetNextWP()
	{
		if (wpIndex >= WayPoints.waypoints.Count - 1)
		{
			Destroy(gameObject);
			return;
		}
		else
		{
			wpIndex++;
			target = WayPoints.waypoints[wpIndex];
		}
	}

	void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawLine(transform.position, transform.position + transform.forward * 2);
	}
}
