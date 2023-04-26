using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Ball : MonoBehaviour
{
    public bool isBad;

    public bool deflected;

    Transform boss;
    GameObject bossOject;
    public Vector3 moveDirection;
    public float speed = 1.0f;
    public Rigidbody rb;

    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        bossOject = GameObject.Find("Head_Pivot");
        boss = bossOject.transform;

        if (deflected == true)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            transform.LookAt(boss);
            moveDirection = new Vector3(boss.transform.position.x, boss.transform.position.y, boss.transform.position.z);
            //rb.MovePosition(transform.position + speed * moveDirection * Time.deltaTime);

            rb.velocity = (moveDirection - transform.position).normalized * speed;
        }
    }

    public void deleteBall()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.name)
        {
            case "Player_Sword":
                if (isBad == false)
                {
                    deflected = true;
                }
                break;

            case "Head_Bottom":
                if (isBad == false)
                {
                    Destroy(gameObject);
                }
                break;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        switch (other.tag)
        {
            case "Player":
                if (isBad == true)
                {
                    GameObject.Find("Player").GetComponent<Player_Boss_Movement>().loseHealth();
                    Destroy(gameObject);
                }
                break;
        }
    }
}
