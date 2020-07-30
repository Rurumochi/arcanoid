using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "wallup" || other.gameObject.name == "brick(Clone)")
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        speed = 400;    
    }
    
    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, speed * Time.deltaTime, 0);
    }
}
