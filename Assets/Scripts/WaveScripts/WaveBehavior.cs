using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using System.Collections;


public class WaveBehavior : MonoBehaviour
{
    // General
    [SerializeField] private float resetDistance;
    [Tooltip("The speed at which the player moves forward.")]
    [SerializeField] private float speed = 5f;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private PlayerController playerScript;
    [SerializeField] private int CrumbLossAmount;

    private bool move = false;  //turns it all on
    private bool reset = true;  //for reset for loop
    [Tooltip("Decides wether it is a constant loop or just goes up. (true: loop / false: Up and stop).")]
    [SerializeField] private bool MovementType = true;
    private bool direction = true; //true up / false down

    private bool blocker = true;//stop movement from happening while moving

    //locations for loop
    [SerializeField] private float topLocation;
    [SerializeField] private float bottomLocation;

    //text
    [SerializeField] private TextMeshProUGUI warningText;
    [SerializeField] private TextMeshProUGUI hitText;

    //wait timer
    [SerializeField] private float waitAfterWarning;
    [SerializeField] private float waitBeforeRestart;//only for loop MovementType
    [SerializeField] private float pauseBeforeDown;//only for loop MovementType

    //for reset
    private Vector2 startingPosition;
    private Vector2 playerPos;

    private Coroutine movementControlVar;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
        startingPosition = transform.position;
        StartCoroutine(WaveLoop());

        
    }

    // Update is called once per frame
    void Update()
    {
       


    }

    /*
    * starts the loop
    */
    IEnumerator WaveLoop()
    {
        while (true)
        {
            if (move)
                yield return movementControlVar = StartCoroutine((movementControl()));
            else
                yield return null;
        }
    }

    /*
     * controls the hole loop depening on the movment type
     */
    IEnumerator movementControl()
    {
        if (MovementType && blocker)//loop
        {
            while (move && MovementType)
            {
                reset = true;
                blocker = false;
                ShowWarningText();
                yield return new WaitForSeconds(waitAfterWarning);
                HideWarningText();
                spriteRenderer.enabled = true;
                yield return StartCoroutine(goUp());
                yield return new WaitForSeconds(pauseBeforeDown);
                yield return StartCoroutine(goDown());
                spriteRenderer.enabled = false;
                yield return new WaitForSeconds(waitBeforeRestart);
            }
        }
        else if (!MovementType && blocker)//up
        {
            reset = true;
            direction = true;
            blocker = false;
            ShowWarningText();
            yield return new WaitForSeconds(waitAfterWarning);
            HideWarningText();
            spriteRenderer.enabled = true;
            Debug.Log("BYYYYEEEEE");
            yield return StartCoroutine(goUp());
        }
        yield return null;
    }

   /*
    * up loop
    *
    */
    IEnumerator goUp()
    {
        //Debug.Log("This object y" + transform.position.y + " < This object y" + topLocation + "This object y" + transform.position.y);

        while (transform.position.y < topLocation&&reset && direction)
        {
            
            transform.Translate(Vector3.up * speed * Time.deltaTime);
            yield return null;
        }
        direction = false;
    }

    /*
    * down loop
    *
    */
    IEnumerator goDown()
    {
        while (transform.position.y > bottomLocation && !direction)
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
            yield return null;

        }
            direction = true;
    }


    

    public void onSwitch()
    {
        Debug.Log("on Switch");
        direction = true;
        move = true;
        blocker = true;
    }

    public void offSwitch()
    {
        move = false;
    }

    /*
     *  Triger for colitions based on if it is a rat or player 
     */
     
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Rat"))
        {
            Debug.Log("Rat hit put rat kill here");
        }
        if (other.CompareTag("Player"))
        {
            playerScript.addBreadCrumbs(CrumbLossAmount);
            if (MovementType) 
            {
                

                Invoke("ResetToStart", 0.2f);
                ShowHitText();

                Invoke("HideHitText", 1f);
                
                StopCoroutine(movementControlVar);

                Invoke("onSwitch", 2f);
                StartCoroutine(WaveLoop());
            }
            else
            {
                playerPos = other.transform.position;
                //ResetOnHit();
                Invoke("ResetOnHit", 0.2f);
                ShowHitText();

                Invoke("HideHitText", 1f);
                //HideHitText();

                //Invoke("onSwitch", 0.5f);

                StopCoroutine(movementControlVar);

                Invoke("onSwitch", 2f);
                StartCoroutine(WaveLoop());
                //onSwitch();
            }

                
           
        }
        
    }

    /*
     * Restart for the constant loop verstion
     * 
     * resets to start position
     */
    public void ResetToStart()
    {
        transform.position = startingPosition;
        move = false;
        blocker = true;
        reset = false;



    }

    /*
     * Restart for the constant up verstion
     * 
     * resets the wave at resetDistance distance from the player
     */
    public void ResetOnHit()
    {
        transform.position = new Vector3(transform.position.x, (playerPos.y - resetDistance), transform.position.z);
        move = false;
        blocker = false;
        reset = false;
        //onSwitch();
    }

    public bool getMove()
    {
        return move;
    }

    public void ShowWarningText()
    {
        warningText.enabled = true;
        warningText.gameObject.SetActive(true);
    }

    public void HideWarningText()
    {
        warningText.enabled = false;
        warningText.gameObject.SetActive(false);
    }

    public void ShowHitText()
    {
        hitText.enabled = true;
        hitText.gameObject.SetActive(true);
    }

    public void HideHitText()
    {
        hitText.enabled = false;
        hitText.gameObject.SetActive(false);
    }
}
