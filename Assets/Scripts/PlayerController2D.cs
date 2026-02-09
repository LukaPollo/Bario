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

    public Transform groundCheck;
    public float groundCheckRadius = 0.1f;

    private Rigidbody2D rb;
    private bool isGrounded;
    public Animator animator;

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

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Spike"))
        {
            transform.position = spawnPoint.position;
            audioSource.PlayOneShot(deathAudio);
        }
    }

    //
    // 2/9/2026 4:28
    //
}