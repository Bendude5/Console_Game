using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Sphere : MonoBehaviour
{
    public bool attacking;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            attacking = true;
            Debug.Log("Collided");
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            attacking = false;
            Debug.Log("Not Collided");
        }
    }
}