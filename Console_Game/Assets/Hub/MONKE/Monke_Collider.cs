using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monke_Collider : MonoBehaviour
{
    public GameObject monkey;
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
        switch (other.name)
        {
            case "Player":
                monkey.GetComponent<MONKE_PATROL>().byPlayer = true;
                break;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        switch (other.name)
        {
            case "Player":
                monkey.GetComponent<MONKE_PATROL>().byPlayer = false;
                break;
        }
    }
}
