using UnityEngine;
using UnityEngine.InputSystem;

public class CameraManager : MonoBehaviour
{
    // Editable Variables
    [Tooltip("Where the center of the camera should be inr espect of the player (assuming player is looking right)")]
    [SerializeField] private Vector3 cameraFollowPosition = new Vector3(3, 0, 0);
    [Tooltip("How much the camera speeds up based on how far away the distance is")]
    [SerializeField] private float stiffness = 3;
    [Tooltip("How the function that determines the speed of the camera works\n" +
        "< 1: Gradual curve\n" +
        "= 1: Linear\n" +
        "> 1: Exponential\n")]
    [SerializeField] private float cameraChasePow = 1;
    [SerializeField] private float followZoom;

    // Other Variables
    private GameObject camera;
    private GameObject followPoint;
    private PlayerController controller;
    private int state = 0; // 0 = follow player, 1 = lock in on puzzle
    private float startZoom;
    private float zoom;
    private Vector3 center;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<PlayerController>();
        followPoint = transform.GetChild(0).gameObject;
        camera = Camera.main.gameObject;
        startZoom = camera.GetComponent<Camera>().orthographicSize;
        zoom = startZoom;
    }

    // Update is called once per frame
    void Update()
    {
        // Follow State Logic
        if (state == 0)
        {
            Vector3 tempCameraFollowPos = cameraFollowPosition;
            if (!controller.IsFacingRight())
            {
                tempCameraFollowPos.x = -tempCameraFollowPos.x;
            }
            Vector3 followPos = tempCameraFollowPos + transform.position;
            float distance = Vector2.Distance(camera.transform.position, transform.position);
            


            followPoint.transform.position = Vector3.MoveTowards(camera.transform.position, followPos, distance * stiffness);
            followPoint.transform.position = new Vector3(followPoint.transform.position.x, followPoint.transform.position.y, -10);
        }

        else if (state == 1)
        {
            followPoint.transform.position = Vector3.MoveTowards(followPoint.transform.position, center, stiffness);
            
        }

        // Change camera zoom if needed
        if (camera.GetComponent<Camera>().orthographicSize != zoom)
        {
            camera.GetComponent<Camera>().orthographicSize = Mathf.Lerp(camera.GetComponent<Camera>().orthographicSize, zoom, stiffness/2);
        }

        camera.transform.position = followPoint.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 12)
        {
            state = 1;
            center = collision.GetComponent<CameraLockZone>().GetCenterPos();
            zoom = collision.GetComponent<CameraLockZone>().GetZoom();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 12)
        {
            state = 0;
            zoom = startZoom;
        }
    }


}
