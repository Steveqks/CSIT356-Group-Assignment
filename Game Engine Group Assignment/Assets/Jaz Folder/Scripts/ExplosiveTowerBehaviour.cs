using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveTowerBehaviour : MonoBehaviour
{
    public GameObject cannonPrefab;
    public Transform cannonStart;
    public GameObject particleSysPrefab;
    private float cannonImpulse = 5.0f;
    public float radius = 5.0f;
    public float power = 10.0f;

    public float fireRate = 1.0f;
    public float range = 10.0f;
    public float lifetime = 3.0f;

    bool canShoot = true;

    private MeshRenderer showRangeMeshRenderer;

    /*    public float throwCooldown = 1.0f;
        private float lastThrowTime = 0f;*/
    private IEnumerator shootProjectile(Transform enemy)
    {
        if (cannonPrefab != null && cannonStart != null)
        {
            GameObject cannon = Instantiate(cannonPrefab, cannonStart.position, Quaternion.identity);
            cannon.transform.LookAt(enemy.position);
            Vector3 direction = (enemy.position - cannonStart.position).normalized;
            cannon.GetComponent<Rigidbody>().velocity = direction * range;
            Destroy(cannon, lifetime);
        }
        yield return new WaitForSeconds(fireRate);
        canShoot = true;
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
    private void Start()
    {
        Transform meshRendTransform = transform.Find("showRange");

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

    private void Update()
    {
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
}
