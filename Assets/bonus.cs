using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bonus : MonoBehaviour
{
    public string bonusType; 
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "wallup" || other.gameObject.name == "platform")
            Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        if (bonusType == "red")
            GetComponent<Renderer>().material.color = Color.red;
        if (bonusType == "green")
            GetComponent<Renderer>().material.color = Color.green;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(15 * Time.deltaTime, 20 * Time.deltaTime * -1, 0);
        
    }
}
