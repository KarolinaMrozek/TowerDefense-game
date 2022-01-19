using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Wróg))]
public class EnemyMovement : MonoBehaviour
{
    private Transform target;
    private int wavepointIndex = 0;

    private Wróg enemy;

    void Start()
    {
        enemy = GetComponent<Wróg>();

        target = kierunek.points[0];

    }
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }

    }
    void GetNextWaypoint()
    {
        if (wavepointIndex >= kierunek.points.Length - 1)
        {
            EndPath();
            return;
        }

        wavepointIndex++;
        target = kierunek.points[wavepointIndex];
    }

    void EndPath()
    {
        PlayerStat.Lives--;
        Spawner.EnemiesAlive--;
        Destroy(gameObject);
    }
}
