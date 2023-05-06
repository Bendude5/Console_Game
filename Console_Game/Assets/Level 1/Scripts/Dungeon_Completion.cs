using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dungeon_Completion : MonoBehaviour
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

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Player":
                if(GameObject.Find("Player").GetComponent<Bens_Movement>().keys >= 5)
                {
                    progress.level1Complete = true;
                    SceneManager.LoadScene("HUB");
                }
                break;
        }
    }
}
