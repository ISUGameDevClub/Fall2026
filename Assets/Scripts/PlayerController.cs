using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    //private float walkSpeed;
    [SerializeField] private float jumpHeight = 2f;
    [SerializeField] private float coyoteTime = 0.1f;
    private int jumpCount = 0;
    private int jumpLimit = 2;
    private bool grounded;
    private float coyoteTimeCounter;
    private readonly HashSet<Collider2D> groundColliders = new HashSet<Collider2D>();

    private Rigidbody2D body;
    private Vector2 moveInput;
    [SerializeField] private bool jumpRequested;
    public bool ableToMove;
    //
    [SerializeField] private GameObject Reticle;
    private Vector3 mousePos;
    public bool aiming;
    private InputAction Aim;
    public bool facingRight;

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
    public float range;
    Pause pause;

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
        pause = FindAnyObjectByType<Pause>();
        Application.targetFrameRate = 60;
        Drop = InputSystem.actions.FindAction("Player/Plant");
        Aim = InputSystem.actions.FindAction("Player/Aim");
        Aim.performed += ctx => StartAim();
        Aim.canceled += ctx => EndAim();
        Drop.performed += ctx => Plant();
        Throw = InputSystem.actions.FindAction("Player/Throw");
        Throw.performed += ctx => ThrowObject();
        ableToMove = true;
        aiming = false;
        //walkSpeed = speed;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (ableToMove)
        {


            moveInput = context.ReadValue<Vector2>();

            // Update which direction player is facing
            if (moveInput.x > 0) facingRight = true;
            else if (moveInput.x < 0) facingRight = false;
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
            //BCGO is instantiated Breadcrumbs gameobject 
            GameObject BCGO = Instantiate(BreadcrumbPrefab, new Vector3(transform.position.x, transform.position.y - .75f, transform.position.z), Quaternion.identity);
            BCGO.GetComponent<BreadCrumbBehavior>().parent = gameObject;
            BCGO.GetComponent<BreadCrumbBehavior>().target = Reticle;
            BCGO.GetComponent<BreadCrumbBehavior>().thrown = false;
            
            BreadCrumbAmount++;
        }

    }
    void ThrowObject()
    {
        if (aiming && (BreadCrumbAmount < BreadCrumbLimit))
        {
            GameObject BCGO = Instantiate(BreadcrumbPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            BreadCrumbAmount++;
            //BCGO.GetComponent<BreadCrumbBehavior>().CurrentPosition = new Vector2(mousePos.x, mousePos.y);
            //BCGO.GetComponent<BreadCrumbBehavior>().thrown = true;
            BCGO.GetComponent<BreadCrumbBehavior>().parent = gameObject;
            BCGO.GetComponent<BreadCrumbBehavior>().target = Reticle;
            BCGO.GetComponent<BreadCrumbBehavior>().thrown=true;
            //BCGO.GetComponent<BreadCrumbBehavior>().mousePos = new Vector2(mousePos.x, mousePos.y);
            //BCGO.GetComponent<Rigidbody2D>().AddForce(Vector2.one * 250);
            //BCGO.GetComponent<BreadCrumbBehavior>().thrownRight = true;
            //BCGO.GetComponent<BreadCrumbBehavior>().thrownLeft = true;
        }
    }

    private void FixedUpdate()
    {
        if (pause.isPaused())
            return; //dont check for player input if paused

        if (grounded)
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter = Mathf.Max(0f, coyoteTimeCounter - Time.fixedDeltaTime);
        }

        if (ableToMove)
        {
            body.linearVelocity = new Vector2(moveInput.x * speed, body.linearVelocity.y);

            bool canGroundJump = jumpCount == 0 && (grounded || coyoteTimeCounter > 0f);
            bool canDoubleJump = jumpCount == 1 && jumpLimit > 1;
            if (jumpRequested && (canGroundJump || canDoubleJump))
            {
                body.AddForce(transform.up * jumpHeight, ForceMode2D.Impulse);
                jumpCount++;
                coyoteTimeCounter = 0f;
            }

            jumpRequested = false;
        }
        else if (aiming)
        {
            
            //if (Vector2.Distance(transform.position, Reticle.transform.position) > range)
            //{
                //Debug.Log("Out of range");
            //}
            //else
             mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Mouse.current.position.ReadValue().x, Mouse.current.position.ReadValue().y, Camera.main.nearClipPlane));
            
            if (Vector2.Distance(transform.position, mousePos) < range)
            {
                Reticle.transform.position = mousePos;
            if (mousePos.y > transform.position.y)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }
            else if (mousePos.y < transform.position.y)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
            }
            }
        }
    }
    void StartAim()
    {
        ableToMove = false;
        aiming = true;
        Reticle.SetActive(true);
        gameObject.GetComponent<SwingController>().enabled = false;
        body.linearVelocity = new Vector2(0, 0);
        moveInput = new Vector2(0, 0);
        mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Mouse.current.position.ReadValue().x, Mouse.current.position.ReadValue().y, Camera.main.nearClipPlane));
        Reticle.transform.position = mousePos;
        //speed = 0;
    }
    void EndAim()
    {
        ableToMove = true;
        aiming = false;
        Reticle.SetActive(false);
        gameObject.GetComponent<SwingController>().enabled = true;
        //speed = walkSpeed;
        
    }
    void OnCollisionEnter2D(Collision2D Coll)
    {
        if (Coll.gameObject.CompareTag("Floor"))
        {
            groundColliders.Add(Coll.collider);
            grounded = true;
            jumpCount = 0;
        }
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Floor"))
        {
            groundColliders.Remove(coll.collider);
            grounded = groundColliders.Count > 0;
        }
    }

    public bool IsFacingRight()
    {
        return facingRight;
    }
}
