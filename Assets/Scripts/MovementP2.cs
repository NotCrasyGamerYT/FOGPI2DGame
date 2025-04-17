using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class MovementP2 : MonoBehaviour
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
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = moveInput * moveSpeed;
        animator.SetFloat("Speed", Mathf.Abs(rb.linearVelocityX));
    }

    private void OnEnable()
    {
        controls = new PlayerControls();
        controls.MovementP2.Move.performed += OnMove;
        controls.MovementP2.Move.canceled += OnMove;
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
}
