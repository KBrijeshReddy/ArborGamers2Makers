using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public bool keyCollected;
    public int nextSceneNumber;

    void Start()
    {
        keyCollected = false;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Player"))
        {
            if (keyCollected)
            {
                SceneManager.LoadScene(nextSceneNumber);
            }
        }
    }
}
