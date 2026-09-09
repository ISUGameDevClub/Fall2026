using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpHeight = 2f;

    private Rigidbody2D body;
    private Vector2 moveInput;
    private bool jumpRequested;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
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
        body.linearVelocity = new Vector2(moveInput.x * speed, body.linearVelocity.y);

        if (jumpRequested)
        {
            body.linearVelocity = new Vector2(body.linearVelocity.x, jumpHeight);
            jumpRequested = false;
        }
    }
}
