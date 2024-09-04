using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Enemy prefab to spawn
    public Transform player; // Player transform
    public float spawnInterval = 5f; // Interval in seconds

    void Start()
    {
        InvokeRepeating("SpawnEnemy", 0f, spawnInterval);
    }

    void SpawnEnemy()
    {
        Vector3 randomDirection = Random.insideUnitSphere * 10;
        randomDirection += player.position;
        randomDirection.y = player.position.y; // Keep the same height as the player

        Instantiate(enemyPrefab, randomDirection, Quaternion.identity);
    }
}