using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SimpleEnemyController : MonoBehaviour
{
	private List<Transform> waypoints;
	private int currentWP = 0;
	[SerializeField] private float distanceToWP = 0.5f;
	private bool WPset = false;
	NavMeshAgent agent;

	// Start is called before the first frame update
	void Start()
	{
		agent = GetComponent<NavMeshAgent>();
	}

	// Update is called once per frame
	void Update()
	{
		if (!WPset)
		{
			return;
		}

		if (!agent.pathPending && agent.remainingDistance <= distanceToWP)
		{
			if (currentWP == waypoints.Count - 1)
			{
				Destroy(this.gameObject);
			}
			else
			{
				currentWP++;
				agent.SetDestination(waypoints[currentWP].position);
			}
		}
	}

	public void SetDestination(List<Transform> waypoints)
	{
		this.waypoints = waypoints;
		WPset = true;
	}
}
