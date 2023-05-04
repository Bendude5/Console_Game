using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderPush : MonoBehaviour
{
    public GameObject lava;
    public Animator anim;

    void Start()
    {
        anim.enabled = false;
    }

    public void PlayAnim()
    {
        anim.enabled = true;
    }

    public void LavaBlock()
    {
        lava.SetActive(false);
    }
}
