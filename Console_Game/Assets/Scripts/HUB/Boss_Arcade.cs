using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Arcade : MonoBehaviour
{
    ProgressManager progress;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        switch (other.name)
        {
            case "Player":
                Debug.Log("Cheese");
                break;
        }
    }
}
