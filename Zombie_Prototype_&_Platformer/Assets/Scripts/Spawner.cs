using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Spawner : MonoBehaviour
{
    public NewLevelManager newLevelManager;
    public GameObject enemyPrefab;
    public float timeBetweenSpawns = 5.0f;
    public bool spawn = true;
    private bool _hasRun = false;


    // Start is called before the first frame update
    void Start()
    {  //The first zombie to spawnm
       InvokeRepeating("SpawnEnemy", 1.0f, timeBetweenSpawns);
    }

    // Update is called once per frame
    void Update()
    {
        if (!_hasRun)
        {            
            if (newLevelManager.score == newLevelManager.killsTillLastWave)
            {
                Invoke("FinalSpawnEnemy", 1);
                _hasRun = true;
                Debug.Log("The score matched the last wave");
            }
        }     
    }

    // How Enemies Spawn
    void SpawnEnemy()
	{
        if (spawn == true)
        {
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        }
	}
    void FinalSpawnEnemy()
    {
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        spawn = false;
    }
}
