using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Slam : MonoBehaviour
{
    public Transform[] firePoints;
    public GameObject bulletPrefab;
    public float bulletForce = 20f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void shootSlam(int firePointNumber)
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoints[firePointNumber].position, transform.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(firePoints[firePointNumber].up * bulletForce, ForceMode.Impulse);
    }
}
