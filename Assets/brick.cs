using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class brick : MonoBehaviour
{
    public int hitPoint;
    public Transform green;
    public Transform red;
    

    void OnTriggerEnter(Collider other)
    
    {
        if(other.gameObject.name == "ball")
        {
            hitPoint = hitPoint - 30;
        }
        if (other.gameObject.name == "bullet(Clone)")
        {
            hitPoint = hitPoint - 10;          
        }
    }
    void Start()
    {
        hitPoint = 90;
    }


    // Update is called once per frame
    void Update()
    {
        if(hitPoint <= 0)
        {
            if (Random.Range(0, 20) < 6)
            {
                if (Random.Range(0, 2) == 1)
                    Instantiate(green, transform.position, Quaternion.identity);
                else
                    Instantiate(red, transform.position, Quaternion.identity);
            }
            GameObject.Find("script").GetComponent<score>().ScoreCounter();
            Destroy(gameObject);
        }
    }
}
