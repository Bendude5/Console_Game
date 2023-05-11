using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Game_Load : MonoBehaviour
{
    Console_Game playerControls;

    void Awake()
    {
        playerControls = new Console_Game();

        playerControls.Player.Resume.performed += ctx => loadScene();

        playerControls.Player.Quit.performed += ctx => exitGame();
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
        if (Input.GetKeyDown(KeyCode.A))
        {
            this.loadScene();
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            this.exitGame();
        }
    }

    public void loadScene()
    {
        SceneManager.LoadScene("Cutscene");
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
