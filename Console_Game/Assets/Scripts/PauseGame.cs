using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseGame : MonoBehaviour
{
    Console_Game playerControls;

    public GameObject pauseMenu;

    void Awake()
    {
        playerControls = new Console_Game();

        playerControls.Player.Pause.performed += ctx => pauseGame();
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
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseGame();
        }
    }

    public void pauseGame()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }

    //public void resumeGame()
    //{
    //    Time.timeScale = 1;
    //    pauseMenu.SetActive(false);
    //}
}
