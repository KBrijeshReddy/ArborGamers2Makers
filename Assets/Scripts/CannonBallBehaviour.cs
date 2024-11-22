using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallBehaviour : MonoBehaviour
{
    public float timeAlive = 2f;
    private float time = 0;

    void FixedUpdate()
    {
        time += Time.deltaTime;
        if (time >= timeAlive)
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
