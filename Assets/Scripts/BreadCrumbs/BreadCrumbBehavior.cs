using UnityEngine;
using UnityEngine.InputSystem;

public class BreadCrumbBehavior : MonoBehaviour
{
    public bool collectable;
    public bool thrown;
    private Rigidbody2D GORB2D;
    [SerializeField] private float speed;
    public GameObject parent, target;
    public Vector3 mousePos;
    private Vector2 parentPos;
    private float distance;
    private float nextX;
    private float baseY;
    private float height;
    private GameObject Floor;
    //public float thing;
    //public Vector2 CurrentPosition;
    //private Transform Object;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GORB2D = gameObject.GetComponent<Rigidbody2D>();
        collectable = false;
        parentPos = new Vector2(parent.transform.position.x, parent.transform.position.y);
        Floor = GameObject.FindGameObjectWithTag("Floor");
        mousePos = new Vector3(target.transform.position.x, Floor.transform.position.y + .9f, 0);
        if (thrown)
        {

        }
        else
        {
            GetComponent<Rigidbody2D>().gravityScale = 0;
        }
        //thrown = true;
        //Object = gameObject.transform;
        //speedTimer = 0;
        
        //target = GameObject.Find("Circle");
        //aiming = false;
    }

    // Update is called once per frame
    void Update()
    {
       
        //parentPos = new Vector2(parent.transform.position.x, parent.transform.position.y);
        //mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Mouse.current.position.ReadValue().x, Mouse.current.position.ReadValue().y, Camera.main.nearClipPlane));
        //mousePos = Camera.main.ScreenToViewportPoint(new Vector3(Mouse.current.position.ReadValue().x, Mouse.current.position.ReadValue().y, Camera.main.nearClipPlane));
        //new Vector2(target.transform.position.x, target.transform.position.y);
        //mousePos = target.transform.position;
        if (thrown)
        {

        
        distance=  mousePos.x - parentPos.x;
        nextX = Mathf.MoveTowards(transform.position.x, mousePos.x, speed * Time.deltaTime);
        baseY = Mathf.Lerp(parentPos.y, mousePos.y, (nextX - parentPos.x) / distance);
        //baseY = Mathf.Lerp(parent.transform.position.y, target.transform.position.y, (nextX- parentPos.x)/distance);
        height = 2 * (nextX - parentPos.x) * (nextX - mousePos.x)/(-.25f * distance * distance);
        Vector3 movePosition = new Vector3(nextX, baseY + height, transform.position.z);
        transform.rotation  = LookAtTarget(movePosition - transform.position);
        transform.position = movePosition;
        RaycastHit2D hitDown = Physics2D.Raycast(transform.position, -Vector2.up,.5f);
        Debug.DrawRay(transform.position, -Vector2.up * .5f, Color.red);
        if (hitDown)
        {
            if (hitDown.collider.gameObject.CompareTag("Floor"))
            {
                //collectable = true;
                GetComponent<Rigidbody2D>().gravityScale = 0;
                collectable = true;
                //thrown = false;
                //Debug.Log("Distance between floor and me is " + Mathf.Abs(transform.position.y - hitDown.collider.gameObject.transform.position.y));
            }
        }
        }
        //The following code is used for moving targets, therefore moving the mouse will also move the thrown object while in flight, not needed
        //nextX = Mathf.MoveTowards(transform.position.x, mousePos.x, speed * Time.deltaTime);
       /*if (thrown)
        {
            //GORB2D.AddRelativeForce(new Vector2(speed * Time.deltaTime, speed * Time.deltaTime), ForceMode2D.Impulse);
            gameObject.GetComponent<CapsuleCollider2D>().isTrigger = false;
        }*/
    }
    public static Quaternion LookAtTarget(Vector2 rotation)
    {
        return Quaternion.Euler(0, 0, Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg);
    }    
    
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Player") && collectable)
        {
            //Debug.Log("Destroy gameobject");
            coll.gameObject.GetComponent<PlayerController>().BreadCrumbAmount--;
            Destroy(gameObject);
        }
        //if (coll.gameObject.CompareTag("Floor") && thrown)
        //{

            //collectable = true;
          //  Debug.Log("Where is the floor");
          //  Debug.Log(coll.transform.position);
            //gameObject.GetComponent<CapsuleCollider2D>().isTrigger = false;
            //GORB2D.linearVelocity = new Vector2(0, 0);
        //}
    }
    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Player") && !thrown)
        {

            //thrown = true;
            collectable = true;
           // Debug.Log("let the player pickup the breadcrumbs");
            //Debug.Log("Add gameobject to breadcrumbarray")
        }
    }
}
