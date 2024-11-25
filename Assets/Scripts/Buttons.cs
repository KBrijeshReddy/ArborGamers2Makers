using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public int Tutorial = 2;
    public int Controls = 1;

    public void ControlsScene()
    {
        SceneManager.LoadScene(Controls);
    }
    
    public void TutorialScene()
    {
        SceneManager.LoadScene(Tutorial);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
