using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Arcades : MonoBehaviour
{
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("Boss").GetComponent<Boss_States>().bossState == 1)
        {
            anim.SetInteger("Anim_Number", 1);
        }

        if (GameObject.Find("Boss").GetComponent<Boss_States>().bossState == 2)
        {
            anim.SetInteger("Anim_Number", 2);
        }

        if (GameObject.Find("Boss").GetComponent<Boss_States>().bossState == 3)
        {
            anim.SetInteger("Anim_Number", 3);
        }
    }
}
