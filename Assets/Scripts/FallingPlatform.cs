using UnityEngine;
using UnityEngine.UIElements;

public class FallingPlatform : MonoBehaviour
{
    // the player
    [SerializeField] private GameObject player;

    // how long the platform stays in place
    [SerializeField] private float stayUpTime;

    // how fast the platform falls
    [SerializeField] private float fallSpeed;
    
    // how far the platform falls
    [SerializeField] private float fallDistance;

    // starting location of the platform
    private float startPoint;

    // if the platform is falling
    private bool falling;

    // if the timer has started
    private bool timerStart;

    // the timer
    private float stayUpTimer;

    void Start()
    {
        // set up starting values
        falling = false;
        timerStart = false;
        stayUpTimer = 0f;
        startPoint = GetComponent<Transform>().position.y;
    }

    void Update()
    {
        // if the player touches the platform
        if (GetComponent<BoxCollider2D>().IsTouching(player.GetComponent<CapsuleCollider2D>()))
        {
            timerStart = true;
        }

        // if the timer has started
        if (timerStart)
        {
            stayUpTimer += Time.deltaTime;
        }

        // if the timer has ended
        if (stayUpTimer >= stayUpTime)
        {
            falling = true;
        }

        // if the platform is falling
        if (falling)
        {
            if (GetComponent<Transform>().position.y > startPoint - fallDistance)
            {
                GetComponent<Transform>().position -= new Vector3(GetComponent<Transform>().position.x, Time.deltaTime * fallSpeed, 0);
            } else
            {
                Destroy(gameObject);
            }
        }
    }
}
