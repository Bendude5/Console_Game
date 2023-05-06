using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.AI;
using System.Collections;
 
public class MONKE_PATROL : MonoBehaviour
{
    public float wanderRadius;
    public float wanderTimer;
    GameObject player;
    private Vector3 targetPoint;
    private Quaternion targetRotation;

    public Animator anim;

    private Transform target;
    private NavMeshAgent agent;
    private float timer;

    public bool byPlayer;
    public GameObject text;
    public GameObject textBackground;

    public bool infoMonkey;

    public int monkeyNumber;
    public 

    // Use this for initialization
    void OnEnable()
    {
        player = GameObject.Find("Player");
        agent = GetComponent<NavMeshAgent>();
        timer = wanderTimer;
    }

    // Update is called once per frame
    void Update()
    {
        if (byPlayer == false)
        {
            text.GetComponent<TextMeshProUGUI>().text = " ";

            textBackground.SetActive(false);

            if (agent.velocity == Vector3.zero)
            {
                anim.SetInteger("Anim_Number", 1);
            }

            if (agent.velocity != Vector3.zero)
            {
                anim.SetInteger("Anim_Number", 2);
            }

            if (infoMonkey == false)
            {
                timer += Time.deltaTime;

                if (timer >= wanderTimer)
                {
                    Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
                    agent.SetDestination(newPos);
                    timer = 0;
                }
            }
        }

        if (byPlayer == true )
        {
            //anim.SetInteger("Anim_Number", 1);

            transform.LookAt(player.transform);

            Vector3 eulerAngles = transform.rotation.eulerAngles;
            eulerAngles.x = 0;
            eulerAngles.z = 0;

            transform.rotation = Quaternion.Euler(eulerAngles);

            agent.SetDestination(this.transform.position);

            if (infoMonkey == false)
            {
                anim.SetInteger("Anim_Number", 3);
            }

            if (infoMonkey == true)
            {
                anim.SetInteger("Anim_Number", 4);
            }


            displayText();
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

    public void displayText()
    {
        textBackground.SetActive(true);

        if (monkeyNumber == 1)
        {
            text.GetComponent<TextMeshProUGUI>().text = "I don't know what happened! Those machines just fell from the sky!";
        }

        if (monkeyNumber == 2)
        {
            text.GetComponent<TextMeshProUGUI>().text = "The only way to sort out these machines, is to go inside!";
        }

        if (monkeyNumber == 3)
        {
            text.GetComponent<TextMeshProUGUI>().text = "This one looks scary! It looks like it has 2 seals, perhaps the other machines are creating them!";
        }

        if (monkeyNumber == 4)
        {
            text.GetComponent<TextMeshProUGUI>().text = "Hello there";
        }

        if (monkeyNumber == 5)
        {
            text.GetComponent<TextMeshProUGUI>().text = "How do you do?";
        }

        if (monkeyNumber == 6)
        {
            text.GetComponent<TextMeshProUGUI>().text = "What a lovely day";
        }

        if (monkeyNumber == 7)
        {
            text.GetComponent<TextMeshProUGUI>().text = "Some nasty goblins from the other machines came into this one! Be careful in there, there are no weapons!";
        }
    }
}