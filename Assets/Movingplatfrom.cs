using UnityEngine;

public class Movingplatfrom : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float movespeed = 2f;

    private Vector3 nextPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        nextPosition = pointB.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, nextPosition, movespeed * Time.deltaTime);

        if (transform.position == nextPosition)
        {
            nextPosition = (nextPosition == pointA.position) ? pointB.position : pointA.position;
        }
    }

    }

