using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] public int health = 100;
    private NavMeshAgent agent;
    private Renderer renderer;
    /*
    private GameObject obj;
    private PlayerStatus ps;
    */

    public ParticleSystem blood;

    [SerializeField] int reward;

    public enum EnemyType
    {
        GROUND,
        AIR
    } 

    public EnemyType enemyType = EnemyType.GROUND;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        renderer = GetComponent<Renderer>();
        /*
        obj = GameObject.FindGameObjectWithTag("PlayerStatus");
        ps = obj.GetComponent<PlayerStatus>();
        */
    }

    private void Update()
    {
        if (health <= 0)
        {
            Die();
        }
        else if (health <= 20)
        {
            // change color 
            renderer.material.color = Color.red;
            agent.speed = 8;
        }
        else if (health <= 50)
        {
            // change color 
            renderer.material.color = Color.yellow;
        }
    }
    public void Damage(int damage)
    {
        // particle - blood 
        Instantiate(blood, transform.position, Quaternion.identity);

        health -= damage;
    }

    public void Die()
    {
        // add money 
        /*ps.enemyReward(reward);*/
        Destroy(gameObject);
    }

}
