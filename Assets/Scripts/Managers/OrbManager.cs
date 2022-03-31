using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbManager : MonoBehaviour
{
    public Orb orb;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;
    public GameObject[] orbPrefab;

    // Start is called before the first frame update
    void Start()
    {  
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (orb.abc<100)
        {
            return;
        }


        int spawnPointIndex = Random.Range (0, spawnPoints.Length);
        int spawnEnemy = Random.Range(0,orbPrefab.Length);
        Instantiate(orbPrefab[spawnEnemy], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);

    }
}
