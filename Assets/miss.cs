using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class miss : MonoBehaviour
{
    public int HP;
    void OnTriggerEnter(Collider other)
    {
        if (HP == 0)
        {
            GameObject.Find("script").GetComponent<gamecontrol>().GameOver();
        }
        if (other.gameObject.name == "ball")
        {
            HP = HP - 1;
            GameObject.Find("script").GetComponent<score>().ScoreMultiplier = 0;
        }
    }
}
