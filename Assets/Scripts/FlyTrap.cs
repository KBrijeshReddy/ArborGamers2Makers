using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlyTrap : MonoBehaviour
{
    public Transform player; // Reference to the player
    public float activationTime = 4f; // Time to stay under the object for activation
    public float speed = 5f; // Speed at which the object moves toward the player

    private bool isChasing = false; // Flag to check if the object is chasing the player
    private float timer = 0f; // Timer to track how long the player stays under the object

    private void Update()
    {
        if (isChasing)
        {
            // Move towards the player
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;

            // Check for collision with the player
            float distance = Vector3.Distance(transform.position, player.position);
            if (distance < 0.5f) // Assuming a collision threshold of 0.5 units
            {
                ResetScreen();
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        // Check if the player is under the object
        if (collision.CompareTag("Player"))
        {
            timer += Time.deltaTime;

            if (timer >= activationTime && !isChasing)
            {
                isChasing = true; // Activate chasing
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Reset timer if the player leaves
        if (collision.CompareTag("Player"))
        {
            timer = 0f;
        }
    }

    private void ResetScreen()
    {
        // Reload the active scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

