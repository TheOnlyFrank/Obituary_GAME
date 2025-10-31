using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawns : MonoBehaviour
{
    public GameObject mantis;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnEnemy()
    {
        int spawnPointX = Random.Range(-10, 10);
        int spawnPointY = Random.Range(-10, 10);
        int spawnPointZ = Random.Range(-10, 10);

        Vector3 spawnPosition = new Vector3(spawnPointX, spawnPointY, spawnPointZ);

        Instantiate(mantis, spawnPosition, Quaternion.identity);
    }
}
