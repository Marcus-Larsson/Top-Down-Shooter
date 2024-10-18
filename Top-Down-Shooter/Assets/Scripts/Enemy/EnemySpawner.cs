using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float minSpawnTime = 1f;
    [SerializeField] float maxSpawnTime = 3f;
    [SerializeField] float spawnDistace = 10f;
    Vector2 screenBounds;
    Vector2 spawnPos;

    void Start()
    {
        SpawnEnemy();
    }
    void SpawnEnemy()
    {
        float spawnTime = Random.Range(minSpawnTime, maxSpawnTime);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        int side = Random.Range(0, 4);
        switch (side)
        {

            case 0:
                spawnPos = new Vector2(Random.Range(-screenBounds.x, screenBounds.x), screenBounds.y + spawnDistace);
                break;
            case 1:
                spawnPos = new Vector2(Random.Range(-screenBounds.x, screenBounds.x), -screenBounds.y - spawnDistace);
                break;
            case 2:
                spawnPos = new Vector2(screenBounds.x + spawnDistace, Random.Range(-screenBounds.y, screenBounds.y));
                break;
            case 3:
                spawnPos = new Vector2(-screenBounds.x - spawnDistace, Random.Range(-screenBounds.y, screenBounds.y));
                break;
        }
        Instantiate(enemyPrefab, spawnPos, transform.rotation);
        Invoke("SpawnEnemy", spawnTime);

    }
    


}

