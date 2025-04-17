using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class MovementP1 : MonoBehaviour
{
    private Vector2 moveInput;
    private Rigidbody2D rb;
    private PlayerControls controls;
    public Animator animator;

    public SpriteRenderer playerSpriteRenderer;

    [SerializeField] private float moveSpeed = 0;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerSpriteRenderer = GetComponent<SpriteRenderer>();

    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    private void Update()
    {
        FlipSprite();
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetBool("isAttack3", true);
        }

    }

    private void FixedUpdate()
    {
        rb.linearVelocity = moveInput * moveSpeed;
        animator.SetFloat("Speed", Mathf.Abs(rb.linearVelocityX));
        animator.SetBool("isWalking", true);
    }


    private void OnEnable()
    {
        controls = new PlayerControls();
        controls.MovementP1.Move.performed += OnMove;
        controls.MovementP1.Move.canceled += OnMove;
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    private void FlipSprite()
    {
        if (moveInput.x > 0) // Moving right
        {
            playerSpriteRenderer.flipX = false;
        }
        else if (moveInput.x < 0) // Moving left
        {
            playerSpriteRenderer.flipX = true;
        }

    }

    public void endAttack()
    {
        animator.SetBool("isAttack3", false);
        animator.SetBool("isAttacking", false);
    }
}
