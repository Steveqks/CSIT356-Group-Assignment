using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    public float explosionRadius = 5.0f;
    public int explosionDamage = 50;
    public GameObject particleSysPrefab;

    private void OnCollisionEnter(Collision collision)
    {
         // Trigger the explosion
            Explode();
    }

    private void Explode()
    {
        // Instantiate particle effects at the explosion point
        if (particleSysPrefab != null)
        {
            Instantiate(particleSysPrefab, transform.position, Quaternion.identity);
        }

        // Find all enemies within the explosion radius
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider hitCollider in hitColliders)
        {
            Enemy enemy = hitCollider.GetComponent<Enemy>();

            // If the collider belongs to an enemy, deal damage
            if (enemy != null)
            {
                enemy.Damage(explosionDamage);
            }
        }

        // Destroy the cannonball after the explosion
        Destroy(gameObject);
    }
}
