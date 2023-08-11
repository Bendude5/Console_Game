using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Movement : MonoBehaviour
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
        yPosition = 9.43f;
        zPosition = player.position.z - 7.890015f;

    }
}