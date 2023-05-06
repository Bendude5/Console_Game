using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Enter_Arcade : MonoBehaviour
{
    Console_Game playerControls;
    public GameObject arcade1;
    public GameObject arcade2;
    public GameObject arcade3;

    public bool byArcade1;
    public bool byArcade2;
    public bool byArcade3;

    public GameObject player;

    //public ButtonControl this[GamepadButton button] { get; }

    void Awake()
    {
        playerControls = new Console_Game();

        playerControls.Player.Interact.performed += ctx => enterArcade();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            enterArcade();
        }
    }

    void OnEnable()
    {
        playerControls.Player.Enable();
    }

    void OnDisable()
    {
        playerControls.Player.Disable();
    }

    public void enterArcade()
    {
        if (byArcade1 == true)
        {
            arcade1.GetComponent<Animator>().SetInteger("Anim_Number", 1);
            player.GetComponent<Movement>().enteringArcade = true;
            
            Debug.Log("Entered arcade 1");
        }

        if (byArcade2 == true)
        {
            arcade2.GetComponent<Animator>().SetInteger("Anim_Number", 1);
            player.GetComponent<Movement>().enteringArcade = true;
            Debug.Log("Entered arcade 2");
        }

        if (byArcade3 == true)
        {
            arcade3.GetComponent<Animator>().SetInteger("Anim_Number", 1);
            player.GetComponent<Movement>().enteringArcade = true;
            Debug.Log("Entered arcade 3");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        switch (other.name)
        {
            case "Arcade_Machine_1":
                byArcade1 = true;
                break;

            case "Arcade_Machine_2":
                byArcade2 = true;
                break;

            case "Arcade_Machine_3":
                byArcade3 = true;
                break;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        switch (other.name)
        {
            case "Arcade_Machine_1":
                byArcade1 = false;
                break;

            case "Arcade_Machine_2":
                byArcade2 = false;
                break;

            case "Arcade_Machine_3":
                byArcade3 = false;
                break;
        }
    }

}
