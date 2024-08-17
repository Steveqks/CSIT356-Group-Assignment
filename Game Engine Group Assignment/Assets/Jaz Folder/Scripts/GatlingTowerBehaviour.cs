using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatlingTowerBehaviour : MonoBehaviour
{

    public GameObject arrowPrefab;
    public Transform arrowStart;
    public float fireRate = 1.0f;
    public float range = 10.0f;
    private float fireTimer;

    // Start is called before the first frame update
    void Start()
    {
        fireTimer = fireRate;
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
    }
}
