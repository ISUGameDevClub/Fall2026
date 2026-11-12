using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private Vector2 travelOffset = new Vector2(3f, 0f);
    [SerializeField] private float speed = 2f;
    [SerializeField] private float waitTime;

    private Rigidbody2D body;
    private Vector2 startPosition;
    private Vector2 targetPosition;
    private float waitTimer;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        body.bodyType = RigidbodyType2D.Kinematic;
        body.gravityScale = 0f;

        startPosition = body.position;
        targetPosition = startPosition + travelOffset;
    }

    private void FixedUpdate()
    {
        if (waitTimer > 0f)
        {
            waitTimer -= Time.fixedDeltaTime;
            return;
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
