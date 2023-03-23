using UnityEngine;
using UnityEngine.AI;
using System.Collections;
 
public class MONKE_PATROL : MonoBehaviour
{

    public float wanderRadius;
    public float wanderTimer;

    public Animator anim;

    private Transform target;
    private NavMeshAgent agent;
    private float timer;

    // Use this for initialization
    void OnEnable()
    {
        agent = GetComponent<NavMeshAgent>();
        timer = wanderTimer;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= wanderTimer)
        {
            Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
            agent.SetDestination(newPos);
            timer = 0;
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

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;

        randDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;
    }
}