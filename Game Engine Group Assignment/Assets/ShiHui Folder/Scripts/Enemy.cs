using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] public int health = 100;
    private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (health <= 0)
        {
            Debug.Log("health = " + health);
            Die();
        }
        else if (health <= 20)
        {
            Debug.Log("speed = " + agent.speed);
            Debug.Log("health = " + health);
            agent.speed = 8;
            Debug.Log("speed = " + agent.speed);
        }
    }
    public void Damage(int damage)
    {
        health -= damage;
    }

    public void Die()
    {
        Destroy(gameObject);
    }

}
