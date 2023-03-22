using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Cutscene : MonoBehaviour
{
    Console_Game playerControls;

    void Awake()
    {
        playerControls = new Console_Game();

        playerControls.Player.Attack.performed += ctx => finishCutscene();
    }

    void OnEnable()
    {
        playerControls.Player.Enable();
    }

    void OnDisable()
    {
        playerControls.Player.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            this.finishCutscene();
        }
    }

    //This function does exactly what it says it does
    public void finishCutscene()
    {
        SceneManager.LoadScene("HUB");
    }
}
