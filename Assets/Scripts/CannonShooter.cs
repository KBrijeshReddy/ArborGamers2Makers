using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonShooter : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab; // The prefab of the ball to shoot
    [SerializeField] private Transform shootPoint; // The point from where the ball is shot
    [SerializeField] private float shootForce = 10f; // Force applied to the ball
    [SerializeField] private float shootInterval = 5f; // Time interval between shots

    private bool isPlayerInRange = false; // Tracks if the player is in the collider
    private Coroutine shootingCoroutine;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Ensure the object entering is the player
        {
            isPlayerInRange = true;
            shootingCoroutine = StartCoroutine(StartShooting());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Ensure the object exiting is the player
        {
            isPlayerInRange = false;
            if (shootingCoroutine != null)
            {
                StopCoroutine(shootingCoroutine);
            }
        }
    }

    private IEnumerator StartShooting()
    {
        while (isPlayerInRange)
        {
            ShootBall();
            yield return new WaitForSeconds(shootInterval);
        }
    }

    private void ShootBall()
    {
        if (ballPrefab == null || shootPoint == null)
        {
            Debug.LogError("BallPrefab or ShootPoint is not assigned!");
            return;
        }

        // Instantiate the ball at the shoot point
        GameObject ball = Instantiate(ballPrefab, shootPoint.position, shootPoint.rotation);

        // Add force to the ball to shoot it towards the player
        Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.AddForce(shootPoint.right * shootForce, ForceMode2D.Impulse);
        }
    }
}

