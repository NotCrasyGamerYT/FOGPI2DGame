using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    private Vector2 moveInput;
    private Rigidbody2D rb;
    private PlayerControls controls;

    [SerializeField] private float moveSpeed = 5f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = moveInput * moveSpeed;
    }

    private void OnEnable()
    {
        controls = new PlayerControls();
        controls.Movement.Move.performed += OnMove;
        controls.Movement.Move.canceled += OnMove;
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }
}
