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
    Animator animator;


	[SerializeField] int reward;

	public enum EnemyType
	{
		GROUND,
		AIR
	}

    //public EnemyType enemyType = EnemyType.GROUND;
    public EnemyType enemyType;

	private void Start()
	{
		agent = GetComponent<NavMeshAgent>();
		renderer = GetComponent<Renderer>();
		/*
        obj = GameObject.FindGameObjectWithTag("PlayerStatus");
        ps = obj.GetComponent<PlayerStatus>();
        */

        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (enemyType == EnemyType.GROUND)
        {
            animator.Play("Run");
        } 
        else if (enemyType == EnemyType.AIR) {
            animator.Play("Fly");
        }
        

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
        animator.Play("Hit");

        // particle - blood 
        Instantiate(blood, transform.position, Quaternion.identity);

        health -= damage;
    }

    public void Die()
    {
        animator.Play("Death");

        // add money 
        /*ps.enemyReward(reward);*/

        Destroy(gameObject);
    }

	public void Die()
	{
		// add money 
		/*ps.enemyReward(reward);*/
		Destroy(gameObject);
	}
}
