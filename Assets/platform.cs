using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class platform : MonoBehaviour
{
    public bool stickyPlatform;
    public float speed;
    public Transform bullet;
    public float ammo, noAmmo;
    private bool stopLeft, stopRight, turret;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "leftwall")
            stopLeft = true;
        if (other.gameObject.name == "rightwall")
            stopRight = true;
        if (other.gameObject.name == "bonus(Clone)") 
        {
            if (other.gameObject.GetComponent<bonus>().bonusType == "green")
                stickyPlatform = true;
            if (other.gameObject.GetComponent<bonus>().bonusType == "red")
                turret = true;
        }
    }


void Start()
    {
        stickyPlatform = true;
        speed = 200;
        ammo = 0;
        noAmmo = 0;
        turret = false;

    }

// Update is called once per frame

    void Update()
    {
        if (Input.GetKey("a") && stopLeft == false)
        {
            transform.Translate(0,speed * Time.deltaTime, 0);
            stopRight = false;
        }
        if (Input.GetKey("d") && stopRight == false)
        {
            transform.Translate(0,-speed * Time.deltaTime, 0);
            stopLeft = false;
        }
        if (turret == true)
        {
            if (ammo <= 2)
            {
                if(noAmmo * 0.34 <= ammo)
                {
                    Instantiate(bullet, transform.position, Quaternion.identity);
                    noAmmo = noAmmo + 1;
                }
                ammo = ammo + Time.deltaTime;
            }
            if (ammo > 2)
            {
                ammo = 0;
                noAmmo = 0;
                turret = false;
            }

        }


    }
}
