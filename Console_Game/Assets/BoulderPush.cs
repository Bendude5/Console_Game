using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderPush : MonoBehaviour
{
    public GameObject lava;

    public void PlayAnim()
    {
        
    }

    public void LavaBlock()
    {
        lava.SetActive(false);
    }
}
