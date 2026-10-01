using UnityEngine;


/*
 * ANIMAL CONTROL SETUP:
 *
 * Animal Control GameObject:
 *      - Make sure it has a "AnimalControl" tag!!!
 *      - Make sure it has a Rigidbody2D
 *      - Make sure it has a BoxCollider2D (NOT a trigger!!!)
 *      - SpriteRenderer
 *      - This animalControlAI script!!!
 * Player: Tag = "Player" If the player does not have the "Player" tag, this ain't gonna work right.
 *
 * Level geometry:
 *      - Needs a Collider2D
 *      - The "AI" recognizes all surfaces that have the "ground" layer. If it does not have a "ground" layer, the AI won't detect it.
 *
 * The AI finds the Player by tag(!!!), checks its distance, checks whether
 * the Player is in front, then uses a Raycast to see whether a wall
 * or other Ground object is blocking its view.
 */

/*
 * The Design Document only had two sentences.
 * "If player enters radius of animal control, they go back to last checkpoint"
 * and
 * "Must get evade or block their line of sight"
 * So, the enemy is really simple.
 * The Enemy will turn around and change its velocity when it encounters: A ledge, a wall (classified with a "ground" layer!), or another "AnimaControl" tagged enemy.
 * Since I don't know where anything about any checkpoints, I've assumed "they go back to last checkpoint" as "not my job."
 * So, when the enemy has seen the player, the AI will stop in its tracks.
 * I've left a clearly labeled spot where "back to last checkpoint" logic should go. Ya can't miss it.
 * The player is only "seen" when there is not an obstacle in the way + the player is to the enemy's FRONT. You CAN sneak BEHIND the enemy without being caught.
 */

public class animalControlAI : MonoBehaviour
{
    //AI variables
    /* [SerializeField] keeps the variable private
     * while still allowing us to change it from Unity's Inspector tab.
     */

    //How fast Animal Control moves while patrolling.
    [SerializeField] private float moveSpeed = 3.0f;

    //-1 and +1 for direction. -1 for left, +1 for right.
    private int moveDirection = 1;


    //How far ahead of Animal Control we check for a wall.
    [SerializeField] private float wallCheckDistance = 0.6f;

    //Which physics layer(s) count as solid level geometry.
    //Set this to the "Ground" layer in Unity's Inspector panel!!!
    [SerializeField] private LayerMask groundLayer;


    //How far IN FRONT of Animal Contorl's foot we begin checking for a ledge.
    [SerializeField] private float ledgeCheckForwardDistance = 0.1f;

    //How far DOWN we check for ground.
    [SerializeField] private float ledgeCheckDistance = 0.4f;


    //How close the Player needs to be before Animal Control can see them.
    //This replaces the old CircleCollider2D detection radius.
    [SerializeField] private float detectionRadius = 5.0f;

    //Raises the start of our sight Raycast above Animal Control's feet.
    //Basically tells the Raycast approximately where Animal Control's "eyes" are.
    [SerializeField] private float eyeHeight = 0.3f;


    //Retrieve a reference to the RigidBody2D
    //We will use this to control movement.
    private Rigidbody2D rigidBody;

    //Reference to the Animal Control's SpriteRenderer.
    //We will use this to visually flip the enemy when changing directions.
    private SpriteRenderer spriteRenderer;

    //Reference to the Animal Control's physical BoxCollider2D.
    //We use its size when checking for walls and ledges.
    private BoxCollider2D bodyCollider;

    //Reference to the Player's Transform.
    //We use this to know where the Player currently is.
    private Transform playerTransform;



    private void Awake() //Upon initialization of this particular component.
                         //"Start()" would be closer to UE5's "BeginPlay"
                         //"Awake()" would start *sooner* than "BeginPlay"
                         //"FixedUpdate()" is used for physics behavior and runs on the physics timestep.
    {
        /*
         * Find the components attached to this same GameObject (~Actor)
         * and store references to them.
         *
         * Because of this, the Rigidbody2D, SpriteRenderer, and BoxCollider2D
         * all need to be attached to the same GameObject as this script.
         */
        rigidBody = GetComponent<Rigidbody2D>();

        spriteRenderer = GetComponent<SpriteRenderer>();

        bodyCollider = GetComponent<BoxCollider2D>();


        /*
         * Search the scene for the GameObject tagged "Player."
         * If we find it, save a reference to its Transform.
         *
         * This means Animal Control can keep track of where the Player is
         * without needing a CircleCollider2D trigger around itself.
         */
        GameObject playerObject =
            GameObject.FindGameObjectWithTag("Player");

        if (playerObject != null)
        {
            playerTransform = playerObject.transform;
        }
    }



    private void FixedUpdate() //Good for physics-related behavior
    {
        /*
         * FIRST, check whether Animal Control can currently see the Player.
         * If it CAN see the Player, stop Animal Control's horizontal movement.
         */
        if (CanSeePlayer())
        {
            rigidBody.linearVelocity = new Vector2(
                0.0f, rigidBody.linearVelocity.y
            );

            /*
             * TODO: PLAYER CHECKPOINT LOGIC GOES HERE!!!
             * 
             * AI has successfully detectedw the player.
             * At this point, the player is supposed to be sent back to their
             * most recent checkpoint, no?
             * 
             * Whatever returns the player to the last checkpoint SHOULD BE CALLED HERE!!!
             * AI sees player -> AI stops moving (for as long as the palyer is seen) ->
             * -> reset player to previous checkpoint. 
             * 
             * TODO: PLAYER CHECKPOINT LOGIC GOES HERE!!!
             * 
             * 
             * 
             * 
             * TODO: PLAYER CHECKPOINT LOGIC GOES HERE!!!
             * 
             * 
             * 
             * 
             * TODO: PLAYER CHECKPOINT LOGIC GOES HERE!!!
             * 
             * 
             * 
             * 
             * TODO: PLAYER CHECKPOINT LOGIC GOES HERE!!!
             * 
             * 
             * 
             * 
             * TODO: PLAYER CHECKPOINT LOGIC GOES HERE!!!
             * 
             * 
             * 
             * 
             * 
             */

            //Return ends this particular FixedUpdate() here.
            //This prevents the normal patrol behavior below from running.
            return;
        }


        /*
         * If Animal Control DOESN'T see teh Player, continue patrolling.
         *
         * Turn around if:
         *     1. There is a wall ahead
         * OR
         *      2. There is NOT ground ahead (a ledge)
         */
        if (CheckForWall() || CheckForLedge())
        {
            TurnAround(); //tada
        }


        /*
         * Set Animal Control's horizontal velocity.
         * We calculate X-velocity using moveDirection * moveSpeed.
         *
         * If moveDirection is 1: 1 * moveSpeed = Move Right
         * If moveDirection is -1: -1 * moveSpeed = Move Left
         *
         * We preserve the existing Y-velocity so gravity is
         * still free to make Animal Control fall normally. (I think)
         */
        rigidBody.linearVelocity = new Vector2(
            moveDirection * moveSpeed, rigidBody.linearVelocity.y
        );
    }



    //Turns the AI around.
    private void TurnAround()
    {
        //Multiply the current direction by -1
        //Every call reverses the movement direction.
        moveDirection *= -1;

        /* "flipX" is a bool belonging to the SpriteRenderer
         * false = sprite drawn normally
         * true = sprite horizontally mirrored
         */
        //Every time we turn around, we swap the CURRENT flipX state.
        spriteRenderer.flipX = !spriteRenderer.flipX; //Since the test sprite is symmetrical, you can't really tell, but trust me bro.
    }



    //Called when teh Animal Control's physical collider hits another collider.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        /*
         * Check whether the GameObject we hit has the "AnimalControl" tag.
         * If two Animal Control enemies physically bump into each other,
         * they should both know to turn around instead of pushing forever.
         */
        if (collision.gameObject.CompareTag("AnimalControl")) //Again, make sure the AI has the tag!!!
        {
            TurnAround();
        }
    }



    //Checks whether Animal Control can currently see the Player.
    private bool CanSeePlayer()
    {
        /*
         * If Awake() never found a Player GameObject, then we have no
         * Player position to check against.
         */
        if (playerTransform == null)
        {
            return false;
        }


        /*
         * STEP 1: Is the Player close enough?
         *
         * Subtract Animal Control's position from teh Player's position.
         * This gives us a Vector pointing FROM Animal Control TO the Player.
         */
        Vector2 differenceToPlayer =
            (Vector2)playerTransform.position -
            (Vector2)transform.position;


        /*
         * "sqrMagnitude" gives us the squared length of that Vector.
         *
         * Since distanceSquared is squared, detectionRadius also needs to
         * be squared before the two values can be compared.
         */
        float distanceSquared = differenceToPlayer.sqrMagnitude;

        float detectionRadiusSquared =
            detectionRadius * detectionRadius;

        //Too far away = Animal Control CANNOT see the Player.
        if (distanceSquared > detectionRadiusSquared)
        {
            return false;
        }


        /*
         * STEP 2: Is the Player actually IN FRONT of Animal Control?
         *
         * Being *inside* the radius alone is not enough.
         * See "IsPlayerInFront()" function.
         */
        if (!IsPlayerInFront())
        {
            return false;
        }
        /*
         * STEP 3: Is a wall blocking Animal Control's view?
         * First, make an approximate "eye position." 
         * Maybe play around with this value, cuz I never really checked.
         * See "eyeHeight" variable.
         * This is just Animal Control's position moved upward by approximate eyeHeight.
         */
        Vector2 eyePosition = new Vector2(
            transform.position.x,
            transform.position.y + eyeHeight
        );

        //Save the player's current position as a Vector2.
        Vector2 playerPosition = playerTransform.position;
        /*
         * Subtract the eye position from the Player position.
         * This gives us the direction FROM Animal Control's eyes TO the Player.
         */
        Vector2 directionToPlayer =
            playerPosition - eyePosition;

        //Get the actual distance between Animal Control's eyes and the Player.
        float distanceToPlayer =
            directionToPlayer.magnitude;
        /*
         * Normalize() changes the Vector's length to 1 without changing
         * the direction it points.
         *
         * Physics2D.Raycast() wants a direction, while distanceToPlayer
         * separately tells it how far to cast.
         */
        directionToPlayer.Normalize();


        /*
         * Raycast is similar to UE5's Line Trace.
         *
         * We cast FROM Animal Control's eyes TOWARD the Player.
         *
         * IMPORTANT:
         * This Raycast ONLY checks the "Ground" layer.
         * We already know where the Player is, so we do NOT need the
         * Raycast to hit the Player.
         *
         * We only care whether a wall, floor, platform, etc. on the
         * Ground layer is sitting BETWEEN Animal Control and the Player.
         * 
         * THIS IS WHY OBSTACLES NEED TO HAVE THE "ground" LAYER!!!
         */
        RaycastHit2D obstacleHit = Physics2D.Raycast(
            eyePosition,             //Origin
            directionToPlayer,       //Direction
            distanceToPlayer,        //Distance
            groundLayer              //Layers to detect (Ground!)
        );


        /*
         * Draw the same sight-line in Unity's Scene view for debugging.
         * This does NOT appear on the player's actual game screen.
         */
        Debug.DrawRay(
            eyePosition,
            directionToPlayer * distanceToPlayer,
            Color.green
        );


        //If the Raycast hit "Ground," something is blocking Animal Control's view.
        if (obstacleHit.collider != null)
        {
            return false; //There's an obstacle in the way. Player is NOT seen.
        }
        /*
         * If we reached this point:
         * The Player exists. Yes
         * The Player is close enough. Yes
         * The Player is in front. Yes
         * Nothing on the Ground layer is blocking the view. Yes
         * Therefore, Animal Control can see the Player.
         */
        return true; //Seen!
    }



    //Checks whether teh Player is on the side Animal Control is currently facing.
    private bool IsPlayerInFront()
    {
        /*
         * If moveDirection is +1, Animal Control is moving RIGHT.
         * So, the Player's X position needs to be GREATER than ours.
         */
        if (moveDirection == 1)
        {
            return playerTransform.position.x > transform.position.x;
        }
        /*
         * Otherwise, moveDirection is -1 and Animal Control is moving LEFT.
         * So, the Player's X position needs to be LESS than ours.
         */
        return playerTransform.position.x < transform.position.x;
    }



    //Makes the AI check for a wall (Knows when to turn around)
    private bool CheckForWall()
    {
        /*
         * We create a smaller BoxCast using Animal Control's physical collider.
         * The cast is only 20% as wide and 70% as tall as the real collider. Hence my 0.2f and0.7f
         * (Maybe play around with these values too).
         * This keeps the wall check concentrated in front of Animal Control
         * instead of using its entire physical body.
         */
        Vector2 wallCheckSize = new Vector2(
            bodyCollider.bounds.size.x * 0.2f,
            bodyCollider.bounds.size.y * 0.7f
        );


        /*
         * BoxCast is similar to UE5's Box Trace.
         * Unlike a Raycast (UE5's Line Trace), a BoxCast checks using
         * a rectangular area instead of one thin line.
         * We cast in whatever direction moveDirection currently points.
         */
        RaycastHit2D wallHit = Physics2D.BoxCast(
            bodyCollider.bounds.center,         //Origin
            wallCheckSize,                      //Size of box
            0.0f,                               //rotation
            Vector2.right * moveDirection,      //Direction
            wallCheckDistance,                  //Distance
            groundLayer                         //Layers to detect (Ground)!
        );

        //If the BoxCast hit something on Ground, there is a wall ahead.
        return wallHit.collider != null;
    }



    //Makes the "AI" check whether there is still floor in front of it.
    private bool CheckForLedge()
    {
        /*
         * Find a point slightly IN FRONT of Animal Control's front foot.
         *
         * bodyCollider.bounds.extents.x is HALF the collider's width.
         * We add ledgeCheckForwardDistance so the point is placed a little
         * farther forward than the collider itself.
         *
         * moveDirection makes that point move to the correct side:
         * +1 = right side
         * -1 = left side
         */
        Vector2 ledgeCheckOrigin = new Vector2(
            bodyCollider.bounds.center.x +
            (
                (bodyCollider.bounds.extents.x +
                 ledgeCheckForwardDistance)
                * moveDirection
            ),
            //Start just slightly above the very bottom of the collider.
            bodyCollider.bounds.min.y + 0.05f
        );


        /*
         * Raycast straight DOWN from the point in front of Animal Control.
         * If we hit Ground, there is still floor there.
         * If we hit nothing, Animal Control is about to walk off a ledge.
         * Don't let em' walk off the edge. No bueno.
         */
        RaycastHit2D groundHit = Physics2D.Raycast(
            ledgeCheckOrigin,        //Origin
            Vector2.down,            //Direction
            ledgeCheckDistance,      //Distance
            groundLayer              //Layers to detect (Ground!)
        );

        //No Ground layer underneath the forward point = there is a ledge ahead.
        return groundHit.collider == null;
    }
}
