using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifeTime = 3f;
    [SerializeField] float baseFireRate = 0.3f;
    [SerializeField] float minimumFireRate = 0.2f;
    [SerializeField] float fireRateVariance = 0f;

    [SerializeField] bool useAI;

    [HideInInspector] public bool isFiring;
    Coroutine fireCoroutine;

    void Start()
    {
        if (useAI)
        {
            isFiring = true;
        }
    }
    private void Update()
    {
        Fire();
    }

    void Fire()
    {
        if (isFiring && fireCoroutine == null)
        {
            fireCoroutine = StartCoroutine(FireContinuously());
        }
        else if (fireCoroutine != null && !isFiring)
        {
            StopCoroutine(fireCoroutine);
            fireCoroutine = null;
        }
    }

    IEnumerator FireContinuously()
    {
        while (true)
        {
            GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            
            projectile.transform.rotation = transform.rotation;
            
            Rigidbody2D projectilerb = projectile.GetComponent<Rigidbody2D>();
            projectilerb.linearVelocity= transform.up * projectileSpeed;
            
            Destroy(projectile, projectileLifeTime);
            
            float waitTime = Random.Range(baseFireRate - fireRateVariance, baseFireRate + fireRateVariance);
            waitTime = Mathf.Clamp(waitTime, minimumFireRate, float.MaxValue);
            
            yield return new WaitForSeconds(waitTime);
        }
    }
}
