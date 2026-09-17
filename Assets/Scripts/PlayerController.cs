using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpHeight = 2f;
    private int jumpCount = 0;
    private int jumpLimit = 2;
    private bool grounded = true;

    private Rigidbody2D body;
    private Vector2 moveInput;
    [SerializeField] private bool jumpRequested;

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
        //body.linearVelocity = new Vector2(moveInput.x * speed, body.linearVelocity.y);

        if (jumpRequested && (jumpCount < jumpLimit))
        {
            body.AddForce(transform.up * jumpHeight, ForceMode2D.Impulse);
            jumpCount++;

            //body.linearVelocity = new Vector2(body.linearVelocity.x, jumpHeight);
            jumpRequested = false;

        }
        if (jumpRequested && (jumpCount >= jumpLimit))
        {
            jumpRequested = false;
        }
    }
    void OnCollisionEnter2D(Collision2D Coll)
    {
        //if (Coll.gameObject.name == "Floor")
        //{
        //Debug.Log(Coll.gameObject.name);
        //            Debug.Log("Have touched floor");
        if (Coll.gameObject.name == "Floor")
        {
            //Debug.Log(jumpCount);
            jumpCount = 0;
            grounded = true;
        }
        //}
    }
    void OnCollisionExit2D(Collision2D coll)
    {
       // if (coll.gameObject.name == "Floor")
        //{
          //  grounded = false;
       // }
    }
}
