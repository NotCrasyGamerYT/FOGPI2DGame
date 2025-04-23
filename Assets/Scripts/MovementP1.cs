using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class MovementP1 : MonoBehaviour
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
            attack();
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
        if (moveInput.x > 0)
            transform.localScale = new Vector3(1.9875f, 2.55f, 1);
        else if (moveInput.x < 0)
            transform.localScale = new Vector3(-1.9875f, 2.55f, 1);

    }

    public void attack()
    {
        Collider2D[] enemy = Physics2D.OverlapCircleAll(attackPoint.transform.position, radius, enemies);
        foreach (Collider2D enemyGameObject in enemy)
        {
            Debug.Log("p1 hit p2");
            enemyGameObject.GetComponent<P2Health>().health -= 10;
        }
    }

    public void endAttack()
    {
        animator.SetBool("isAttack3", false);
        animator.SetBool("isAttacking", false);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackPoint.transform.position, radius);

    }
}
