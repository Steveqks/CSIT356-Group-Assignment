using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
	private List<Transform> waypoints;
	private int currentWP = 0;
	[SerializeField] private float distanceToWP = 0.5f;
	NavMeshAgent agent;

	// Start is called before the first frame update
	void Start()
	{
		agent = GetComponent<NavMeshAgent>();
	}

	// Update is called once per frame
	void Update()
	{

	}

	public void SetDestination(List<Transform> waypoints)
	{
		//
	}
}
