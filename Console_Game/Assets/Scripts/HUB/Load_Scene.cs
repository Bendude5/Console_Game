using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load_Scene : MonoBehaviour
{
    public GameObject player;
    public GameObject popupUI;

    public float arcadeDistance;

    ProgressManager progress;

    // Start is called before the first frame update
    void Start()
    {
        popupUI.SetActive(false);
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        arcadeDistance = Vector3.Distance(this.gameObject.transform.position, player.transform.position);
        if (arcadeDistance < 3.5)
        {
            popupUI.SetActive(true);
        }
        else if(arcadeDistance > 3.5)
        {
            popupUI.SetActive(false);
        }
    }

    void loadScene()
    {
        switch (gameObject.name)
        {
            case "Arcade_Machine_1":
                //progress.lastLevel = 1;
                SceneManager.LoadScene("Level 1");
                break;

            case "Arcade_Machine_2":
                SceneManager.LoadScene("Level 2");
                break;

            //case "Arcade_Machine_3":
            //    //progress.lastLevel = 2;
            //    SceneManager.LoadScene("Arcade_Game3");
            //    break;

            case "Boss_Machine":
                SceneManager.LoadScene("Boss_Cutscene");
                break;
        }
    }
}
