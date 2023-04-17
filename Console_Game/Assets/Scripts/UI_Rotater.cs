using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Rotater : MonoBehaviour
{
    //All the objects for the player cameras
    GameObject playerCameraObject;
    Transform playerCamera;

    void Start()
    {

    }

    void Update()
    {
        //Looks at the unlocked on camera
        transform.LookAt(playerCamera);

        //Sets the object to the player camera
        playerCameraObject = GameObject.Find("Main Camera");
        playerCamera = playerCameraObject.GetComponent<Transform>();

        //Vector3 eulerAngles = transform.rotation.eulerAngles;
        //eulerAngles.x = 0;
        //eulerAngles.z = 0;

        //// Set the altered rotation back
        //transform.rotation = Quaternion.Euler(eulerAngles);
    }
}