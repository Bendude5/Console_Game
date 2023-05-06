using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Spawn_Rocks : MonoBehaviour
{
    public GameObject rocks;
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnRocks()
    {
        GameObject rock = Instantiate(rocks, player.position, transform.rotation);
    }
}
