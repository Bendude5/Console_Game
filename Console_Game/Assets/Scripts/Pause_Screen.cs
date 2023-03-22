using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Pause_Screen : MonoBehaviour
{
    Console_Game playerControls;

    public string exitScene;

    public GameObject pauseMenu;


    void Awake()
    {
        playerControls = new Console_Game();

        playerControls.Player.Resume.performed += ctx => resume();

        playerControls.Player.Quit.performed += ctx => exit();
    }

    void OnEnable()
    {
        playerControls.Player.Enable();
    }

    void OnDisable()
    {
        playerControls.Player.Disable();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            resume();
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            exit();
        }
    }

    public void resume()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }

    public void exit()
    {
        SceneManager.LoadScene(exitScene);
    }
}
