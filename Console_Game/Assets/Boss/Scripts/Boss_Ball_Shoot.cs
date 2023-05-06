using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Ball_Shoot : MonoBehaviour
{
    public Transform firePoint1;
    public Transform firePoint2;
    public Transform firePoint3;
    public Transform firePoint4;
    public Transform firePoint5;

    public int goodBulletNumber;

    //public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject goodBulletPrefab;

    public GameObject bulletTelegraph;
    public GameObject goodBulletTelegraph;
    //public Transform enemy;

    public float bulletForce = 20f;

    public void telegraph()
    {
        goodBulletNumber = Random.Range(1, 6);

        if (goodBulletNumber == 1)
        {
            GameObject bullet = Instantiate(goodBulletTelegraph, firePoint1.position, transform.rotation);
        }
        else
        {
            GameObject bullet = Instantiate(bulletTelegraph, firePoint1.position, transform.rotation);
        }

        if (goodBulletNumber == 2)
        {
            GameObject bullet2 = Instantiate(goodBulletTelegraph, firePoint2.position, transform.rotation);
        }
        else
        {
            GameObject bullet2 = Instantiate(bulletTelegraph, firePoint2.position, transform.rotation);
        }

        if (goodBulletNumber == 3)
        {
            GameObject bullet3 = Instantiate(goodBulletTelegraph, firePoint3.position, transform.rotation);
        }
        else
        {
            GameObject bullet3 = Instantiate(bulletTelegraph, firePoint3.position, transform.rotation);
        }

        if (goodBulletNumber == 4)
        {
            GameObject bullet4 = Instantiate(goodBulletTelegraph, firePoint4.position, transform.rotation);
        }
        else
        {
            GameObject bullet4 = Instantiate(bulletTelegraph, firePoint4.position, transform.rotation);
        }

        if (goodBulletNumber == 5)
        {
            GameObject bullet5 = Instantiate(goodBulletTelegraph, firePoint5.position, transform.rotation);
        }
        else
        {
            GameObject bullet5 = Instantiate(bulletTelegraph, firePoint5.position, transform.rotation);
        }
    }

    public void Shoot()
    {
        if (goodBulletNumber == 1)
        {
            GameObject bullet = Instantiate(goodBulletPrefab, firePoint1.position, transform.rotation);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.AddForce(firePoint1.up * bulletForce, ForceMode.Impulse);
        }
        else
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint1.position, transform.rotation);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.AddForce(firePoint1.up * bulletForce, ForceMode.Impulse);
        }



        if (goodBulletNumber == 2)
        {
            GameObject bullet2 = Instantiate(goodBulletPrefab, firePoint2.position, transform.rotation);
            Rigidbody rb2 = bullet2.GetComponent<Rigidbody>();
            rb2.AddForce(firePoint2.up * bulletForce, ForceMode.Impulse);
        }
        else
        {
            GameObject bullet2 = Instantiate(bulletPrefab, firePoint2.position, transform.rotation);
            Rigidbody rb2 = bullet2.GetComponent<Rigidbody>();
            rb2.AddForce(firePoint2.up * bulletForce, ForceMode.Impulse);
        }



        if (goodBulletNumber == 3)
        {
            GameObject bullet3 = Instantiate(goodBulletPrefab, firePoint3.position, transform.rotation);
            Rigidbody rb3 = bullet3.GetComponent<Rigidbody>();
            rb3.AddForce(firePoint3.up * bulletForce, ForceMode.Impulse);
        }
        else
        {
            GameObject bullet3 = Instantiate(bulletPrefab, firePoint3.position, transform.rotation);
            Rigidbody rb3 = bullet3.GetComponent<Rigidbody>();
            rb3.AddForce(firePoint3.up * bulletForce, ForceMode.Impulse);
        }



        if (goodBulletNumber == 4)
        {
            GameObject bullet4 = Instantiate(goodBulletPrefab, firePoint4.position, transform.rotation);
            Rigidbody rb4 = bullet4.GetComponent<Rigidbody>();
            rb4.AddForce(firePoint4.up * bulletForce, ForceMode.Impulse);
        }
        else
        {
            GameObject bullet4 = Instantiate(bulletPrefab, firePoint4.position, transform.rotation);
            Rigidbody rb4 = bullet4.GetComponent<Rigidbody>();
            rb4.AddForce(firePoint4.up * bulletForce, ForceMode.Impulse);
        }



        if (goodBulletNumber == 5)
        {
            GameObject bullet5 = Instantiate(goodBulletPrefab, firePoint5.position, transform.rotation);
            Rigidbody rb5 = bullet5.GetComponent<Rigidbody>();
            rb5.AddForce(firePoint5.up * bulletForce, ForceMode.Impulse);
        }
        else
        {
            GameObject bullet5 = Instantiate(bulletPrefab, firePoint5.position, transform.rotation);
            Rigidbody rb5 = bullet5.GetComponent<Rigidbody>();
            rb5.AddForce(firePoint5.up * bulletForce, ForceMode.Impulse);
        }

    }
}
