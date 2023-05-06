using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_1_Complete : MonoBehaviour
{
    [SerializeField]
    ProgressManager progress;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void dungeonCompletion()
    {
        progress.level1Complete = true;
        SceneManager.LoadScene("HUB");
    }
}
