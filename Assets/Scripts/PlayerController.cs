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

    //private bool jumpRequested;
    [Header("Player Consumables")]
    [SerializeField] private GameObject BreadcrumbPrefab;
    [SerializeField] private int BreadCrumbLimit;
    public int BreadCrumbAmount;
    //public GameObject[] breadCrumbArray;
    //This inputaction variable is because the "void OnPlant()" wasnt working, 
    //so I did it the way that works in my other project
    private InputAction Drop;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }
    //Yeah so the start function is because the "void OnPlant()" wasnt working for some reason
    void Start()
    {
        Drop = InputSystem.actions.FindAction("Player/Plant");
        Drop.performed += ctx => Plant();
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
    void Plant()
    {


        //Debug.Log("What");
        if (BreadCrumbAmount < BreadCrumbLimit)
        {
            GameObject BCGO = Instantiate(BreadcrumbPrefab, new Vector3(transform.position.x, transform.position.y - .75f, transform.position.z), Quaternion.identity);
            BreadCrumbAmount++;
        }
        
    }

    private void FixedUpdate()
    {
        body.linearVelocity = new Vector2(moveInput.x * speed, body.linearVelocity.y);

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
