using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterController controller;
    public Animator playerAnim;

    public float speed = 6f;
    public float jumpSpeed = 0.5f;
    private float yDir;

    public float verticalSpeed = 0f;
    private float gravity = 20f;

    public float rotationspeed = 90f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    public bool enteringArcade;

    void Update()
    {
        if (enteringArcade == false)
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");

            Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;


            if (controller.isGrounded)
            {
                verticalSpeed = 0;
                yDir = 0f;
                Debug.Log("grounded");

                if (Input.GetKey("space"))
                {
                    yDir = jumpSpeed;
                }
            }
            else
            {
                verticalSpeed -= gravity * Time.deltaTime;
                Debug.Log("not grounded");
            }


            yDir += Physics.gravity.y * Time.deltaTime;
            direction.y = yDir;


            Vector3 gravityMove = new Vector3(0, verticalSpeed, 0);
            controller.Move(gravityMove * Time.deltaTime);

            if (direction.magnitude >= 0.1f)
            {
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);
                playerAnim.SetFloat("Speed", 1.0f);
                Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                controller.Move(direction * speed * Time.deltaTime);

            }
            else
            {
                playerAnim.SetFloat("Speed", 0.0f);
            }
        }
    }
}