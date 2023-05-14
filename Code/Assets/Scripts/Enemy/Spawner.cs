using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyToSpawn;
    [SerializeField] private float spawnTime = 0.4f;
    [SerializeField] private int waveCount = 0;
    [SerializeField] private int maxWave = 3;
    [SerializeField] private int wave = 1;
    [SerializeField] private float nextWaveTimer = 7f;
    
    void Start()
    {
        StartCoroutine(SpawnEnemy()); 
    }

    private IEnumerator SpawnEnemy ()
    {
        if (waveCount < maxWave)
        {
            Instantiate(enemyToSpawn, transform);
            waveCount++;
            yield return new WaitForSeconds(spawnTime);
            yield return NextWave();
        }

        waveCount = 0;
        wave++;
        maxWave = wave * 3;
        yield return new WaitForSeconds(nextWaveTimer);
        yield return NextWave();
    }

    private IEnumerator NextWave ()
    {
        yield return new WaitForSeconds(nextWaveTimer);
        yield return SpawnEnemy();
    }
}
