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

    private Rigidbody2D rb;
    private bool isGrounded;
    private int groundContacts;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!canMove) return;
        float moveInput = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            isGrounded = false; 
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (((1 << collision.gameObject.layer) & groundLayer) != 0)
        {
            groundContacts++;
            isGrounded = true;
        }
        if(collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Spike"))
        {
            transform.position = spawnPoint.position;
            audioSource.PlayOneShot(deathAudio);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (((1 << collision.gameObject.layer) & groundLayer) != 0)
        {
            groundContacts--;
            if (groundContacts <= 0)
                isGrounded = false;
        }
    }

    //animaciok nehezek azokat maskor megcsinaljuk inkabb a projekt masik felehez, de a mozgast megcsinaltam, hogy legyen valami alapunk
}