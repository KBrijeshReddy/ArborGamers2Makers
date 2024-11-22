using UnityEngine;

public class CannonShooter : MonoBehaviour
{
    public bool playerInRange = false;
    // Fireball prefab to spawn
    public GameObject fireballPrefab;

    // Time interval between shots
    public float shootInterval = 2f;

    // Fireball speed
    public float fireballSpeed = 10f;

    // Internal timer to manage firing
    private float timer;
    private Vector3 dir;

    void Update()
    {
        // Update the timer
        if (playerInRange)
        timer += Time.deltaTime;

        // Check if it's time to shoot
        if (timer >= shootInterval)
        {
            ShootFireball();
            timer = 0f; // Reset the timer
        }
    }

    void ShootFireball()
    {
        if (fireballPrefab != null && transform != null)
        {
            // Spawn the fireball
            GameObject fireball = Instantiate(fireballPrefab, transform.position, transform.rotation);

            // Add velocity to the fireball
            Rigidbody2D rb = fireball.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                dir = (PlayerManager.instance.gameObject.transform.position - transform.position).normalized;
                rb.velocity = dir * fireballSpeed; // Fire in the forward direction
            }
        }
        else
        {
            Debug.LogWarning("Fireball prefab or fire point not assigned!");
        }
    }
}
