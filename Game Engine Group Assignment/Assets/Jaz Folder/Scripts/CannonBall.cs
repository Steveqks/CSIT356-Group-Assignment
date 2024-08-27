using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class CannonBall : MonoBehaviour
{
    public float explosionRadius;
    public int explosionDamage;
    public GameObject particleSysPrefab;

    private void OnCollisionEnter(Collision collision)
    {
        // Create explosion effect
        if (particleSysPrefab != null)
        {
            Instantiate(particleSysPrefab, transform.position, Quaternion.identity);
        }

        // Find all colliders within the explosion radius
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider hitCollider in hitColliders)
        {
            // Check if the collider has the "Enemy" tag
            if (hitCollider.CompareTag("Enemy"))
            {
                Enemy enemy = hitCollider.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.Damage(explosionDamage);
                }
                // Apply damage to the enemy (assuming the enemy has a method to take damage)
                //hitCollider.GetComponent<Enemy>().Damage(explosionDamage);
            }
        }
        // Destroy the cannonball after the explosion
        Destroy(gameObject);
    }
}
