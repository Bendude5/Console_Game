using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Enemy_Movement : MonoBehaviour
{
    private NavMeshAgent agent;
    Transform player;
    public float speed;
    public float chaseSpeed;
    public bool canMove;
    public GameObject detectionSphere;
    public GameObject attackSphere;

    public Animator anim;

    Vector3 playerLocation;

    public bool chasingPlayer;
    //public GameObject detectionSphere;
    public float wanderRadius;
    public float wanderTimer;

    private Transform target;
    private float timer;

    // Use this for initialization
    void OnEnable()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        timer = wanderTimer;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove == true)
        {
            if (detectionSphere.GetComponent<DetectionSphere>().playerDetected == false)
            {
                if (attackSphere.GetComponent<Attack_Sphere>().attacking == false)
                {
                    //agent.velocity = Vector3.one;
                    //agent.isStopped = false;
                    agent.speed = speed;
                    timer += Time.deltaTime;
                    if (timer >= wanderTimer)
                    {
                        //anim.SetInteger("Anim_Number", 1);
                        Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
                        agent.SetDestination(newPos);
                        timer = 0;

                        //if (agent.transform.position == newPos)
                        //{
                        //    Debug.Log("NotArrived");
                        //}
                    }

                    if (agent.velocity == Vector3.zero)
                    {
                        anim.SetInteger("Anim_Number", 1);
                    }

                    if (agent.velocity != Vector3.zero)
                    {
                        anim.SetInteger("Anim_Number", 2);
                    }
                }
            }

            if (detectionSphere.GetComponent<DetectionSphere>().playerDetected == true)
            {
                if (attackSphere.GetComponent<Attack_Sphere>().attacking == false)
                {
                    //agent.velocity = Vector3.one;
                    //agent.isStopped = false;

                    playerLocation.x = player.position.x;
                    playerLocation.y = player.position.y;
                    playerLocation.z = player.position.z;

                    agent.SetDestination(playerLocation);

                    agent.speed = chaseSpeed;

                    if (agent.velocity == Vector3.zero)
                    {
                        anim.SetInteger("Anim_Number", 1);
                    }

                    if (agent.velocity != Vector3.zero)
                    {
                        anim.SetInteger("Anim_Number", 3);
                    }
                }
            }

            if (attackSphere.GetComponent<Attack_Sphere>().attacking == true)
            {
                agent.velocity = Vector3.zero;
                //agent.speed = 0;
                //agent.velocity = Vector3.zero;
                //agent.isStopped = true;
                anim.SetInteger("Anim_Number", 4);
            }

            if (attackSphere.GetComponent<Attack_Sphere>().attacking == false)
            {
                //agent.velocity = Vector3.one;
                //agent.isStopped = false;
            }
        }
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;

        randDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;
    }
}