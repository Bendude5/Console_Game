using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressionPopup : MonoBehaviour
{
    [SerializeField]
    ProgressManager progress;

    public GameObject completeIcon1;
    public GameObject incompleteIcon1;

    public GameObject completeIcon2;
    public GameObject incompleteIcon2;

    public GameObject bossSpinner1;
    public GameObject bossSpinner2;


    void Update()
    {
        Level1ProgressCheck();
        Level2ProgressCheck();          
    }

    void Level1ProgressCheck()
    {
        switch (progress.level1Complete)
        {
            //level 1 completed
            case true:
                completeIcon1.SetActive(true);
                incompleteIcon1.SetActive(false);
                bossSpinner1.SetActive(false);
                break;
            //level 1 not completed
            case false:
                completeIcon1.SetActive(false);
                incompleteIcon1.SetActive(true);
                bossSpinner1.SetActive(true);
                break;
        }
    }

    void Level2ProgressCheck()
    {
        switch (progress.level2Complete)
        {
            //level 2 completed
            case true:
                completeIcon2.SetActive(true);
                incompleteIcon2.SetActive(false);
                bossSpinner2.SetActive(false);
                break;
            //level 2 not completed
            case false:
                completeIcon2.SetActive(false);
                incompleteIcon2.SetActive(true);
                bossSpinner2.SetActive(true);
                break;
        }
    }
}
