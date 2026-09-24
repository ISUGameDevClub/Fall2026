using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpHeight = 2f;
    [SerializeField] private int jumpLimit = 2;

    private int jumpCount;
    private Rigidbody2D body;
    private InputAction moveAction;
    private InputAction jumpAction;
    private Vector2 moveInput;
    private bool jumpRequested;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        PlayerInput playerInput = GetComponent<PlayerInput>();

        if (playerInput != null && playerInput.actions != null)
        {
            moveAction = playerInput.actions.FindAction("Move");
            jumpAction = playerInput.actions.FindAction("Jump");
        }

        if (body == null)
        {
            Debug.LogError("PlayerController needs a Rigidbody2D on the same GameObject.", this);
        }
    }

    private void OnEnable()
    {
        if (moveAction != null)
        {
            moveAction.performed += OnMove;
            moveAction.canceled += OnMove;
            moveAction.Enable();
        }

        if (jumpAction != null)
        {
            jumpAction.performed += OnJump;
            jumpAction.Enable();
        }
    }

    private void OnDisable()
    {
        if (moveAction != null)
        {
            moveAction.performed -= OnMove;
            moveAction.canceled -= OnMove;
        }

        if (jumpAction != null)
        {
            jumpAction.performed -= OnJump;
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            jumpRequested = true;

        }
    }

    private void FixedUpdate()
    {
        if (body == null)
        {
            return;
        }

        body.linearVelocity = new Vector2(moveInput.x * speed, body.linearVelocity.y);

        if (!jumpRequested)
        {
            return;
        }

        jumpRequested = false;

        if (jumpCount < jumpLimit)
        {
            body.AddForce(transform.up * jumpHeight, ForceMode2D.Impulse);
            jumpCount++;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        foreach (ContactPoint2D contact in collision.contacts)
        {
            if (contact.normal.y > 0.5f)
            {
                jumpCount = 0;
                return;
            }
        }
    }
}
