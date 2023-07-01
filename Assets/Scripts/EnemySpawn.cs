using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    
    public GameObject enemyPrefeb;
    Transform spawnPoints;

    float timer;
    float spawnWait = 4f;

    EnemeyMovement enemymovement;
    void Start()
    {
       // spawnLocation = new Vector3(Random.Range(41, 48), Random.Range(0, 1), Random.Range(3, -13));
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnWait)
        {
            EnemySpawner();
            timer = 0f;
        }
    }

    void EnemySpawner()
    {
                // --------------BÝRÝNCÝ SPAWN NOKTASI ---------------------

        float secondepointX = Random.Range(1.50f, 18);
        float secondpointY = Random.Range(0, 1);
        float secondpointZ = Random.Range(48, 41);
        Vector3 secondspawnLocation = new Vector3(secondepointX, secondpointY, secondpointZ);

        GameObject secondspawnEnemy = Instantiate(enemyPrefeb, secondspawnLocation, Quaternion.identity);
        secondspawnEnemy.GetComponent<EnemeyMovement>();

        EnemeyMovement secondenemymovement = secondspawnEnemy.GetComponent<EnemeyMovement>();
        EnemyAttack secondenemyattack = secondspawnEnemy.GetComponent<EnemyAttack>();
        if (secondenemymovement != null)
        {

            //enemymovement.charachterObject = character;
            secondenemymovement.enabled = true;
        }

                // --------------BÝRÝNCÝ SPAWN NOKTASI ---------------------



        // --------------ÝKÝNCÝ SPAWN NOKTASI ---------------------
        float firstpointX = Random.Range(41,48);
        float firstpointY = Random.Range(0,1);
        float firstpointZ = Random.Range(3,-13);
        Vector3 spawnLocation = new Vector3(firstpointX, firstpointY, firstpointZ);

        GameObject spawnEnemy = Instantiate(enemyPrefeb, spawnLocation, Quaternion.identity);
        spawnEnemy.GetComponent<EnemeyMovement>();

        EnemeyMovement enemymovement = spawnEnemy.GetComponent<EnemeyMovement>();
        EnemyAttack enemyattack = spawnEnemy.GetComponent<EnemyAttack>();
        if (enemymovement != null)
        {
           
            //enemymovement.charachterObject = character;
            enemymovement.enabled = true;
        }

        // --------------ÝKÝNCÝ SPAWN NOKTASI ---------------------
    }
}
