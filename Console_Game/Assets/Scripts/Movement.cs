using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterController controller;
    public Animator playerAnim;

    private Vector3 direction;

    public float speed = 6f;
    public float rotationspeed = 90f;
    private float gravity = -20f; 

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;   


    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        direction.x = horizontal * speed;
        direction.z = vertical * speed;

        if (direction.magnitude >= 0.1f)
        {

            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            playerAnim.SetFloat("Speed", 1.0f);

            
            controller.Move(direction * Time.deltaTime);

        }
        else
        {
            playerAnim.SetFloat("Speed", 0.0f);
        }


        //float horizontal = Input.GetAxis("Horizontal");
        //float vertical = Input.GetAxis("Vertical");

        //if (controller.isGrounded)
            //{
            //    direction = transform.forward * speed * vertical;
            //    turnVelocity = transform.up * rotationspeed * horizontal;            
            //}
            //direction.y += gravity * Time.deltaTime;
        
        //controller.Move(moveVelocity * Time.deltaTime);
        //transform.Rotate(turnVelocity * Time.deltaTime);
    }


}