using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    public float radius = 5.0f;
    public float power = 10.0f;
    public GameObject particles;

    private IEnumerator CannonPS(Collision collision)
    {
        Vector3 hitPoint = collision.contacts[0].point;
        Vector3 hitNormal = collision.contacts[0].normal;

        GameObject ps = Instantiate(particles, hitPoint, Quaternion.LookRotation(hitNormal));
        Debug.Log("Particle System Instantiated at: " + hitPoint);

        var psComponent = ps.GetComponent<ParticleSystem>();
        if (psComponent != null)
        {
            psComponent.Play();
            Debug.Log("Particle System started playing.");
        }
        else
        {
            Debug.Log("Particle Sys Component not found");
        }

        if (psComponent != null)
        {
            float duration = psComponent.main.duration;
            Debug.Log(duration);
            yield return new WaitForSeconds(duration);
        }
        else
        {
            yield return new WaitForSeconds(1);
        }
        Destroy(ps);
    }
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        StartCoroutine(CannonPS(collision));

        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);

        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
            {
                GameObject gObj = hit.transform.gameObject;
                EnemyBehaviour enemy = gObj.GetComponent<EnemyBehaviour>();

                if (enemy != null)
                {
                    enemy.health = enemy.health - 50;

                    if (enemy.health <= 0)
                    {
                        Destroy(enemy);
                    }
                }
                rb.AddExplosionForce(power, explosionPos, radius, 3.0f, ForceMode.Impulse);
            }
        }

        Debug.Log("[Grenade] hit the target");
        Destroy(gameObject);
    }
}
