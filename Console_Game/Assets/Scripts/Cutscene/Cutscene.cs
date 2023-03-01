using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cutscene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            this.finishCutscene();
        }
    }

    //This function does exactly what it says it does
    public void finishCutscene()
    {
        SceneManager.LoadScene("HUB");
    }
}
