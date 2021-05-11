using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class Spawner : MonoBehaviour
{
    public NewLevelManager newLevelManager;
    public GameObject enemyPrefab;
    public float timeBetweenSpawns = 5.0f;
    public float timeUntilSpawn = 0f;
    public bool spawn = true;
    private bool _hasRun = false;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        timeUntilSpawn -= Time.deltaTime;

        if (timeUntilSpawn <= 0)
        {
            //Keep spawning zombies
            InvokeRepeating("SpawnEnemy", 1.0f, timeBetweenSpawns);
            timeUntilSpawn = 1000;
        }


        //Run Once
        if (!_hasRun)
        {            
            //if Kill cap is reached
            if (newLevelManager.score == newLevelManager.killsTillLastWave)
            {
                //Spawn last wave after 1 second
                Invoke("FinalSpawnEnemy", 1);
                _hasRun = true;                
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
    //How Final Enemies Spawn
    void FinalSpawnEnemy()
    {
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        spawn = false;
    }
}
