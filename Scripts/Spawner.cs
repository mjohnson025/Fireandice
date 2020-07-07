using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] hazards;
    private float timeBetweenSpawns;
    public float startBetweenSpawns;
    public float minTimeBetweenSpawns;
    public float decrease;
    public GameObject player;

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if (player != null){

            if(timeBetweenSpawns <= 0){
                //Spawn Hazard
                Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            // print(randomSpawnPoint);
                GameObject randomHazard = hazards[Random.Range(0, hazards.Length)];
                print(randomHazard);

                Instantiate(randomHazard, randomSpawnPoint.position, Quaternion.identity);

                if (startBetweenSpawns > minTimeBetweenSpawns){
                    startBetweenSpawns -=decrease;
                }
                timeBetweenSpawns = startBetweenSpawns;
                //print(timeBetweenSpawns);
            }
            else
            {
            timeBetweenSpawns -= Time.deltaTime;   
            }

        }
    }
}
