using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class MovementP2 : MonoBehaviour
{
    private Vector2 moveInput;
    private Rigidbody2D rb;
    private PlayerControls controls;
    public Animator animator;
    public GameObject attackPoint;
    public float radius;
    public LayerMask enemies;

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

    public void attack()
    {
        Collider2D[] enemy = Physics2D.OverlapCircleAll(attackPoint.transform.position, radius, enemies);
        foreach (Collider2D enemyGameObject in enemy)
        {
            Debug.Log("hit");
        }
    }

    public void endAttack()
    {
        animator.SetBool("isAttack3", false);
        animator.SetBool("isAttack", false);
    }

    private void onDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackPoint.transform.position, radius);
    }
}
