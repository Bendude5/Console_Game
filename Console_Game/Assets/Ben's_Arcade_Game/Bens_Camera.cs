using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bens_Camera : MonoBehaviour
{

    public Transform player;
    public Vector3 cameraPos;

    public float xPosition;
    public float yPosition;
    public float zPosition;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        cameraPos = transform.position;

        transform.position = new Vector3(xPosition, yPosition, zPosition);

        xPosition = player.position.x;
        yPosition = 42;
        zPosition = player.position.z;

    }
}