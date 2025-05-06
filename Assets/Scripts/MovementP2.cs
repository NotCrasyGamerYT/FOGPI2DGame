using UnityEngine;
using UnityEngine.InputSystem;

public class MovementP2 : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 12f;
    private Vector2 moveInput;

    [Header("Ground Check")]
    public Transform groundCheck;        // assign a child at the player's feet
    public LayerMask groundLayer;        // layer(s) to treat as ground
    private bool isGrounded;

    [Header("Attack")]
    public GameObject attackPoint;
    public float radius = 0.5f;
    public LayerMask enemies;

    [Header("References")]
    public Animator animator;

    private Rigidbody2D rb;
    private PlayerControls controls;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        controls = new PlayerControls();

        // Movement binding
        controls.MovementP2.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        controls.MovementP2.Move.canceled += ctx => moveInput = ctx.ReadValue<Vector2>();

        // Jump binding
        controls.MovementP2.Jump.performed += ctx =>
        {
            if (isGrounded)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
                animator.SetTrigger("Jump");
            }
        };


        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    private void Update()
    {
        // 1) Flip sprite
        FlipSprite();

        // 2) Check grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);

        // 3) Animator walk/run
        animator.SetFloat("Speed", Mathf.Abs(rb.linearVelocity.x));
        animator.SetBool("isWalking", Mathf.Abs(rb.linearVelocity.x) > 0.1f);

        // Attack binding
        controls.MovementP2.Attack.performed += ctx =>
        {
            animator.SetBool("isAttack3", true);
            Attack();
        };

    }

    private void FixedUpdate()
    {
        // Preserve existing Y velocity when moving horizontally
        rb.linearVelocity = new Vector2(moveInput.x * moveSpeed, rb.linearVelocity.y);
    }

    private void FlipSprite()
    {
        if (moveInput.x > 0)
            transform.localScale = new Vector3(1.9875f, 2.55f, 1);
        else if (moveInput.x < 0)
            transform.localScale = new Vector3(-1.9875f, 2.55f, 1);
    }

    private void Attack()
    {
        var hits = Physics2D.OverlapCircleAll(attackPoint.transform.position, radius, enemies);
        foreach (var col in hits)
        {
            var health = col.GetComponent<P1Health>();
            if (health != null)
                health.health -= 10;
        }
    }

    public void EndAttack()
    {
        animator.SetBool("isAttack3", false);
    }

    private void OnDrawGizmos()
    {
        // Draw ground-check sphere
        if (groundCheck != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(groundCheck.position, 0.1f);
        }

        // Draw attack range sphere
        if (attackPoint != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(attackPoint.transform.position, radius);
        }
    }
}
