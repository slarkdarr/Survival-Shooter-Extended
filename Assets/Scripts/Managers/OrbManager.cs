using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public float spawnTime = 3f;
    //public Transform[] spawnPoints;
    public GameObject[] orbPrefab;
    public float MinX = 0;
    public float MaxX = 10;
    public float Y = 1;
    public float MinZ = 0;
    public float MaxZ = 10;

    // Start is called before the first frame update
    void Start()
    {  
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    // Update is called once per frame
    void Spawn()
    {
        if (playerHealth.currentHealth <= 0f)
        {
            return;
        }
        float x = Random.Range(MinX,MaxX);
        float z = Random.Range(MinZ,MaxZ);

        //int spawnPointIndex = Random.Range (0, spawnPoints.Length);
        int spawnOrb = Random.Range(0, orbPrefab.Length);
        Instantiate(orbPrefab[spawnOrb], new Vector3(x,Y,z), Quaternion.identity);

    }
}
