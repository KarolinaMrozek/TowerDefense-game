using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{


    public static int EnemiesAlive = 0;

    public Wave[] waves;

    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;

    public Text waveCountdownText;

    private float countdown = 2f;

    private int waveIndex = 0;

    void Update()
    {

        if(EnemiesAlive > 0)
        {
            return;
        }

        if (countdown <= 0f)
        {
            StartCoroutine(SpawnerW());
            countdown = timeBetweenWaves;
            return;
        }
        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        
        waveCountdownText.text = string.Format("{0:00.00}", countdown);
        

    }
    IEnumerator SpawnerW()
    {
        PlayerStat.Rounds++;

        Wave wave = waves[waveIndex];

        for(int i=0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }

        waveIndex++;

        if(waveIndex == waves.Length)
        {
            Debug.Log("LEVEL WON!");
            this.enabled = false;
        }

    }

    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        EnemiesAlive++;

        
    }
}
