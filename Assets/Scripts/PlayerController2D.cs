using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    public bool canMove = true;
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public LayerMask groundLayer;
    public Transform spawnPoint;
    public AudioClip deathAudio;
    public AudioSource audioSource;
    public Animator animator;
    public Transform groundCheck;
    public float groundCheckRadius = 0.1f;

    private Rigidbody2D rb;
    private bool isGrounded;
    private bool facingRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!canMove) return;

        CheckGround();

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    void FixedUpdate()
    {
        if (!canMove) return;

        float moveInput = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        Flip(moveInput);

        animator.SetBool("isRunning", moveInput != 0);

        if (moveInput != 0) 
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
    }

    void CheckGround()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    void Flip(float moveInput)
    {
        if (moveInput > 0 && !facingRight)
        {
            facingRight = true;
        }
        else if (moveInput < 0 && facingRight)
        {
            facingRight = false;
        }
        else
        {
            return;
        }

        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Spike"))
        {
            transform.position = spawnPoint.position;
            audioSource.PlayOneShot(deathAudio);
        }
    }
}