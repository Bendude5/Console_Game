using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawn_Player : MonoBehaviour
{
    [SerializeField]
    ProgressManager progress;

    public GameObject Player;

    public GameObject spawnEnter;
    public GameObject spawnLevel1;
    public GameObject spawnLevel2;
    public GameObject spawnBoss;

    public bool inHUB;

    //public void Start()
    //{
    //    //if (inHUB == true)
    //    //{
    //    //    if (progress.LastLevel == 0)
    //    //    {

    //    //    }

    //    //    else if (progress.LastLevel == 1)
    //    //    {

    //    //    }

    //    //    else if (progress.LastLevel == 2)
    //    //    {

    //    //    }

    //    //    else if (progress.LastLevel == 3)
    //    //    {

    //    //    }

    //    SceneManager.sceneLoaded += OnSceneLoaded;

    //}

    void Awake()
    {
        switch (progress.lastLevel)
        {
            case 0:
                Player.transform.position = spawnEnter.transform.position;
                Debug.Log("Main Spawn");
                break;
            case 1:
                Player.transform.position = spawnLevel1.transform.position;
                Debug.Log("Arcade 1");
                break;
            case 2:
                Player.transform.position = spawnLevel2.transform.position;
                Debug.Log("Arcade 2");
                break;
            case 3:
                Player.transform.position = spawnBoss.transform.position;
                Debug.Log("Boss Area");
                break;
        }
    }
}