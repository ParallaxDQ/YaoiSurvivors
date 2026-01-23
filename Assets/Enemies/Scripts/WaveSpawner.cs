using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class EnemySpawnWave
{
    public EnemySO enemyToSpawn;
    public int enemyCount = 5;
    public int spawnMinutes = 0;
    public int spawnSeconds = 0;
    
    [HideInInspector] public bool hasSpawned = false;
    
    public float GetSpawnTime()
    {
        return (spawnMinutes * 60f) + spawnSeconds;
    }
}

public class WaveSpawner : MonoBehaviour
{
    public List<EnemySpawnWave> waves = new List<EnemySpawnWave>();
    public GameObject enemyPrefab;
    public Transform player;
    public float spawnDistance = 15f;
    public float spawnSpread = 5f;
    
    private float gameTime = 0f;

    void Update()
    {
        gameTime += Time.deltaTime;
        
        foreach (EnemySpawnWave wave in waves)
        {
            if (wave.enemyToSpawn == null) continue;
            
            if (!wave.hasSpawned && gameTime >= wave.GetSpawnTime())
            {
                SpawnWave(wave);
                wave.hasSpawned = true;
            }
        }
    }

    void SpawnWave(EnemySpawnWave wave)
    {
        Debug.Log($"Spawning {wave.enemyCount} {wave.enemyToSpawn.enemyName} at {gameTime:F1}s");
        
        for (int i = 0; i < wave.enemyCount; i++)
        {
            SpawnEnemy(wave.enemyToSpawn);
        }
    }

    void SpawnEnemy(EnemySO enemySO)
    {
        if (player == null || enemySO == null) return;
    
        // Random position around player
        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        Vector3 offset = new Vector3(randomDirection.x, randomDirection.y, 0) * spawnDistance;
        Vector3 spawnPosition = player.position + offset;
    
        // Instantiate enemy
        GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        enemy.name = enemySO.enemyName;
    
        // Assign sprite directly to SpriteRenderer
        SpriteRenderer spriteRenderer = enemy.GetComponent<SpriteRenderer>();
        if (spriteRenderer != null && enemySO.enemySprite != null)
        {
            spriteRenderer.sprite = enemySO.enemySprite;
        }
    
        // Get the Enemy component and initialize
        Enemy enemyComponent = enemy.GetComponent<Enemy>();
        if (enemyComponent != null)
        {
            enemyComponent.enemyData = enemySO.ToEnemyData();
            enemyComponent.Initialize();
        }
    }
}