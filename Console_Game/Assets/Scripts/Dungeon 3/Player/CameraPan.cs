using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPan : MonoBehaviour
{
    public Camera cameraObj;
    public GameObject player;

    private Vector3 previousPos;

    // Update is called once per frame
    void Update()
    {
        RotateCamera();
    }

    void RotateCamera()
    {
        cameraObj.transform.position = player.transform.position;

        if (Input.GetMouseButtonDown(0))
        {
            previousPos = cameraObj.ScreenToViewportPoint(Input.mousePosition);
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 direction = previousPos - cameraObj.ScreenToViewportPoint(Input.mousePosition);

            cameraObj.transform.Rotate(new Vector3(1, 0, 0), direction.y * 180);
            cameraObj.transform.Rotate(new Vector3(0, 1, 0), -direction.x * 180, Space.World);

            previousPos = cameraObj.ScreenToViewportPoint(Input.mousePosition);
        }

        cameraObj.transform.Translate(new Vector3(0, 1, -6));
    }
}
