using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gamecontrol : MonoBehaviour
{
    public GameObject menu;
    public GameObject con;
    public GameObject end;
    bool clean = false;
    public void GameOver()
    {
        GetComponent<score>().ResetScore();
        menu.SetActive(true);
        con.SetActive(false);
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
        clean = true;

        //while (!(GameObject.Find("brick(Clone)") == null))
        //{
        //Destroy(GameObject.Find("brick(Clone)"));
        //}
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
        if (clean)
        {
            Destroy(GameObject.Find("brick(Clone)"));
            Destroy(GameObject.Find("green(Clone)"));
            Destroy(GameObject.Find("red(Clone)"));
            if (!(GameObject.Find("brick(Clone)") || GameObject.Find("red(Clone)") || GameObject.Find("green(Clone)")))
            {
                clean = false;
                GameObject.Find("script").GetComponent<builder>().Build();
            }
        }
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menu.SetActive(true);
            end.SetActive(false);
            Time.timeScale = 0f;
        }
    }
}
