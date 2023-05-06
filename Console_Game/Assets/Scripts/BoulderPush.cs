using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderPush : MonoBehaviour
{
    public GameObject lava;
    public GameObject rockBase;
    public Animator anim;

    void Start()
    {
        anim.enabled = false;
    }

    public void LavaBlock()
    {
        lava.SetActive(false);
        rockBase.SetActive(true);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            anim.enabled = true;

        }
    }

}
