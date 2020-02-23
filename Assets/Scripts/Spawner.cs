using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] spawnPrefabs;
    public float spawnRadius = 0f;
    public int spawnAmount = 1;
    public float timer;
    public float gameTime;
    public int maxSpawn = 1;
    public int spawnInterval = 1;
    public float spawntimer1;
    public float spawntimer2;    
    

    void Start()
    {
        
    }

    void Update()
    {
        gameTime += Time.deltaTime;

        if(gameTime >= 20)
        {
            spawntimer2 = 9;
        }
        if (gameTime >= 40)
        {
            
            spawntimer2 = 7;
        }
        if (gameTime >= 60)
        {
            
            spawntimer2 =  5;
        }
        if (gameTime >= 80)
        {
            
            spawntimer2 = 0.5f;
        }

        timer += Time.deltaTime;

        if(timer >= Random.Range(spawntimer1,spawntimer2))
        {
            
            StartCoroutine(SpawnNow());
            timer = 0;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, spawnRadius);
    }

    void SpawnEnemies()
    {
        for (int i = 0; i < spawnAmount; i++)
        {
            // Spawned new GameObject
            int randomIndex = Random.Range(0, spawnPrefabs.Length);

            // Store randomly selected prefab
            GameObject randomPrefab = spawnPrefabs[randomIndex];

            // Spawned new GameObject
            GameObject clone = Instantiate(randomPrefab);

            // Calculate random position within sphere
            Vector3 randomPos = transform.position + Random.insideUnitSphere * spawnRadius; // calculate random position

            // Lock the Y
            randomPos.z = 0;

            // Set spawned object's position
            clone.transform.position = randomPos;
        }
    }

    IEnumerator SpawnNow()
    {
        

        // Spawn the Enemy
        SpawnEnemies();

        yield return new WaitForSeconds(spawnInterval); // wait a few seconds

        
    }
}
