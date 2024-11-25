using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformsTrigger : MonoBehaviour
{
    [SerializeField] private float stayTime = 3f; // Time to stay before moving (set in Inspector)
    [SerializeField] private ShiftingObjects shiftingObjects; // Time to stay before moving (set in Inspector)

    private float stayTimer = 0f; // Timer to track how long the GameObject has been on
    private bool canMove = false; // Flag to indicate if movement is allowed

    private void Update()
    {
        // If the object is being hovered/stayed on, increase the timer
        if (canMove)
        {
            stayTimer += Time.deltaTime;

            // After the specified time, start moving
            if (stayTimer >= stayTime)
            {
                shiftingObjects.MoveObject();
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        // Check if another object (e.g., the player) is staying on the trigger collider
        if (other.CompareTag("Player"))  // You can modify this to other tags as needed
        {
            canMove = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Reset everything if the player exits the trigger area
        if (other.CompareTag("Player"))
        {
            canMove = false;
            stayTimer = 0f; // Reset timer
            Destroy(gameObject);
        }
    }
}
