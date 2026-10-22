 
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using Unity.VisualScripting;
using NUnit.Framework.Constraints;
using UnityEditor.Build.Content;

public class PigeonManager : MonoBehaviour
{
    private Queue<GameObject> BreadCrumbs = new Queue<GameObject>();
    /* Odin Understanding: The "Queue<GameObject>" states that this is a queue using GameObject.
     * This Queue's name is BreadCrumbs.*/
    private SpriteRenderer sprite;
    //^ To be able to see the sprite of the pigeon. 
    private bool movement = false;
    //^ For the movement to be in motion. 
    GameObject target;
    private GameObject player;
    bool active = false;
    [SerializeField] private float speed = 5;
    //^ What the pigeon will go after. Whether that is the player or bread crumbs. The collider. 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        sprite.enabled = false;
        player = GameObject.FindGameObjectWithTag("Player");
        //^ Meaning that the sprite of the pigeon is off. 

        //^active is button state. When starting the button state is off. 

        if (target != null)
        {
            target = GameObject.Find("BreadCrumb");
            // If the target is not empty, there is breadcrumbs. So, find the game object
            // with the tag "BreadCrumb". 
        }
        else
        {
            target = GameObject.Find("Player");
            // If the target is empty, there is no breadcrumbs left. 
            // Find game object with tag "Player". 
        }

    }


    /*
    --- Pigeon Ability for Crumb Collection --- Odin
    */

    // 1st - Configure Button to Pigeon
    // That is in the input systems. Written here for note. 
    // The instance is to the input system. That is the GameObject. 
    void Update()
    {
        if (Keyboard.current.lKey.wasPressedThisFrame)
        {
            
            Debug.Log(BreadCrumbs.Peek());
        }


        if (Keyboard.current.pKey.wasPressedThisFrame)
        {
            // The "p" key is pressed. 
            // "p" due to pigeon. 
            // This is a temp input system

            // Make code for moving pigeon to breadcrumb. 
            // Teleport to player.
            
            /* ^Flips the truth values. Meaning the state of the button flipped. 
             */


            if (!movement)
            {
                while (BreadCrumbs.Count > 0)
                {
                    if (BreadCrumbs.Peek() == null)
                    {
                        BreadCrumbs.Dequeue();
                    }
                    else break;
                }

                if (!active && BreadCrumbs.Count > 0)
                {
                    Debug.Log("Inactive and Queue is not empty: Send out pigeon");
                    active = true;
                    sprite.enabled = true;
                    transform.position = player.transform.position;

                    target = BreadCrumbs.Dequeue();
                    movement = true;

                    /* Works when the push of the function is activated. Along with the queue not being empty.
                     * If the queue is not empty. The target is delegated to the item at the top of the queue. 
                     * Making it where the pigeon starts moving to the target. 
                     */
                }
                else if (active && BreadCrumbs.Count > 0)
                {
                    Debug.Log("Active and Queue is not empty: Send pigeon to next crumb");
                    target = BreadCrumbs.Dequeue();
                    movement = true;
                }
                else if (active && BreadCrumbs.Count == 0)
                {
                    Debug.Log("Active and Queue is empty: Send Pigeon to player");
                    target = GameObject.Find("Player");
                    // Mayber should be "Player"
                    movement = true;
                }
                Debug.Log("Target : " + target.name);

            }
        }

        if (movement)
        {

            // Move to breadcrumb. 
            
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime); 
            if (transform.position == target.transform.position)
            {
                movement = false;
                //If the pigeon overlaps with the breadcrumb they stop moving. 
                if (target == GameObject.Find("Player"))
                {
                    active = false;
                    sprite.enabled = false;
                    //If the pigeon is at the player it disables function. 
                }
                else
                {
                    Destroy(target);
                }
            }

            
            // After task is done, the sprite of the bird turns off. 

        }
    }
    // ^ Update is called once per frame

    public void SpawnedBreadcrumb(GameObject breadCrumb)
    {
        Debug.Log("Bread Crumb: " +  breadCrumb);
        BreadCrumbs.Enqueue(breadCrumb);

        // When we call this function in player controller, it puts that data into "breadCrumb" as a temp variable. 
        // This is for the queue with the spawning bread crumbs. 
    }


    // 2nd - Make pigeon follow the queue/arrary of breadcrumbs. 
    // Grab game object of bread crumb. Name "BCGO"
    
    /*
    void OnTriggerEnter2D(Collider2D coll)
    {
        //^ Script being entered on it, activates it. ^
        if (coll.gameObject == BreadCrumbs.Peek())
        {

            Destroy(coll.gameObject);
            BreadCrumbs.Dequeue(); 
            
        }
    }
    */

    // BreadCrumbLimit: total breadcrumbs in inventory. 
    // BreadCrumbAmount: Amount of bread crumbs on screen. 
    /// Within in the updates account for player picking up breadcrumbs and rats. 
    /// Activating Pigeon, goes to the queued breadcrumb, nulls it, activate again, to the next. Returns when whole queue is null after final input. 
    //// Figure out how to see selected deletion.
    //// Possibly checking a collided object. 
    //// ^ Possibly be checking for null. 

    // 3rd - Bird collison. 
    // No collision of floors and walls. 


    /*
     --- End of Pigeon Ability for Crumb Collection --- Odin
     */
}
