using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public float speed;
    public float moveInput;

    private Rigidbody2D rb;

    private bool facingRight = true;

    private RaycastHit2D hit;
    private bool IsAbove = false;

    public LayerMask groundLayer;

    private bool canDash = true;
    private bool isDashing;
    public float dashingPower = 10f;
    public float dashingTime = 0.2f;
    public float dashingCooldown = 1f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        
        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if(facingRight == true && moveInput < 0) 
        {
            Flip();
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
            rb.gravityScale *= -1;
            IsAbove = !IsAbove;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            StartCoroutine(Dash());    
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
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
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
}
