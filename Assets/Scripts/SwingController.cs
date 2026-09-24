using UnityEngine;
using UnityEngine.InputSystem;

public class SwingController : MonoBehaviour
{
    [SerializeField] private float maxHookDistance = 20f;
    [SerializeField] private string hookTag = "Hook";

    private DistanceJoint2D swingJoint;
    private InputAction swingAction;

    private void Awake()
    {
        swingJoint = gameObject.AddComponent<DistanceJoint2D>();
        swingJoint.enabled = false;
        swingJoint.autoConfigureDistance = false;
        swingJoint.maxDistanceOnly = false;

        PlayerInput playerInput = GetComponent<PlayerInput>();
        if (playerInput != null && playerInput.actions != null)
        {
            swingAction = playerInput.actions.FindAction("Swing");
        }
    }

    private void OnEnable()
    {
        if (swingAction != null)
        {
            swingAction.performed += OnSwing;
            swingAction.canceled += OnSwing;
            swingAction.Enable();
        }
    }

    private void OnDisable()
    {
        if (swingAction != null)
        {
            swingAction.performed -= OnSwing;
            swingAction.canceled -= OnSwing;
        }
    }

    public void OnSwing(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            AttachToNearestHook();
        }
        else if (context.canceled)
        {
            ReleaseSwing();
        }
    }

    private void AttachToNearestHook()
    {
        GameObject nearestHook = FindNearestHook();

        if (nearestHook == null)
        {
            return;
        }

        Rigidbody2D hookBody = nearestHook.GetComponent<Rigidbody2D>();
        swingJoint.connectedBody = hookBody;

        if (hookBody == null)
        {
            swingJoint.connectedAnchor = nearestHook.transform.position;
        }

        swingJoint.distance = Vector2.Distance(transform.position, nearestHook.transform.position);
        swingJoint.enabled = true;
    }

    private GameObject FindNearestHook()
    {
        GameObject nearestHook = null;
        float nearestDistance = maxHookDistance * maxHookDistance;

        foreach (GameObject hook in GameObject.FindGameObjectsWithTag(hookTag))
        {
            float distance = ((Vector2)(hook.transform.position - transform.position)).sqrMagnitude;

            if (distance < nearestDistance)
            {
                nearestDistance = distance;
                nearestHook = hook;
            }
        }

        return nearestHook;
    }

    private void ReleaseSwing()
    {
        swingJoint.enabled = false;
        swingJoint.connectedBody = null;
    }

    private void OnDestroy()
    {
        if (swingJoint != null)
        {
            Destroy(swingJoint);
        }
    }
}