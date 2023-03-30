using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player_Boss_Movement : MonoBehaviour
{
    Console_Game playerControls;

    public CharacterController controller;

    //public Animator playerAnim;

    public int health;

    public bool canMove;

    public Animator anim;

    public AudioSource audioSource;
    public AudioClip attackSound;
    public AudioClip itemSound;
    public AudioClip damageSound;

    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;

    public float gravity = 20.0f;

    public float speed = 6f;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    void Awake()
    {
        playerControls = new Console_Game();

        playerControls.Player.Attack.performed += ctx => Attack();
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }

        if (canMove == true)
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

            //direction.y -= gravity;
            //direction += Physics.gravity;
            //Makes it so if the player isn't locked on they will move freely
            if (direction.magnitude >= 0.1f)
            {
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);
                anim.SetInteger("Anim_Number", 2);
                Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                controller.Move(moveDir.normalized * speed * Time.deltaTime);
            }

            if (direction.magnitude <= 0.1f)
            {
                anim.SetInteger("Anim_Number", 1);
            }


            //Applies gravity to the player
            direction.y -= gravity;

            //Moves the controller
            controller.Move(direction * Time.deltaTime);

        }


        if (health == 3)
        {
            heart1.SetActive(true);
            heart2.SetActive(true);
            heart3.SetActive(true);
        }

        if (health == 2)
        {
            heart1.SetActive(false);
            heart2.SetActive(true);
            heart3.SetActive(true);
        }

        if (health == 1)
        {
            heart1.SetActive(false);
            heart2.SetActive(false);
            heart3.SetActive(true);
        }

        if (health == 0)
        {
            heart1.SetActive(false);
            heart2.SetActive(false);
            heart3.SetActive(false);
            SceneManager.LoadScene("HUB");
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Enemy_Attack":
                loseHealth();
                break;
        }
    }

    public void Attack()
    {
        canMove = false;
        anim.SetInteger("Anim_Number", 3);
    }

    public void loseHealth()
    {
        audioSource.PlayOneShot(damageSound);
        health -= 1;
    }

    public void endAttack()
    {
        canMove = true;
        anim.SetInteger("Anim_Number", 1);
    }

    public void playAttackSound()
    {
        audioSource.PlayOneShot(attackSound);
    }
}