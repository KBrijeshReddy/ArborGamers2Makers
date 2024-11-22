using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChanger : MonoBehaviour
{
    public bool keyCollected;

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
                // change scene
            }
            else
            {
                // alert player
            }
        }
    }
}
