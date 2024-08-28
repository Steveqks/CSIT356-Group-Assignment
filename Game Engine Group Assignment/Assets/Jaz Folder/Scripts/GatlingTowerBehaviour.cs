using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatlingTowerBehaviour : MonoBehaviour
{

    public GameObject arrowPrefab;
    public Transform arrowStart;
    public float fireRate = 1.0f;
    public float range = 10.0f;
    public float lifetime = 3.0f;


    bool canShoot = true;

    //private float fireTimer;

    private MeshRenderer showRangeMeshRenderer;
    private Transform targetEnemy;

    private AudioSource rapidFireSFX;

    // Start is called before the first frame update
    void Start()
    {
        //fireTimer = fireRate;

        Transform meshRendTransform = transform.Find("showRange");

        rapidFireSFX = GetComponent<AudioSource>();

        if (meshRendTransform != null)
        {
            showRangeMeshRenderer = meshRendTransform.GetComponent<MeshRenderer>();

            if (showRangeMeshRenderer != null)
            {
                showRangeMeshRenderer.enabled = false;
            }
        }
        else
        {
            Debug.LogError("showRange is not Found");
        }
    }
    private void ToggleShowRange(bool show)
    {
        if (showRangeMeshRenderer != null)
        {
            showRangeMeshRenderer.enabled = show;
        }
    }
    private void OnMouseEnter()
    {
        ToggleShowRange(true);
    }
    private void OnMouseExit()
    {
        ToggleShowRange(false);
    }

    // Update is called once per frame
    void Update()
    {
        //fireTimer += Time.deltaTime;

        if (targetEnemy != null)
        {
            Debug.Log("Distance to target: " + Vector3.Distance(transform.position, targetEnemy.position));
            Debug.Log("Range: " + range);
        }

        if (canShoot)
        {
            if (targetEnemy == null || !IsTargetInRange())
            {
                FindNewTarget();
            }
            if (targetEnemy != null)
            {
                StartCoroutine(shootProjectile(targetEnemy));
                canShoot = false;
            }
        }
    }
    /*    private void shootProjectile(Transform enemy)
        {
            if (arrowPrefab != null && arrowStart != null)
            {
                GameObject arrow = Instantiate(arrowPrefab, arrowStart.position, Quaternion.identity);
                arrow.transform.LookAt(enemy.position);
                Vector3 direction = (enemy.position - arrowStart.position).normalized;
                arrow.GetComponent<Rigidbody>().velocity = direction * range;
                Destroy(arrow, lifetime);

                if (rapidFireSFX != null)
                {
                    rapidFireSFX.Play();
                }
            }
        }*/
    private IEnumerator shootProjectile(Transform enemy)
    {
        if (arrowPrefab != null && arrowStart != null)
        {
            GameObject arrow = Instantiate(arrowPrefab, arrowStart.position, Quaternion.identity);
            arrow.transform.LookAt(enemy.position);
            Vector3 direction = (enemy.position - arrowStart.position).normalized;
            arrow.GetComponent<Rigidbody>().velocity = direction * range;
            Destroy(arrow, lifetime);

            if (rapidFireSFX != null)
            {
                rapidFireSFX.Play();  // Play the shooting sound effect
            }
        }
        yield return new WaitForSeconds(fireRate);
        canShoot = true;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("EnemyAir"))
        {
            Debug.Log("Enemy IN range!");
            shootProjectile(other.transform);
            //fireTimer = 0.0f;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Projectile"))
        {
            Debug.Log("test test test");
        }
    }
    private void FindNewTarget()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, range);
        foreach (Collider collider in hitColliders)
        {
            if (collider.CompareTag("EnemyAir"))
            {
                targetEnemy = collider.transform;
                break;
            }
        }
    }
    private bool IsTargetInRange()
    {
        return Vector3.Distance(transform.position, targetEnemy.position) <= range;
    }
}
