using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enter_Arcade : MonoBehaviour
{
    public GameObject arcade1;

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
            case "Arcade_Machine_1":
                if(Input.GetKey(KeyCode.E))
                {
                    arcade1.GetComponent<Animator>().SetInteger("Anim_Number", 1);
                    Debug.Log("Entererd arcade");
                }
                break;
        }
    }

}
