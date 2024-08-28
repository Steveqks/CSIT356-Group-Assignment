using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;

public class Enemy : MonoBehaviour
{
	[SerializeField] public int health = 100;
	private NavMeshAgent agent;
	private Renderer renderer;
	/**/
    private GameObject obj;
    private PlayerStatus ps;
    

	public ParticleSystem blood;
	Animator animator;

	Vector3 bloodPos;
    //[SerializeField] int reward;

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
		
        obj = GameObject.FindGameObjectWithTag("PlayerStatus");
        ps = obj.GetComponent<PlayerStatus>();
        

		animator = GetComponent<Animator>();
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
            renderer.material.SetColor("_EmissionColor", Color.red * 5.0f);
            renderer.material.EnableKeyword("_EMISSION");
            agent.speed = 8;
		}
		else if (health <= 50)
		{
            // change color 
            renderer.material.SetColor("_EmissionColor", Color.yellow * 5.0f);
            renderer.material.EnableKeyword("_EMISSION");
            renderer.material.color = Color.yellow;
		}
	}
	public void Damage(int damage)
	{
		//animator.Play("Hit");

		// particle - blood 
		Instantiate(blood, bloodPos, Quaternion.identity);

		/* JAZ EDITTED - now "Blood" disappears after awhile */
        //ParticleSystem bloodClone = Instantiate(blood, transform.position, Quaternion.identity);
        //Destroy(bloodClone, 2.0f);

        health -= damage;
	}

	public void Die()
	{
		animator.Play("Death");

		// add money 
		ps.enemyReward(5);

		Destroy(gameObject);
	}


    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Projectile"))
        {
            Debug.Log("HIT HIT HIT");
			Damage(25);
            //navMesh.speed += speedIncrement;
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Cannon"))
        {
            Debug.Log("HIT HIT HIT");
			Damage(40);
            //navMesh.speed += speedIncrement;
            Destroy(other.gameObject);
        }
    }

}
