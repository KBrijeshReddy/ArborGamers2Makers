using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlytrapTrigger : MonoBehaviour
{
    public FlytrapChase flytrapChase;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Player"))
        {
            // flytrapChase.StartChase(coll.gameObject);

        }
    }
}
