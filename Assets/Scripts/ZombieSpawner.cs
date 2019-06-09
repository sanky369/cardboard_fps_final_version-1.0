using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public Transform player;
    public GameObject zombiePrefab;
    public Transform[] spawnPoints;
    float timeBetweenSpawns;
    float timer;
    private int playerKills;
    bool spawnerEnabled;

    void OnEnable()
    {
        spawnerEnabled = true;
        StartCoroutine(SpawnZombies());
        //InvokeRepeating("SpawnZombies", timeBetweenSpawns, timeBetweenSpawns);
    }

    void Update()
    {
        playerKills = player.GetComponent<Player>().kills;
        DifficulyLevelUp(playerKills);
    }

    IEnumerator SpawnZombies()
    {
        while(spawnerEnabled)
        {
            timer += Time.deltaTime;
            if(timer >= timeBetweenSpawns)
            {
                int spawnPoint = Random.Range(0, spawnPoints.Length);
                Instantiate(zombiePrefab, spawnPoints[spawnPoint].position, Quaternion.identity);
                yield return new WaitForSeconds(timeBetweenSpawns);
                timer = 0;
            }
            
        }
        
    }

    void DifficulyLevelUp(int killAmount)
    {
        killAmount = 0;
        switch (killAmount)
        {
            case 0:
                timeBetweenSpawns = 3;
                break;

            case 2:
                timeBetweenSpawns = 2;
                break;

            case 10:
                timeBetweenSpawns = 1;
                break;

            case 15:
                timeBetweenSpawns = 0.5f;
                break;

            case 20:
                timeBetweenSpawns = 0.25f;
                break;

            case 25:
                timeBetweenSpawns = 0.1f;
                break;
        }

        Debug.Log(timeBetweenSpawns);
    }
 
}
