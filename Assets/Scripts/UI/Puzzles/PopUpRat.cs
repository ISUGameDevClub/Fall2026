using UnityEngine;

public class PopUpRat : MonoBehaviour
{
    // to activate and deactivate the rat
    [SerializeField] private GameObject rat;

    // minimum time between popping up
    [SerializeField] private float popUpRangeStart = 1f;

    // maximum time between popping up
    [SerializeField] private float popUpRangeEnd = 6f;

    // minimum time staying up
    [SerializeField] private float durationRangeStart = 1f;

    // maximum time staying up
    [SerializeField] private float durationRangeEnd = 3f;


    // timer for how long between popping up
    private float popUpTimer;

    // timer for how long staying up
    private float durationTimer;

    // end of popUpTimer
    private float popUpEnd;

    // end of durationTimer 
    private float durationEnd;

    // if the rat has been hit
    private bool wasHit;

    void Start()
    {
        // set starting values for variables
        popUpTimer = 0f;
        popUpEnd = SetRandomEnd(0);
        durationTimer = 0f;
        durationEnd = SetRandomEnd(1);
        wasHit = false;
    }

    void Update()
    {
        // start popUpTimer
        popUpTimer += Time.unscaledDeltaTime;
        
        // end of popUpTimer
        if (popUpTimer > popUpEnd)
        {
            // checks if rat has already been hit
            if (!wasHit)
            {
                // turn on the rat
                rat.SetActive(true);
            }

            // start durationTimer
            durationTimer += Time.unscaledDeltaTime;

            // end of durationTimer
            if (durationTimer > durationEnd)
            {
                // turn off rat in case it wasn't hit
                rat.SetActive(false);

                // reset variables with new random numbers
                popUpTimer -= popUpEnd;
                popUpEnd = SetRandomEnd(0);
                durationTimer -= durationEnd;
                durationEnd = SetRandomEnd(1);
                wasHit = false;
            }
        }
    }

    // method to set a random number for the timer ends
    // 0 for popUpEnd
    // anything else for durationEnd
    private float SetRandomEnd(int selection)
    {
        if (selection == 0)
        {
            return Random.Range(popUpRangeStart, popUpRangeEnd);
        } else
        {
            return Random.Range(durationRangeStart, durationRangeEnd);
        }
        
    }

    // method called when rat is clicked/hit
    public void Hit()
    {
        rat.SetActive(false);
        wasHit = true;
    }

    // method called when puzzle window opened to reset puzzle
    public void ResetPuzzle()
    {
        rat.SetActive(false);
        popUpTimer = 0f;
        popUpEnd = SetRandomEnd(0);
        durationTimer = 0f;
        durationEnd = SetRandomEnd(1);
        wasHit = false;
    }
}
