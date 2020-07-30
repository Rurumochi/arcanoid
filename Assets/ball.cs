using System;
using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;

public class ball : MonoBehaviour

{
    public Vector3 move,moveBoost,angle;
    public float speed;
    public bool onPlatform;
    Vector3 onPlatformPosition;
    private float k;
    


    void invertX()
    {
        move.x = move.x * -1;
        moveBoost.x = moveBoost.x * -1;
    }
    void invertY()
    {
        move.y = move.y * -1;
        moveBoost.y = moveBoost.y * -1;
    }
    void boostY()
    {
        moveBoost.y = move.y * 2;
    }
    void boostX()
    {
        moveBoost.x = move.x * 2;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "leftwall" || other.gameObject.name == "rightwall")
        {
            invertX();
        }
        if (other.gameObject.name == "wallup")
            invertY();
        if (other.gameObject.name == "platform")
        {
            invertY();
            if (Input.GetKey("a"))
                moveBoost.x = -1;

            if (Input.GetKey("d"))
                moveBoost.x = 1;

            if (GameObject.Find("platform").GetComponent<platform>().stickyPlatform == true)
            {
                onPlatform = true;
                move.x = 0;
                print("0");
            }

         }
         if (other.gameObject.name == "brick(Clone)")
         {
            
            if (other.gameObject.transform.position.x - 20 <= transform.position.x && other.gameObject.transform.position.x + 20 >= transform.position.x)
            {
                invertY();
                boostY();
            }

            else
            {
                if (other.gameObject.transform.position.y - 10 <= transform.position.y && other.gameObject.transform.position.y + 10 >= transform.position.y)
                {
                    invertX();
                    boostX();
                }
                else
                {
                    angle = (transform.position - other.gameObject.transform.position).normalized;
                    move.x = angle.x ;
                    moveBoost.x = angle.x ;
                    move.y = angle.y ;
                    moveBoost.y = angle.y ;                   
                }
            }

         }
        if (other.gameObject.name == "misswall")
        {
            onPlatform = true;
            GameObject.Find("platform").GetComponent<platform>().stickyPlatform = true;
            move.x = 0;

        }

    }

    void Start()
    {
        onPlatform = true;
        onPlatformPosition = new Vector3(0, 0, 0);
        Debug.Log(onPlatformPosition);
        onPlatformPosition = transform.position - GameObject.Find("platform").transform.position;
        Debug.Log(onPlatformPosition);
        speed = 200f;
        k = 0;
    }

    void Update()
    {
        if (GameObject.Find("platform").GetComponent<platform>().stickyPlatform == true && onPlatform == true)
        {
            transform.position = GameObject.Find("platform").transform.position + onPlatformPosition;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                move.y = Convert.ToSingle(Math.Cos(Math.PI * 45 / 180));
                if (Input.GetKey("a"))
                {
                    move.x = -Convert.ToSingle(Math.Cos(Math.PI * 45 / 180));
                }
                if (Input.GetKey("d"))
                {
                    move.x = Convert.ToSingle(Math.Cos(Math.PI * 45 / 180));
                }
                moveBoost = move;
                onPlatform = false;
                GameObject.Find("platform").GetComponent<platform>().stickyPlatform = false;
                
            }
        }
        else
        {
            transform.Translate((move + moveBoost) / 2 * Time.deltaTime * speed);
            k = k + Time.deltaTime;
            if (k > 1)
            {
                moveBoost = (move + moveBoost) / 2;
                k = 0;
            }
        }
    }
}
