using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    Console_Game playerControls;
    public CharacterController controller;
    public Animator playerAnim;
    public Camera followCam;

    public bool canjump;

    public int sceneNum;

    public float speed = 6f;
    public float jumpSpeed = 0.5f;
    private float yDir;

    public float verticalSpeed = 0f;
    private float gravity = 20f;

    public float rotationspeed = 90f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    public bool enteringArcade;

    public bool jumpButtonPressed;
    //public bool jumpButtonDown;

    void Awake()
    {
        playerControls = new Console_Game();

        //playerControls.Player.Jump.performed += ctx => jump();
        playerControls.Player.Jump.performed += ctx => jumpButtonPressed = true;
        playerControls.Player.Jump.canceled += ctx => jumpButtonPressed = false;
    }

    void Start()
    {

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
        if (enteringArcade == false)
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");

            Vector3 direction = Quaternion.Euler(0, followCam.transform.eulerAngles.y, 0) * new Vector3(horizontal, 0f, vertical).normalized;


            if (controller.isGrounded)
            {
                verticalSpeed = 0;
                yDir = 0f;
                Debug.Log("grounded");
                canjump = true;

                if (Input.GetKey("space"))
                {
                    jump();
                    //yDir = jumpSpeed;
                }

                if (jumpButtonPressed == true)
                {
                    jump();
                }

                //if (Input.GetButton("Jump"))
                //{
                //    jump();
                //    //yDir = jumpSpeed;
                //}

            }
            else
            {
                canjump = false;
                verticalSpeed -= gravity * Time.deltaTime;
                Debug.Log("not grounded");
            }


            yDir += Physics.gravity.y * Time.deltaTime;
            direction.y = yDir;


            Vector3 gravityMove = new Vector3(0, verticalSpeed, 0);
            controller.Move(gravityMove * Time.deltaTime);

            if (direction.magnitude >= 1f)
            {
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);
                playerAnim.SetFloat("Speed", 1.0f);

                controller.Move(direction * speed * Time.deltaTime);

            }
            else
            {
                playerAnim.SetFloat("Speed", 0.0f);
            }
        }
    }

    public void jump()
    {
        if (canjump == true)
        {
            yDir = jumpSpeed;
        }
    }
}