using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gamecontrol : MonoBehaviour
{
    public GameObject menu;
    public GameObject con;
    public GameObject end, result;
    bool gameEnd = false;
    public void GameOver()
    {
        result.GetComponent<Text>().text = GetComponent<score>().value.ToString() + " !!!";
        GetComponent<score>().ResetScore();
        menu.SetActive(true);
        con.SetActive(false);
        result.SetActive(true);
        gameEnd = true;
        Time.timeScale = 0f;
    }
    
    public void Continue()
    {
        menu.SetActive(false);
        Time.timeScale = 1f;
    }
    public void Restart()
    {
        menu.SetActive(false);
        GetComponent<score>().ResetScore();
        GameObject.Find("misswall").GetComponent<miss>().HP = 2;
        
        GameObject.Find("platform").GetComponent<platform>().stickyPlatform = true;
        GameObject.Find("ball").GetComponent<ball>().onPlatform = true;
        GetComponent<builder>().Destroy();
        GetComponent<builder>().Build();
        gameEnd = false;

        
        Time.timeScale = 1f;

    }
    public void Isekai()
    {
        Application.Quit();   
    }


    void Start()
    {
        GameObject.Find("misswall").GetComponent<miss>().HP = 2;
    }
    void Update()
    {       
        if (Input.GetKeyDown(KeyCode.Escape) && !(gameEnd))
        {
            menu.SetActive(true);
            con.SetActive(true);
            end.SetActive(false);
            result.SetActive(false);
            Time.timeScale = 0f;
        }
    }
}
