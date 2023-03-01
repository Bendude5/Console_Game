using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        
            gameObject.SetActive(false);
            Debug.Log("Collected");
        
    }
}
