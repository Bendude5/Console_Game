using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    public void Explode()
    {
        gameObject.SetActive(false);
        Invoke("Reset", 2f);            
    }

    public void Reset()
    {
        gameObject.SetActive(true);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject.Find("Player").GetComponent<PlayerProgress>().health -= 1;
            //Destroy(gameObject);
        }
    }
}
