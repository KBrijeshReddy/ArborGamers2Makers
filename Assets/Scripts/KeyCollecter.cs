using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCollecter : MonoBehaviour
{
    public SceneChanger sceneChanger;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Player"))
        {
            sceneChanger.keyCollected = true;
            Destroy(gameObject);
        }
    }
}
