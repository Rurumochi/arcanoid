using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class brick : MonoBehaviour
{
    public int hitPoint;
    public GameObject bonusPrefab;
    private GameObject script;
    




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
        script = GameObject.Find("script");
    }
    void CreateBonus(string key)
    {
        var bonus = Instantiate(bonusPrefab, transform.position, Quaternion.identity);
        bonus.GetComponent<bonus>().bonusType = key;
        script.GetComponent<builder>().bonuses.Add(bonus);
        
    }


    // Update is called once per frame
    void Update()
    {
        if(hitPoint <= 0)
        {
            if (Random.Range(0, 20) < 6)
            {
                if (Random.Range(0, 2) == 1)
                    CreateBonus("red");
                else
                    CreateBonus("green");
            }
            script.GetComponent<score>().ScoreCounter();
            Destroy(gameObject);
        }
    }
}
