using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance; void Awake() { instance = this; }

    public float CurrentSpeed;
    public float NormalSpeed = 7f;
    public float ReducedSpeed = 3f;
    public float moveInput;
    public float dashingPower = 24f;
    public float dashingTime = 0.2f;
    public float dashingCooldown = 1f;
    public float maxTimeOnGround = 7f;
    public float recoveryTime = 3f;
    public LayerMask groundLayer;
    public SpriteRenderer playerSprite;
    public string level;

    private Coroutine recoveryCoroutine;
    private Rigidbody2D rb;
    private RaycastHit2D hit;
    private float timeOnGround = 0f;
    private bool facingRight = true;
    private bool IsAbove = false;
    private bool canDash = true;
    private bool isDashing = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerSprite.color = Color.white;
        CurrentSpeed = NormalSpeed;
    }

    void FixedUpdate()
    {
        if (IsGrounded() && level == "fire")
        {
            timeOnGround += Time.deltaTime;
            playerSprite.color = Color.Lerp(Color.white, Color.red, timeOnGround/maxTimeOnGround);
            if (timeOnGround >= maxTimeOnGround)
            {
                timeOnGround = 0f;
                RestartLevel();
            }
        }

        if (isDashing)
        {
            return;
        }
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * CurrentSpeed, rb.velocity.y);

        if (facingRight == false && moveInput * rb.gravityScale > 0)
        {
            FlipX();
        }
        else if(facingRight == true && moveInput * rb.gravityScale < 0) 
        {
            FlipX();
        }
    }

    void Update()
    {
        if (isDashing)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Q) && IsGrounded())
        {
            Debug.Log("nil");
            rb.gravityScale *= -1;
            IsAbove = !IsAbove;
            timeOnGround = 0f;
            FlipY();
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            StartCoroutine(Dash());    
        }
        Debug.Log(CurrentSpeed);
    }

    void FlipX()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    void FlipY()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.y *= -1;
        transform.localScale = Scaler;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private bool IsGrounded()
    {
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

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            RestartLevel();
        }
        if (collision.gameObject.tag == "wheeltrigger")
        {
            collision.gameObject.GetComponent<WheelTrigger>().RunRoll(IsAbove);
        }
        if (collision.gameObject.tag == "water")
        {
            if (recoveryCoroutine != null)
            {
                StopCoroutine(recoveryCoroutine); // Stop any existing recovery coroutine
            }
            CurrentSpeed = ReducedSpeed; // Reduce speed immediately
            recoveryCoroutine = StartCoroutine(RecoverSpeedAfterDelay());
        }
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        yield return new WaitForSeconds(dashingTime);
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }

    private IEnumerator RecoverSpeedAfterDelay()
    {
        yield return new WaitForSeconds(recoveryTime); // Wait for recovery time
        CurrentSpeed = NormalSpeed; // Restore normal speed
    }

    private void OnDrawGizmos()
    {
        // Draw a ray to visualize ground check in the editor
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * 1.1f);
    }
}
