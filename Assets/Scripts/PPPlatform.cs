using Unity.AppUI.UI;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

[RequireComponent(typeof(Rigidbody2D))]
public class PPPlatform : MonoBehaviour
{
    [SerializeField] private Vector2 travelOffset = new Vector2(3f, 0f);
    [SerializeField] private float speed = 2f;
    [SerializeField] private float waitTime;

    private Rigidbody2D body;
    private Vector2 startPosition;
    private Vector2 targetPosition;
    private float waitTimer;

    private bool powered;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        body.bodyType = RigidbodyType2D.Kinematic;
        body.gravityScale = 0f;
        //The three bits of script above set the existence of the platform as a physical body.
        //That does not abide by gravity. 

        startPosition = body.position;
        targetPosition = startPosition + travelOffset;
        //Awake: is called the instance script is loaded. 
    }

    private void FixedUpdate()
    {
        if (powered)
       {
            if (waitTimer > 0f)
        {
            waitTimer -= Time.fixedDeltaTime;
            return;
         // 0f: Is a float. 
         // waitTimer = waitTimer - Time.fixedDeltaTime
         // waitTimer plays once platform reaches destination, it is set to that value. 
         // This acts as a count down timer. 
        }

       
            Vector2 nextPosition = Vector2.MoveTowards(
            body.position,
            targetPosition,
            speed * Time.fixedDeltaTime);
            body.MovePosition(nextPosition);

            if (nextPosition == targetPosition)
            {
                targetPosition = targetPosition == startPosition
                    ? startPosition + travelOffset
                    : startPosition;
                waitTimer = waitTime;
            }
       }

       
    }

    public void PowerPlatform(bool powered)
    {
        this.powered = powered;
    }
}
