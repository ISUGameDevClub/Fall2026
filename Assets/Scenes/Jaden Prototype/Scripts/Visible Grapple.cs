using UnityEngine;

public class VisibleGrapple : MonoBehaviour
{
    SwingController swingScript;
    private float maxDistance;
    private Transform transform;
    private SpriteRenderer spriteRenderer;
    GameObject player;
    GameObject thisHook;
    GameObject hook=null;

    void Start()
    {


        spriteRenderer = GetComponent<SpriteRenderer>();

        player = GameObject.FindWithTag("Player");

        //to find the max distance grapple
        swingScript = player.GetComponent<SwingController>();
        maxDistance = swingScript.getMaxHookDistance();

        //changes the size
        transform = GetComponent<Transform>();
        if (transform != null ) 
            transform.localScale = new Vector3(maxDistance * 2, maxDistance * 2, 1.0f);
        
        thisHook = transform.parent.gameObject;


    }

    // Update is called once per frame
    void Update()
    {
        colorChange();//collor changing
    }

    //checks if the nearest hook is this hook
    private bool checkIfHook()
    {
        if (swingScript == null)
        {
            return false;
        }
        else
        {
            
            hook = swingScript.getNearestHook();
            if (thisHook != hook)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        
    }

    //function to change color
    private void colorChange()
    {
        if (checkIfHook())
            spriteRenderer.color = new Color32(82, 167, 138, 107);
        else
            spriteRenderer.color = new Color32(82, 105, 138, 107);
    }


}
