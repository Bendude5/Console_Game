using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Player : MonoBehaviour
{
    [SerializeField]
    ProgressManager progress;

    public bool inHUB;

    public void spawn()
    {
        if (inHUB == true)
        {
            if (progress.LastLevel == 0)
            {
                gameObject.transform.position = new Vector3(529, 1, 453);
                Debug.Log("Area 1");
            }

            else if (progress.LastLevel == 1)
            {
                gameObject.transform.position = new Vector3(518, 1, 465);
                Debug.Log("Area 2");
            }

            else if (progress.LastLevel == 2)
            {
                gameObject.transform.position = new Vector3(535, 2, 489);
                Debug.Log("Area 3");
            }

            else if (progress.LastLevel == 3)
            {
                gameObject.transform.position = new Vector3(504, 1, 506);
                Debug.Log("Boss Area");
            }
        }
    }
}
