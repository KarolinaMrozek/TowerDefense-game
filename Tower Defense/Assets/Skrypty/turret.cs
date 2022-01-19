using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turret : MonoBehaviour
{ 
    private Transform target;
    private Wróg targetEnemy;

    [Header("Atrybuty")]

    public float range = 15f;
    public float fireRate = 1f;
    private float fireCountdown = 0f;

    [Header("Spowolnienie")]
    public int damageOverTime = 30;
    public float SlowPct = .5f;

    [Header("Stworzone w Unity")]

    public string enemyTag = "Wróg";

    public Transform WiezaObrot;
    public float turnSpeed = 10f;

    public GameObject bulletPrefab;
    public Transform firePoint;

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }
    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach(GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
            targetEnemy = nearestEnemy.GetComponent<Wróg>();
        }
        else
        {
            target = null;
        }

    }
    

    void Update()
    {
        if (target == null)
            return;

        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(WiezaObrot.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        WiezaObrot.rotation = Quaternion.Euler (0f, rotation.y, 0f);

        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate; 
        }

        fireCountdown -= Time.deltaTime;
 
    }

    void Spowolnienie()
    {
        targetEnemy.TakeDamage(damageOverTime * Time.deltaTime);
        targetEnemy.Slow(SlowPct);
    }


    void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
            bullet.Seek(target);
        
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
