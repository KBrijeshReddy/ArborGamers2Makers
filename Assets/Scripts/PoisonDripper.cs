using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonDripper : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab; // The prefab of the ball to shoot
    [SerializeField] private Transform shootPoint; // The point from where the ball is shot
    [SerializeField] private float shootForce = 5f; // Force applied to the ball
    [SerializeField] private float shootInterval = 3f; // Time interval between shots
    public string uppadowna;

    private void Start()
    {
        StartCoroutine(ShootBalls());
    }

    private IEnumerator ShootBalls()
    {
        while (true) // Infinite loop to shoot balls at intervals
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
        GameObject ball = Instantiate(ballPrefab, shootPoint.position, Quaternion.identity);

        // Add force to the ball to make it move vertically downward
        Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            if (uppadowna == "up")
            {
                rb.AddForce(Vector2.up * shootForce, ForceMode2D.Impulse);
            }
            else
            {
                rb.AddForce(Vector2.down * shootForce, ForceMode2D.Impulse);
            }
        }
    }
}


