using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonShooter : MonoBehaviour
{
    [Header("Cannon Settings")]
    public GameObject bulletPrefab; // The bullet prefab
    public Transform firePoint; // Where the bullet spawns
    public float bulletSpeed = 10f; // Speed of the bullet
    public float fireRate = 5f; // Time between shots in seconds

    private Transform player;
    private float fireCooldown = 0f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // Find the player by tag
    }

    void Update()
    {
        fireCooldown -= Time.deltaTime;

        if (fireCooldown <= 0f)
        {
            ShootAtPlayer();
            fireCooldown = fireRate;
        }
    }

    private void ShootAtPlayer()
    {
        if (player == null) return;

        // Calculate direction to player
        Vector2 direction = (player.position - firePoint.position).normalized;

        // Instantiate the bullet
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

        // Add velocity to the bullet
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = direction * bulletSpeed;
        }

        // Optional: Destroy the bullet after a certain time to avoid clutter
        Destroy(bullet, 5f);
    }
}

