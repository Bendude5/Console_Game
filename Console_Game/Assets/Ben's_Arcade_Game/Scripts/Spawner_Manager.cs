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
    public GameObject spawner6;
    public GameObject spawner7;
    public GameObject spawner8;
    public GameObject spawner9;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            this.spawnEnemies();
        }
    }

    public void spawnEnemies()
    {
        spawnerNumber = Random.Range(1, 10);

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

        if (spawnerNumber == 6)
        {
            spawner6.GetComponent<Enemy_Spawner>().spawnPrefab();
        }

        if (spawnerNumber == 7)
        {
            spawner7.GetComponent<Enemy_Spawner>().spawnPrefab();
        }

        if (spawnerNumber == 8)
        {
            spawner8.GetComponent<Enemy_Spawner>().spawnPrefab();
        }

        if (spawnerNumber == 9)
        {
            spawner9.GetComponent<Enemy_Spawner>().spawnPrefab();
        }
    }
}
