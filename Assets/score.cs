using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    public GameObject Record;
    public Text Score;
    
    public int ScoreMultiplier;
    private int record, value;
    public void ScoreCounter() {
        ScoreMultiplier++;
        value = value + ScoreMultiplier;
        
        Score.text = "Score " + value.ToString();
    }
    public void ResetScore()
    {
        
        if (record <= value)
        {
            record = value;
            Record.SetActive(true);
            Record.GetComponent<Text>().text = "Record " + record.ToString() + " !!!";
        }
        value = 0;
        ScoreMultiplier = 0;
    }

    void Start()
    {
        Record.SetActive(false);
        Score.text = "Score " + value.ToString();
    } 
}
