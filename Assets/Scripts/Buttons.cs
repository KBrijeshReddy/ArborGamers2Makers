using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public int Tutorial = 1;

    public void Play()
    {
        SceneManager.LoadScene(Tutorial);
    }
    
    public void Quit()
    {
        Application.Quit();
    }
}
