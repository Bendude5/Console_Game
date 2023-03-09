using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterController controller;
    public Animator playerAnim;
    public Camera followCam;

    public float speed = 6f;
    public float jumpSpeed = 0.5f;
    private float yDir;

    public float verticalSpeed = 0f;
    private float gravity = 20f;

    public float rotationspeed = 90f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    private bool isGrounded;
    private bool isJumping;

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = Quaternion.Euler(0, followCam.transform.eulerAngles.y, 0) * new Vector3(horizontal, 0f, vertical).normalized;


        if (controller.isGrounded)
        {
            verticalSpeed = 0;
            yDir = 0f;
            playerAnim.SetBool("IsGrounded", true);
            isGrounded = true;
            playerAnim.SetBool("IsJumping", false);
            isJumping = false;
            playerAnim.SetBool("IsFalling", false);

            if (Input.GetKey("space"))
            {
                yDir = jumpSpeed;
                playerAnim.SetBool("IsJumping", true);
                isJumping = true;
            }
        }
        else
        {
            verticalSpeed -= gravity * Time.deltaTime;
            playerAnim.SetBool("IsGrounded", false);
            isGrounded = false;

            if((isJumping && jumpSpeed < 0))
            {
                playerAnim.SetBool("IsFalling", true);
            }
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
            playerAnim.SetBool("IsMoving", true);

            controller.Move(direction * speed * Time.deltaTime);

        }
        else
        {
            playerAnim.SetBool("IsMoving", false);
        }
    }


}


