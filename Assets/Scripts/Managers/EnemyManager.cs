using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject enemy;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;
    public GameObject[] enemyPrefab;

    public int waveWeightUsed = 0;
    EnemyHealth enemyHealth;
    public static int enemyKilled = 0;
    public int enemySpawned = 0;

    int bossSpawned = 0;

    void Start ()
    {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
        WaveManager.waveNum = 1;
        WaveManager.waveWeight = 10;
        enemyKilled = 0;
        enemySpawned = 0;
    }


    void Spawn ()
    {

        if (GameLogics.mode == 1) {
            if (playerHealth.currentHealth <= 0f)
            {
                return;
            }


            int spawnPointIndex = Random.Range (0, spawnPoints.Length);
            int spawnEnemy = Random.Range(0,enemyPrefab.Length);

            if (spawnEnemy == 4) {
                spawnPointIndex = Random.Range (3,4);
            }

            if (spawnEnemy == 5) {
                spawnPointIndex = 5;
            }

            Instantiate(enemyPrefab[spawnEnemy], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        }

        else if (GameLogics.mode == 2) {

            int enemyWeight;

            if (playerHealth.currentHealth <= 0f)
            {
                return;
            }

            if (WaveManager.waveNum % 3 == 1) {
                bossSpawned = 0;
            }

            while (waveWeightUsed < WaveManager.waveWeight) {
                int spawnPointIndex = Random.Range (0, spawnPoints.Length);
                int spawnEnemy = 0;

                if (WaveManager.waveNum <= 3) {
                    spawnEnemy = Random.Range(0,3);
                }
                else if (WaveManager.waveNum <= 6) {
                    spawnEnemy = Random.Range(0,4);
                }
                else if (WaveManager.waveNum <= 9) {
                    spawnEnemy = Random.Range(0,5);
                }

                if (spawnEnemy == 4) {
                    spawnPointIndex = Random.Range (3,4);
                }

                if (spawnEnemy == 5) {
                    spawnPointIndex = 5;
                }
                
                enemy = enemyPrefab[spawnEnemy];
                enemyHealth = enemy.GetComponent<EnemyHealth>();
                enemyWeight = enemyHealth.weight;

                if (WaveManager.waveNum % 3 == 0 && bossSpawned < 1) {
                    Instantiate(enemyPrefab[5], spawnPoints[5].position, spawnPoints[5].rotation);
                    enemySpawned += 1;
                    bossSpawned += 1;
                }

                if ((enemyWeight + waveWeightUsed) <= WaveManager.waveWeight) {
                    Instantiate(enemyPrefab[spawnEnemy], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
                    waveWeightUsed += enemyWeight;
                    enemySpawned += 1;
                }
            }

            if (waveWeightUsed == WaveManager.waveWeight) {
                if (enemyKilled == enemySpawned) {
                    WaveManager.waveNum += 1;
                    WaveManager.waveWeight += 10;
                    waveWeightUsed = 0;
                }
            }
        }
    }
}
