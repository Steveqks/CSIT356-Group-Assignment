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
        // need check 
        if (health <= 0)
        {
            Die();
        }
        else if (health <= 20)
        {
            agent.speed = 8;
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
