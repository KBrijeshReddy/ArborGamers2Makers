using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float dashSpeed = 20f; // Speed of the dash
    public float dashDuration = 0.2f; // How long the dash lasts
    public float dashCooldown = 1f; // Time between dashes
    public bool cannonShoot;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private bool isDashing;
    private float dashTime;
    private float dashCooldownTimer;
    private Vector2 dashDirection;
    private float gravityCheck;
    private bool isGrounded;
    private float horizontalInput;
    private bool IsAbove;
    private RaycastHit2D hit;

    void Awake()
    {
        isDashing = false;
        cannonShoot = false;
        isGrounded = false;
        IsAbove = false;
        gravityCheck = 1f;
        dashTime = 0f;
        dashCooldownTimer = 0f;

        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.Rotate(0f, 180f, 0f);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.Rotate(0f, 180f, 0f);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            rb.gravityScale *= -1;
            IsAbove = true;
            gravityCheck *= -1;
        }
        if (!isDashing && Input.GetKeyDown(KeyCode.LeftShift) && dashCooldownTimer <= 0f)
        {
            StartDash();
        }
        if (isDashing)
        {
            dashTime -= Time.deltaTime;
            if (dashTime <= 0f)
            {
                EndDash();
            }
        }

        dashCooldownTimer -= Time.deltaTime;
    }

    void FixedUpdate()
    {
        // Move the player
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);

        if (isDashing)
        {
            rb.velocity = dashDirection * dashSpeed;
            return; // Skip normal movement while dashing
        }
    }

    private bool IsGrounded()
    {
        // Check if the player is touching the ground
        if (IsAbove)
        {
            hit = Physics2D.Raycast(transform.position, Vector2.up, 1.1f, groundLayer);
        }
        else
        {
            hit = Physics2D.Raycast(transform.position, Vector2.down, 1.1f, groundLayer);
        }

        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        // Draw a ray to visualize ground check in the editor
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * 1.1f);
    }

    private void StartDash()
    {
        isDashing = true;
        dashTime = dashDuration;
        dashCooldownTimer = dashCooldown;

        // Determine the dash direction based on input
        dashDirection = new Vector2(horizontalInput, 0).normalized;
        if (dashDirection == Vector2.zero) dashDirection = new Vector2(transform.localScale.x, 0); // Default to facing direction

        // Optional: Prevent gravity during dash
        rb.gravityScale = 0f;
    }

    private void EndDash()
    {
        isDashing = false;
        
        if(gravityCheck == 1)
        {
            rb.gravityScale = 5f;
        }
        else
        {
            rb.gravityScale = -5f;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "enemy")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if(collision.gameObject.tag == "cannontrigger")
        {
            cannonShoot = true;
        }
    }
}


