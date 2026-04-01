using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefabs;
    public GameObject powerupPrefabs;
    public float spawnRange = 9.0f;
    public int enemyCount;
    public int waveNumber = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnEnemyWave(waveNumber);
        Instantiate(powerupPrefabs, GenerateSpawnPosition(), powerupPrefabs.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsByType<EnemyController>(FindObjectsSortMode.None).Length;

        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            Instantiate(powerupPrefabs, GenerateSpawnPosition(), powerupPrefabs.transform.rotation);
        }
    }

    private void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefabs, GenerateSpawnPosition(), enemyPrefabs.transform.rotation);
        }
    }

    public Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        Vector3 randomPos = new Vector3(spawnPosX, 0.11f, spawnPosZ);

        return randomPos;
    }
}
