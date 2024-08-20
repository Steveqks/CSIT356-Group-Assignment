using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public Transform[] waypoints;
    [SerializeField] private float minDistance = 1.0f;
    private int currentWaypoint = 0;
    private NavMeshAgent agent;
    private GameObject obj;
    private PlayerStatus ps;


    public float maxSpeed = 10.0f;

    public float mass = 1.0f;
    private Vector3 currentVelocity = Vector3.zero;
    
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        obj = GameObject.FindGameObjectWithTag("PlayerStatus");
        ps = obj.GetComponent<PlayerStatus>();
    }

    private void Update()
    {
        SetWaypoints(waypoints);
    }

    public void SetWaypoints(Transform[] newWaypoints)
    {
        agent = GetComponent<NavMeshAgent>();

        // set the waypints 
        waypoints = newWaypoints;

        if (currentWaypoint != waypoints.Length)
        {
            agent.SetDestination(waypoints[currentWaypoint].position);

            if (Vector3.Distance(transform.position, waypoints[currentWaypoint].position) < minDistance)
            {

                currentWaypoint++;

                Vector3 steeringForce = Seek();
                Vector3 acceleration = steeringForce / mass;

                currentVelocity += acceleration * Time.deltaTime;
                currentVelocity = Vector3.ClampMagnitude(currentVelocity, maxSpeed);

                transform.position += currentVelocity * Time.deltaTime;
                agent.velocity = currentVelocity;

                if (currentVelocity != Vector3.zero)
                {
                    transform.rotation = Quaternion.LookRotation(currentVelocity);
                }
            }
        }
        else
        {
            Debug.Log(this.gameObject.name + " - reach the last waypoint");
            ps.takeDamage(1);
            Destroy(this.gameObject);
        }
    }
    
    Vector3 Seek()
    {
        if (currentWaypoint != waypoints.Length)
        {
            Vector3 toTarget = waypoints[currentWaypoint].position - transform.position;
            toTarget.y = 0;
            Vector3 desiredVelocity = toTarget.normalized * maxSpeed;
            return (desiredVelocity - currentVelocity);
        }
        else
        {
            return Vector3.zero;
        }
    }
    

}
