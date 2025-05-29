using UnityEngine;

public class TigerController : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of tiger's movement
    public float jumpForce = 5f; // Force applied when jumping
    public Animator animator; // Animator for controlling animations
    public Rigidbody rb; // Rigidbody component for physics-based movement

    private bool isGrounded = true; // To check if tiger is on the ground

    void Start()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody>();
        }

        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
    }

    void Update()
    {
        Move();
        Jump();
    }

    // Movement function
    void Move()
    {
        // Get movement inputs (WASD or Arrow Keys)
        float moveHorizontal = Input.GetAxis("Horizontal"); // A/D or Left/Right arrow
        float moveVertical = Input.GetAxis("Vertical"); // W/S or Up/Down arrow

        // Create a movement vector based on inputs
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical).normalized * moveSpeed;

        // Apply movement to the rigidbody
        rb.MovePosition(transform.position + movement * Time.deltaTime);

        // If there's movement, play the walking animation
        if (movement.magnitude > 0)
        {
            animator.SetBool("isWalking", true); // Trigger walking animation
        }
        else
        {
            animator.SetBool("isWalking", false); // Stop walking animation
        }

        // Rotate tiger towards movement direction
        if (movement != Vector3.zero)
        {
            transform.forward = movement;
        }
    }

    // Jump function
    void Jump()
    {
        // Check if the space bar is pressed and tiger is grounded
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            // Apply jump force
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            // Play the jump animation
            animator.SetTrigger("Jump");

            // Set isGrounded to false because tiger is in the air
            isGrounded = false;
        }
    }

    // Check if tiger lands back on the ground
    private void OnCollisionEnter(Collision collision)
    {
        // When tiger collides with ground, allow jumping again
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
