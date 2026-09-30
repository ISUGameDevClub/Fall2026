using UnityEngine;
using UnityEngine.InputSystem;

public class BreadCrumbBehavior : MonoBehaviour
{
    private bool collectable;
    public bool thrown;
    private Rigidbody2D GORB2D;
    [SerializeField] private float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GORB2D = gameObject.GetComponent<Rigidbody2D>();
        collectable = false;
        //aiming = false;
    }

    // Update is called once per frame
    void Update()
    {
       
       if (thrown)
        {
            //GORB2D.linearVelocity = 0.05f * new Vector2(25, 25);
            GORB2D.AddRelativeForce(new Vector2(speed * Time.deltaTime, speed * Time.deltaTime), ForceMode2D.Impulse);
        }
    }
   
    
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Player") && collectable)
        {
            //Debug.Log("Destroy gameobject");
            coll.gameObject.GetComponent<PlayerController>().BreadCrumbAmount--;
            Destroy(gameObject);
        }
    }
    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            collectable = true;
           // Debug.Log("let the player pickup the breadcrumbs");
            //Debug.Log("Add gameobject to breadcrumbarray")
        }
    }
}
