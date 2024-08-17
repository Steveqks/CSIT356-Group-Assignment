using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTowerBehaviour : MonoBehaviour
{
    public GameObject arrowPrefab;
    public Transform arrowStart;
    public float fireRate = 1.0f;
    public float range = 10.0f;
    private float fireTimer;

    bool canShoot = true;

/*    private void Start()
    {
        fireTimer = fireRate;
    }*/

    private void Update()
    {
        //fireTimer += Time.deltaTime;

        if (canShoot)
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, range);
            foreach (Collider collider in hitColliders)
            {
                if (collider.CompareTag("Enemy"))
                {
                     StartCoroutine(shootProjectile(collider.transform));
                     canShoot = false;
                }
            }
        }
    }

    private IEnumerator shootProjectile(Transform enemy)
    {
        if (arrowPrefab != null && arrowStart != null)
        {
            GameObject arrow = Instantiate(arrowPrefab, arrowStart.position, Quaternion.identity);
            Vector3 direction = (enemy.position - arrowStart.position).normalized;
            arrow.GetComponent<Rigidbody>().velocity = direction * range;
        }
        yield return new WaitForSeconds(fireRate);
        canShoot = true;
    }

    // GATLING TOWER SCRIPT

/*    private void shootProjectile(Transform enemy)
    {
        if (arrowPrefab != null && arrowStart != null)
        {
            GameObject arrow = Instantiate(arrowPrefab, arrowStart.position, Quaternion.identity);
            Vector3 direction = (enemy.position - arrowStart.position).normalized;
            arrow.GetComponent<Rigidbody>().velocity = direction * range;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Enemy IN range!");
            shootProjectile(other.transform);
            fireTimer = 0.0f;
        }
    }*/
}
