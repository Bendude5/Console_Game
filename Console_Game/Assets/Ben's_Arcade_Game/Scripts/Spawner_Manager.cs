using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_Manager : MonoBehaviour
{
    public int spawnerNumber;

    public GameObject spawner1;
    public GameObject spawner2;
    public GameObject spawner3;
    public GameObject spawner4;
    public GameObject spawner5;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            this.spawnEnemies();
        }
    }

    public void spawnEnemies()
    {
        spawnerNumber = Random.Range(1, 6);

        if (spawnerNumber == 1)
        {
            spawner1.GetComponent<Enemy_Spawner>().spawnPrefab();
        }

        if (spawnerNumber == 2)
        {
            spawner2.GetComponent<Enemy_Spawner>().spawnPrefab();
        }

        if (spawnerNumber == 3)
        {
            spawner3.GetComponent<Enemy_Spawner>().spawnPrefab();
        }

        if (spawnerNumber == 4)
        {
            spawner4.GetComponent<Enemy_Spawner>().spawnPrefab();
        }

        if (spawnerNumber == 5)
        {
            spawner5.GetComponent<Enemy_Spawner>().spawnPrefab();
        }
    }
}
