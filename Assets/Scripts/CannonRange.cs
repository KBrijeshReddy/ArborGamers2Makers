using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonRange : MonoBehaviour
{
    public CannonShooter cannonShooter;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Player"))
        {
            cannonShooter.playerInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.CompareTag("Player"))
        {
            cannonShooter.playerInRange = false;
        }
    }
}
