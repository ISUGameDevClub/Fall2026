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
    public bool ableToMove;
    //
    [SerializeField] private GameObject Reticle;
    private Vector3 mousePos;
    public bool aiming;
    private InputAction Aim;

    //private bool jumpRequested;
    [Header("Player Consumables")]
    [SerializeField] private GameObject BreadcrumbPrefab;
    [SerializeField] private int BreadCrumbLimit;
    public int BreadCrumbAmount;
    //public GameObject[] breadCrumbArray;
    //This inputaction variable is because the "void OnPlant()" wasnt working, 
    //so I did it the way that works in my other project
    private InputAction Drop;
    private InputAction Throw;
    public static PlayerController instance;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        if (instance == null)
        {
            instance = this;
        }
    }
    //Yeah so the start function is because the "void OnPlant()" wasnt working for some reason
    void Start()
    {
        Drop = InputSystem.actions.FindAction("Player/Plant");
        Aim = InputSystem.actions.FindAction("Player/Aim");
        Aim.performed += ctx => StartAim();
        Aim.canceled += ctx => EndAim();
        Drop.performed += ctx => Plant();
        Throw = InputSystem.actions.FindAction("Player/Throw");
        Throw.performed += ctx => ThrowObject();
        ableToMove = true;
        aiming = false;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (ableToMove)
        {


            moveInput = context.ReadValue<Vector2>();
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (ableToMove)
        {


            if (context.performed)
            {
                jumpRequested = true;

            }
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
    void ThrowObject()
    {
        if (aiming && (BreadCrumbAmount < BreadCrumbLimit))
        {
            GameObject BCGO = Instantiate(BreadcrumbPrefab, new Vector3(transform.position.x, transform.position.y - .75f, transform.position.z), Quaternion.identity);
            BreadCrumbAmount++;
            BCGO.GetComponent<BreadCrumbBehavior>().thrown = true;
            //BCGO.GetComponent<BreadCrumbBehavior>().thrownRight = true;
            //BCGO.GetComponent<BreadCrumbBehavior>().thrownLeft = true;
        }
    }

    private void FixedUpdate()
    {
        if (ableToMove)
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
        if (aiming)
        {
            mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Mouse.current.position.ReadValue().x, Mouse.current.position.ReadValue().y, Camera.main.nearClipPlane));
            Reticle.transform.position = mousePos;
            if (mousePos.y > transform.position.y)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }
        }
    }
    void StartAim()
    {
        ableToMove = false;
        aiming = true;
        Reticle.SetActive(true);
        gameObject.GetComponent<SwingController>().enabled = false;
    }
    void EndAim()
    {
        ableToMove = true;
        aiming = false;
        Reticle.SetActive(false);
        gameObject.GetComponent<SwingController>().enabled = true;
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
