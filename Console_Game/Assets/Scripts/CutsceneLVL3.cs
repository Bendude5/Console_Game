using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CutsceneLVL3 : MonoBehaviour
{
    public Camera mainCam;
    public Camera introCam;

    public GameObject UI;

    public Animator anim;

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
        anim = GetComponent<Animator>();

        anim.Play("Scene 3 Intro", 0, 0);
        mainCam.gameObject.SetActive(false);
        introCam.gameObject.SetActive(true);
        UI.SetActive(false);
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
        mainCam.gameObject.SetActive(true);
        introCam.gameObject.SetActive(false);
        UI.SetActive(true);
    }
}
