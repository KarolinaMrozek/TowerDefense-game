using UnityEngine;

public class Wróg : MonoBehaviour
{
    public float startSpeed = 10f;
    public float speed;

    public float health = 100;

    public int worth = 50;


    public GameObject deathEffect;

    void Stard()
    {
        speed = startSpeed;
    }
    
    
    //ZYCIE/UMIERANIE
    public void TakeDamage (float amount)
    {
        health -= amount;

        if(health <= 0)
        {
            Die();
        }
    }

    public void Slow (float pct)
    {
        speed = startSpeed * (1f - pct);
    }

    void Die()
    {
        PlayerStat.Money += worth;

        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);

        Spawner.EnemiesAlive--;

        Destroy(gameObject);
    }

   

}
