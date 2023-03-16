using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Enter_Arcade : MonoBehaviour
{
    public GameObject arcade1;
    public GameObject arcade2;
    public GameObject arcade3;

    public GameObject player;

    //public ButtonControl this[GamepadButton button] { get; }

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
                //if(Input.GetKey(KeyCode.E))
                //if(InputControl.Gamepad.leftStick.x)
                {
                    arcade1.GetComponent<Animator>().SetInteger("Anim_Number", 1);
                    player.GetComponent<Movement>().enteringArcade = true;
                    Debug.Log("Entered arcade 1");
                }
                break;

            case "Arcade_Machine_2":
                if (Input.GetKey(KeyCode.E))
                {
                    arcade2.GetComponent<Animator>().SetInteger("Anim_Number", 1);
                    player.GetComponent<Movement>().enteringArcade = true;
                    Debug.Log("Entered arcade 2");
                }
                break;

            case "Arcade_Machine_3":
                if (Input.GetKey(KeyCode.E))
                {
                    arcade3.GetComponent<Animator>().SetInteger("Anim_Number", 1);
                    player.GetComponent<Movement>().enteringArcade = true;
                    Debug.Log("Entered arcade 3");
                }
                break;
        }
    }

}
