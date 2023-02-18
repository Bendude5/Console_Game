using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bens_Movement : MonoBehaviour
{
    public CharacterController controller;

    //public Animator playerAnim;

    public int health;

    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;

    public int keys;

    public GameObject key1;
    public GameObject key2;
    public GameObject key3;

    public float speed = 6f;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            //playerAnim.SetFloat("Speed", 1.0f);
            controller.Move(direction * speed * Time.deltaTime);
        }
        else
        {
            //playerAnim.SetFloat("Speed", 0.0f);
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
        }




        if (keys == 0)
        {
            key1.SetActive(false);
            key2.SetActive(false);
            key3.SetActive(false);
        }

        if (keys == 1)
        {
            key1.SetActive(true);
            key2.SetActive(false);
            key3.SetActive(false);
        }

        if (keys == 2)
        {
            key1.SetActive(true);
            key2.SetActive(true);
            key3.SetActive(false);
        }

        if (keys == 3)
        {
            key1.SetActive(true);
            key2.SetActive(true);
            key3.SetActive(true);
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

    public void loseHealth()
    {
        health -= 1;
    }

    public void addKey()
    {
        keys += 1;
    }
}