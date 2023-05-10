using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ThirdPersonController : MonoBehaviour
{
    Console_Game playerControls;
    public CharacterController controller;
    public Animator playerAnim;
    public Camera followCam;
    public BoulderPush boulder;
    public AudioSource jumpAudio;
    public AudioSource runAudio;

    public bool canjump;
    public bool byRock;

    public float speed = 6f;
    public float jumpSpeed = 0.5f;
    public float yDir;

    public float verticalSpeed = 0f;
    private float gravity = 20f;

    public float rotationspeed = 90f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    public bool jumpButtonPressed;

    void Awake()
    {
        playerControls = new Console_Game();

        //playerControls.Player.Jump.performed += ctx => jump();
        playerControls.Player.Jump.performed += ctx => jumpButtonPressed = true;
        playerControls.Player.Jump.canceled += ctx => jumpButtonPressed = false;
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
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = Quaternion.Euler(0, followCam.transform.eulerAngles.y, 0) * new Vector3(horizontal, 0f, vertical).normalized;

        if (controller.isGrounded)
        {
            verticalSpeed = 0;
            yDir = 0f;
            Debug.Log("grounded");
            canjump = true; 
            playerAnim.SetBool("IsJumping", false);

            if (Input.GetKey("space"))
            {
                jump();
                //yDir = jumpSpeed;
            }

            if (jumpButtonPressed == true)
            {
                jump();
            }
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
            runAudio.Play();
            playerAnim.SetFloat("Speed", 0.0f);
        }
    }

    public void jump()
    {
        if (canjump == true)
        {
                jumpAudio.Play();
                playerAnim.SetBool("IsJumping",true);
            yDir = jumpSpeed;
        }
    }


}



    ////input fields
    //private ThirdPersonControls thirdPersonControl;
    //private InputAction move;

    ////movement fields
    //private Rigidbody rb;
    //[SerializeField]
    //private float movementForce = 1f;
    //[SerializeField]
    //private float jumpForce = 5f;
    //[SerializeField]
    //private float maxSpeed = 5f;
    //private Vector3 forceDirection = Vector3.zero;

    //[SerializeField]
    //private Camera playerCamera;
    //private Animator animator;

    //private void Awake()
    //{
    //    rb = this.GetComponent<Rigidbody>();
    //    thirdPersonControl = new ThirdPersonControls();
    //    animator = this.GetComponent<Animator>();
    //}

    //private void OnEnable()
    //{
    //    thirdPersonControl.Player.Jump.started += DoJump;
    //    //thirdPersonControl.Player.Attack.started += DoAttack;
    //    move = thirdPersonControl.Player.Move;
    //    thirdPersonControl.Player.Enable();
    //}

    //private void OnDisable()
    //{
    //    thirdPersonControl.Player.Jump.started -= DoJump;
    //    //thirdPersonControl.Player.Attack.started -= DoAttack;
    //    thirdPersonControl.Player.Disable();
    //}

    //private void FixedUpdate()
    //{
    //    forceDirection += move.ReadValue<Vector2>().x * GetCameraRight(playerCamera) * movementForce;
    //    forceDirection += move.ReadValue<Vector2>().y * GetCameraForward(playerCamera) * movementForce;

    //    rb.AddForce(forceDirection, ForceMode.Impulse);
    //    forceDirection = Vector3.zero;

    //    if (rb.velocity.y < 0f)
    //        rb.velocity -= Vector3.down * Physics.gravity.y * Time.fixedDeltaTime;

    //    Vector3 horizontalVelocity = rb.velocity;
    //    horizontalVelocity.y = 0;
    //    if (horizontalVelocity.sqrMagnitude > maxSpeed * maxSpeed)
    //        rb.velocity = horizontalVelocity.normalized * maxSpeed + Vector3.up * rb.velocity.y;

    //    LookAt();
    //}

    //private void LookAt()
    //{
    //    Vector3 direction = rb.velocity;
    //    direction.y = 0f;

    //    if (move.ReadValue<Vector2>().sqrMagnitude > 0.1f && direction.sqrMagnitude > 0.1f)
    //        this.rb.rotation = Quaternion.LookRotation(direction, Vector3.up);
    //    else
    //        rb.angularVelocity = Vector3.zero;
    //}

    //private Vector3 GetCameraForward(Camera playerCamera)
    //{
    //    Vector3 forward = playerCamera.transform.forward;
    //    forward.y = 0;
    //    return forward.normalized;
    //}

    //private Vector3 GetCameraRight(Camera playerCamera)
    //{
    //    Vector3 right = playerCamera.transform.right;
    //    right.y = 0;
    //    return right.normalized;
    //}

    //private void DoJump(InputAction.CallbackContext obj)
    //{
    //    if (IsGrounded())
    //    {
    //        forceDirection += Vector3.up * jumpForce;
    //    }
    //}

    //private bool IsGrounded()
    //{
    //    Ray ray = new Ray(this.transform.position + Vector3.up * 0.25f, Vector3.down);
    //    if (Physics.Raycast(ray, out RaycastHit hit, 0.3f))
    //        return true;
    //    else
    //        return false;
    //}

    //private void DoAttack(InputAction.CallbackContext obj)
    //{
    //    animator.SetTrigger("attack");
    //}
