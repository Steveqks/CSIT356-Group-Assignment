using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;

public class Enemy : MonoBehaviour
{
	[SerializeField] public int health;
    [SerializeField] public int reward;

    private NavMeshAgent agent;
	private Renderer renderer;
	
    private GameObject obj;
    private PlayerStatus ps;

    private Animator animator;

	public ParticleSystem blood;
	private Vector3 bloodPos;

    public enum EnemyType
	{
		GROUND,
		AIR
	}

    public enum EnemySpeedType
    {
        FAST,
        SLOW
    }

    public EnemyType enemyType;
    public EnemySpeedType enemySpeedType;

	private void Start()
	{
		agent = GetComponent<NavMeshAgent>();
		renderer = GetComponent<Renderer>();
		
        obj = GameObject.FindGameObjectWithTag("PlayerStatus");
        ps = obj.GetComponent<PlayerStatus>();

		animator = GetComponent<Animator>();

		if (enemySpeedType == EnemySpeedType.FAST)
        {
            agent.speed = 5;
			health = 100;
			reward = 1;
        }
        else if (enemySpeedType == EnemySpeedType.SLOW)
        {
			agent.speed = 3.5f;
            health = 150;
			reward = 2;
        }
    }

	private void Update()
	{
        bloodPos = transform.position + new Vector3(0f, 0.5f, 0f);
		
        if (enemyType == EnemyType.GROUND)
		{
			animator.Play("Run");
		}
		else if (enemyType == EnemyType.AIR)
		{
			animator.Play("Fly");
		}

		if (health <= 0)
		{
			Die();
		}
		else if (health <= 30)
		{
			// change color 
			renderer.material.color = Color.red;
			// set speed (speed up) 
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
		Instantiate(blood, bloodPos, Quaternion.identity);

        health -= damage;
	}

	public void Die()
	{
		// add money 
		ps.enemyReward(reward);

		Destroy(gameObject);
	}

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Projectile"))
        {
            Debug.Log("HIT HIT HIT");
			Damage(25);
            Destroy(other.gameObject);
        }
    }

}
