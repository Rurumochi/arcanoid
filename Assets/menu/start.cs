using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class start : MonoBehaviour
{
    public void begin()
    {
        SceneManager.LoadScene(1);
    }
    public void esc()
    {
        Application.Quit();
    }
}
