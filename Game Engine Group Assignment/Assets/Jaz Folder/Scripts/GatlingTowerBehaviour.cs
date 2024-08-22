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

    private float fireTimer;

    private MeshRenderer showRangeMeshRenderer;

    // Start is called before the first frame update
    void Start()
    {
        fireTimer = fireRate;

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
        fireTimer += Time.deltaTime;
    }
    private void shootProjectile(Transform enemy)
    {
        if (arrowPrefab != null && arrowStart != null)
        {
            GameObject arrow = Instantiate(arrowPrefab, arrowStart.position, Quaternion.identity);
            arrow.transform.LookAt(enemy.position);
            Vector3 direction = (enemy.position - arrowStart.position).normalized;
            arrow.GetComponent<Rigidbody>().velocity = direction * range;
            Destroy(arrow, lifetime);
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
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Projectile"))
        {
            Debug.Log("test test test");
        }
    }
}
