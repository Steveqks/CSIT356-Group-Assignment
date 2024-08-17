using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BaseTower : MonoBehaviour
{
    /* Timer fields */
    protected float lastTick;
    protected float refreshRate = 0.10f;

    protected float lastAction;
    protected float cooldown = 1;

    protected float range = 5.0f;

    private void Update()
    {
        // if tower ready to shot  
        if (Time.time - lastAction > cooldown)
        {
            // refresh every 0.10f to find target
            if (Time.time - lastTick > refreshRate)
            {
                // look for target
                lastTick = Time.time;

                /* get target */
                Transform target = GetClosestEnemy();
                if (target != null)
                {
                    Action(target);
                }
            }
        }
    }

    private Transform GetClosestEnemy()
    {
        /* test if there are Enemies within the range */
        Collider[] allEnemies = Physics.OverlapSphere(transform.position, range, LayerMask.GetMask("Enemy"));

        if (allEnemies.Length != 0)
        {
            int closestIndex = 0;
            float closestDistance = Vector3.SqrMagnitude(transform.position - allEnemies[0].transform.position);

            for (int i = 1; i <allEnemies.Length; i++)
            {
                float distance = Vector3.SqrMagnitude(transform.position - allEnemies [i].transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestIndex = i;
                }
            }
            return allEnemies[closestIndex].transform;
        }    
        return null;
    }

    private void Action(Transform target)
    {
        lastAction = Time.time;
        Debug.Log(gameObject.name + " is shooting at " + target.name);
        Debug.DrawRay(transform.position, target.position - transform.position, Color.red, 1.5f);
    }

}
