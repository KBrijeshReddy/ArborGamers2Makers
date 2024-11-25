using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public bool keyCollected;
<<<<<<< HEAD
    public int sceneNum;
=======
    public int nextSceneNumber;
>>>>>>> c2e2262f89aeeb103c41bc4c7efdc685a4bb7c02

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
<<<<<<< HEAD
                SceneManager.LoadScene(sceneNum);
=======
                SceneManager.LoadScene(nextSceneNumber);
>>>>>>> c2e2262f89aeeb103c41bc4c7efdc685a4bb7c02
            }
        }
    }
}
